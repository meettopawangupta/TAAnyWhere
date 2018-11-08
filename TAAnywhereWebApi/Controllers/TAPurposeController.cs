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
    public class TAPurposeController : ApiController
    {
        IUnitOfWork uow;
        public TAPurposeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpGet]
        [Route("api/GetAllTAPurpose/")]
        public async Task<IEnumerable<TAPurpose>> GetAllTAPurpose()
        {
            return await uow.TAPurposeRepo.GetAll();
        }
    }
}
