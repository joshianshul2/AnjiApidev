using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;

namespace WebApiIms.Controllers
{
   
    public class HospitalMasterController : ApiController
    {
        private readonly IHospitalMasterServices _hspMasterServices;

        public HospitalMasterController()
        {
            _hspMasterServices = new HospitalMasterServices();
        }

        public HttpResponseMessage Get()
        {
            var hsp = _hspMasterServices.GetAllUser();
            if (hsp == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hsp not found");
            }
            var hspEntities = hsp as List<HospitalMasterEntity> ?? hsp.ToList();
            if (hspEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, hspEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hsp not found");
        }

        public HttpResponseMessage Get(int id)
        {
            var hsp = _hspMasterServices.GetUserById(id);
          
            if (hsp != null)
                return Request.CreateResponse(HttpStatusCode.OK, hsp);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hsp found for this id");

           
        }

        public HttpResponseMessage GetUserByNamePaasword(string UserName, string Password)
        {
            var hsp = _hspMasterServices.GetUserByNamePaasword(UserName, Password);


            if (hsp != null)
                return Request.CreateResponse(HttpStatusCode.OK, hsp);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hsp found for this id");
        }

        public int Post([FromBody] HospitalMasterEntity hspMasterEntity)
        {
            return _hspMasterServices.CreateUser(hspMasterEntity);
        }

        public bool Put(int id, [FromBody] HospitalMasterEntity hspMasterEntity)
        {
            if (id > 0)
            {
                return _hspMasterServices.UpdateUser(id, hspMasterEntity);
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (id > 0)
                return _hspMasterServices.DeleteUser(id);
            return false;
        }

       

    }
}