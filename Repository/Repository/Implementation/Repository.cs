using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Repository.Repository.Interface;

namespace Repository.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext db;
        public Repository(DbContext _db)
        {
            db = _db;
        }
        public async void Add(TEntity entity)
        {
            await Task.Run(()=> db.Set<TEntity>().Add(entity));
        }

        public async void DeleteById(long Id)
        {
            await Task.Run(() =>
            {
                TEntity entity = db.Set<TEntity>().Find(Id);
                if (entity != null)
                    db.Set<TEntity>().Remove(entity);
            });
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(long Id)
        {
            return await db.Set<TEntity>().FindAsync(Id);
        }

        public async Task<long> GetCount()
        {
            return await Task.Run(()=> db.Set<TEntity>().Count<TEntity>());
        }

        public async void Update(TEntity entity)
        {
           await Task.Run (()=> db.Entry<TEntity>(entity).State = EntityState.Modified);
        }
    }
}