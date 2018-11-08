using DomainModels.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Repository.Repository.Interface;

namespace Repository.Repository.Implementation
{
    public class TATravelTypeRepository : Repository<TATravelType>, ITATravelTypeRepository
    {
        public TATravelTypeRepository(DbContext _db):base(_db)
        {

        }
    }
}