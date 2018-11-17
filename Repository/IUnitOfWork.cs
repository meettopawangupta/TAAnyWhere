using Repository.Repository.Implementation;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public interface IUnitOfWork
    {
        ITATravelTypeRepository TATravelTypeRepo { get;}
        ITAPurposeRepository TAPurposeRepo { get;}
        ITAEmployeeRepository TAEmployeeRepo { get; }
        IResourceBuilder ResourceBuilderRepo { get; }
        IResourceProvider ResourceProviderRepo { get; }
        ResourceProvider GetResourceProvider { get; }
        Task<int> SaveChangesAsync();
    }
}
