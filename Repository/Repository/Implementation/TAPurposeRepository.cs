using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repository.Implementation;
using DomainModels.Entites;

namespace Repository.Repository.Implementation
{
    public class TAPurposeRepository : Repository<TAPurpose>,ITAPurposeRepository
    {
        public TAPurposeRepository(DbContext _db):base(_db)
        {

        }
    }
}
