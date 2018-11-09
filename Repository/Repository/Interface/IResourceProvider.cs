using DomainModels.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IResourceProvider: IRepository<Resource>
    {
        object GetResource(string name, string culture);
        Task<IEnumerable<Resource>> ReadResources();
        Task<Resource> ReadResource(string name, string culture);
    }
}
