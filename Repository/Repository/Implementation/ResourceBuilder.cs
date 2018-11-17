﻿using DomainModels.Entites;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class ResourceBuilder : IResourceBuilder
    {
        DbContext db;
        public ResourceBuilder(DbContext _db)
        {
            db = _db;
        }
        public string Create(ResourceProvider provider, string namespaceName = "Resources", string className = "Resources", string filePath = null, string summaryCulture = null)
        {
            MethodInfo method = provider.GetType().GetMethod("ReadResources");
            IList<Resource> resources = method.Invoke(provider, null) as List<Resource>;

            if (resources == null || resources.Count == 0)
                throw new Exception(string.Format("No resources were found in {0}", provider.GetType().Name));

            // Get a unique list of resource names (keys)
            var keys = resources.Select(r => r.Name).Distinct();

            #region Templates
            const string header =@"using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace {0} {{
        public class {1} {{
            private static IResourceProvider resourceProvider = new {2}();

    {3}
        }}        
}}"; // {0}: namespace {1}:class name   {2}:provider class name   {3}: body  

            const string property =
@"
        {1}
        public static {2} {0} {{
               get {{
                   return ({2}) resourceProvider.GetResource(""{0}"", CultureInfo.CurrentUICulture.Name);
               }}
            }}"; // {0}: key
            #endregion

            // store keys in a string builder
            var sbKeys = new StringBuilder();

            foreach (string key in keys)
            {
                var resource = resources.Where(r => (summaryCulture == null ? true : r.Culture.ToLowerInvariant() == summaryCulture.ToLowerInvariant()) && r.Name == key).FirstOrDefault();
                if (resource == null)
                {
                    throw new Exception(string.Format("Could not find resource {0}", key));
                }

                sbKeys.Append(new String(' ', 12)); // indentation
                // Never Delete it
                /* sbKeys.AppendFormat(property, key,
                        summaryCulture == null ? string.Empty : string.Format("/// <summary>{0}</summary>", resource.Value),
                        resource.Type);*/
                //
                sbKeys.AppendFormat(property, key,
                    summaryCulture == null ? string.Empty : string.Format("/// <summary>{0}</summary>", resource.Value),
                    "string");
                sbKeys.AppendLine();
            }

            if (filePath == null)
                filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources.cs");
            // write to file
            using (var writer = File.CreateText(filePath))
            {

                // write header along with keys
                writer.WriteLine(header, namespaceName, className, provider.GetType().Name, sbKeys.ToString());

                writer.Flush();
                writer.Close();
            }

            return filePath;

        }
    }
}
