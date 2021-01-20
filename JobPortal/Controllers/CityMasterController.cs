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
    public class CityMasterController : ApiController
    {
        private readonly ICityMasterServices _cityMasterServices;

        public CityMasterController()
        {
            _cityMasterServices = new CityMasterServices();
        }

        public HttpResponseMessage Get()
        {
            var city = _cityMasterServices.GetAllCity();
            if (city == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
            }
            var cityEntities = city as List<CityMasterEntity> ?? city.ToList();
            if (cityEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, cityEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "City not found");
        }

        public HttpResponseMessage Get(int id)
        {
            var city = _cityMasterServices.GetCityById(id);
          
            if (city != null)
                return Request.CreateResponse(HttpStatusCode.OK, city);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No City found for this id");

           
        }

        public int Post([FromBody] CityMasterEntity cityMasterEntity)
        {
            return _cityMasterServices.CreateCity(cityMasterEntity);
        }

        public bool Put(int id, [FromBody] CityMasterEntity cityMasterEntity)
        {
            if (id > 0)
            {
                return _cityMasterServices.UpdateCity(id, cityMasterEntity);
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (id > 0)
                return _cityMasterServices.DeleteCity(id);
            return false;
        }

       

    }
}