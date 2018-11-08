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
    public class TATravelTypeController : ApiController
    {
        IUnitOfWork uow;
        public TATravelTypeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpPost]
        [Route("api/GetAllTATravelType/")]
        public async Task<IEnumerable<TATravelType>> GetAllTATravelType()
        {
            return await uow.TATravelTypeRepo.GetAll();
        }
        [HttpGet]
        [Route("api/GetTATravelTypeCount/")]
        public async Task<long> GetTATravelTypeCount()
        {
            return await uow.TATravelTypeRepo.GetCount();
        }
        [HttpPost]
        [Route("api/CreateTATravelType/")]
        public async void CreateTATravelType(TATravelType _TATravelType)
        {
            if (ModelState.IsValid) 
            {
                uow.TATravelTypeRepo.Add(_TATravelType);
                await uow.SaveChangesAsync();
            }
        }
        [HttpPost]
        [Route("api/UpdateTATravelType/")]
        public async void UpdateTATravelType(TATravelType _ModifiedTATravelType)
        {
            if(ModelState.IsValid)
            {
                uow.TATravelTypeRepo.Update(_ModifiedTATravelType);
                await uow.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("api/Delete/")]
        public async void Delete(long TATypeId)
        {
            uow.TATravelTypeRepo.DeleteById(TATypeId);
            await uow.SaveChangesAsync();
        }
    }
}
