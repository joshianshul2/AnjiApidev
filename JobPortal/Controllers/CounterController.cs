using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;


namespace JobPortal.Controllers
{
    public class CounterController : ApiController
    {
        private readonly ICounterServices _CounterServices;
        public CounterController()
        {
          //  _CounterServices = new CounterServices(); 
        }

        //public HttpResponseMessage Get()
        //{
        //    var client = _clientJobSeekerServices.GetAllClientJobSeeker();
        //    if (client == null)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Client JobSeeker not found");
        //    }
        //    var clientEntities = client as List<CounterEntity> ?? client.ToList();
        //    if (clientEntities.Any())
        //        return Request.CreateResponse(HttpStatusCode.OK, clientEntities);
        //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Client JobSeeker not found");
        //}

        //public HttpResponseMessage Get(int id)
        //{
        //    var client = _clientJobSeekerServices.GetClientJobSeekerById(id);
        //    if (client != null)
        //        return Request.CreateResponse(HttpStatusCode.OK, client);
        //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Client JobSeeker found for this id");
        //}

        //public decimal Post([FromBody] CounterEntity clientJobSeekerEntity)
        //{
        //    return _clientJobSeekerServices.CreateClientJobSeeker(clientJobSeekerEntity);
        //}

        //public bool Put(int id, [FromBody] CounterEntity clientJobSeekerEntity)
        //{
        //    if (id > 0)
        //    {
        //        return _clientJobSeekerServices.UpdateClientJobSeeker(id, clientJobSeekerEntity);
        //    }
        //    return false;
        //}
        //public bool Delete(int id)
        //{
        //    if (id > 0)
        //        return _clientJobSeekerServices.DeleteClientJobSeeker(id);
        //    return false;
        //}
    }
}
