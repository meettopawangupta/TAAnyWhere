using DomainModels.Entites;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
   public class TAEmployeeRepository : Repository<TAEmployee>,ITAEmployeeRepository
    {
        public TAEmployeeRepository(DbContext _db):base(_db)
        {

        }
    }
}
