using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repository.Interface;
using Repository.Repository.Implementation;

namespace Resources {
        public class Resources {
            private static IResourceProvider resourceProvider = new ResourceProvider();

                
        /// <summary>Sign in</summary>
        public static string lblSignIn {
               get {
                   return (string) resourceProvider.GetResource("lblSignIn", CultureInfo.CurrentUICulture.Name);
               }
            }

        }        
}
