using Repository.Repository.Implementation;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADBAccess;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        TAAnywhereDbContext db;
        public UnitOfWork()
        {
            db = new TAAnywhereDbContext();
        }

        #region TA Travel Type
        private ITATravelTypeRepository _TATravelTypeRepository;
        public ITATravelTypeRepository TATravelTypeRepo {
            get {
                if (_TATravelTypeRepository == null)
                    _TATravelTypeRepository = new TATravelTypeRepository(db);
                    return _TATravelTypeRepository;
            }
        }
        #endregion

        #region TA purpose
        private ITAPurposeRepository _TAPurposeRepository;
        public ITAPurposeRepository TAPurposeRepo
        {
            get
            {
                if (_TAPurposeRepository == null)
                    _TAPurposeRepository = new TAPurposeRepository(db);
                return _TAPurposeRepository;
            }
        }

        #endregion

        #region TA Employee
        private ITAEmployeeRepository _TAEmployeeRepository;
        public ITAEmployeeRepository TAEmployeeRepo
        {
            get
            {
                if (_TAEmployeeRepository == null)
                    _TAEmployeeRepository = new TAEmployeeRepository(db);
                return _TAEmployeeRepository;
            }
        }
        #endregion

        #region Resources
        private IResourceBuilder _ResourceBuilder;
        public IResourceBuilder ResourceBuilderRepo
        {
            get
            {
                if (_ResourceBuilder == null)
                    _ResourceBuilder = new ResourceBuilder(db);
                return _ResourceBuilder;
            }
        }
        public string Create(ResourceProvider provider, string namespaceName = "Resources", string className = "Resources", string filePath = null, string summaryCulture = null)
        {
            return ResourceBuilderRepo.Create(provider, namespaceName, className, filePath, summaryCulture);
        }
        #endregion

        #region Resource Builder
        private IResourceProvider _ResourceProvider;
        public IResourceProvider ResourceProviderRepo
        {
            get
            {
                if (_ResourceProvider == null)
                    _ResourceProvider = new ResourceProvider(db);
                return _ResourceProvider;
            }
        }

        public ResourceProvider GetResourceProvider
        {
            get
            {
                return new ResourceProvider(db);
            }
        }
        #endregion
        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
