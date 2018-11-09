using DomainModels.Entites;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class ResourceProvider :  Repository<Resource>, IResourceProvider
    {
        // Cache list of resources
        private static IEnumerable<Resource> resources = null;
        private static object lockResources = new object();
        DbContext db;
        protected bool Cache { get; set; } // Cache resources ?
        public ResourceProvider(DbContext _db):base(_db)
        {
            db = _db;
            Cache = true; // By default, enable caching for performance
        }

        public DbSet<Resource> Resource { get; set; }

        public object GetResource(string name, string culture)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Resource name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Culture name cannot be null or empty.");
            // normalize
            culture = culture.ToLowerInvariant();
            if (Cache && resources == null)
            {
                // Fetch all resources
                lock (lockResources)
                {
                    if (resources == null)
                    {
                        resources = (ReadResources() as IEnumerable<Resource>);
                    }
                }
            }

            if (Cache)
            {
                return (resources as IEnumerable<Resource>).Where(x => x.Culture.ToLower() == culture.ToLower() && x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            }

            return ReadResource(name, culture);
        }

        public async Task<Resource> ReadResource(string name, string culture)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(culture))
                return await db.Set<Resource>().Where(x => x.Culture.ToLower() == culture.ToLower() && x.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
            else
                return null;
        }

        public async Task<IEnumerable<Resource>> ReadResources()
        {
            return await GetAll();
        }

    }
}
