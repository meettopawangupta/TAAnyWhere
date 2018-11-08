using DomainModels.Entites;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TAAnywhereWebApi.Controllers
{
    public class TAEmployeeController : ApiController
    {
        IUnitOfWork uow;
        public TAEmployeeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpGet]
        [Route("api/GetAllTAEmployee/")]
        public async Task<IEnumerable<TAEmployee>> GetAllEmployee()
        {
            return await uow.TAEmployeeRepo.GetAll();
        }

        [HttpGet]
        [Route("api/GetEmployeeById/")]
        public async Task<TAEmployee> GetEmployeeById(long EmployeeId)
        {
            return await uow.TAEmployeeRepo.GetById(EmployeeId);
        }

        [HttpPost]
        [Route("api/AddEmployee/")]
        public void AddEmployee(TAEmployee Emp)
        {
           if(ModelState.IsValid)
            {
                uow.TAEmployeeRepo.Add(Emp);
            }
        }

      

    }
}
