using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Repository.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Int64 Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void DeleteById(Int64 Id);
        Task<long> GetCount();
        
    }
}