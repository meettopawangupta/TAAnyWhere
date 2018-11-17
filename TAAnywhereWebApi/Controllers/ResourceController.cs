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
    public class ResourceController : ApiController
    {
        IUnitOfWork uow;
        public ResourceController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpPost]
        [Route("api/CreateResource/")]
        public string CreateResource()
        {
            return  uow.ResourceBuilderRepo.Create(uow.GetResourceProvider, summaryCulture: "en-us" );
        }
    }
}
