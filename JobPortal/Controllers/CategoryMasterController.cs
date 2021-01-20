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
    public class CategoryMasterController : ApiController
    {
        private readonly ICategoryMasterServices _categoryMasterServices;

        public CategoryMasterController()
        {
            _categoryMasterServices = new CategoryMasterServices();
        }

        public HttpResponseMessage Get()
        {
            var category = _categoryMasterServices.GetAllCategory();
            if (category == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Anshul not found");
            }
            var categoryEntities = category as List<CategoryMasterEntity> ?? category.ToList();
            if (categoryEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, categoryEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Anshul not found");
        }

        public HttpResponseMessage Get(int id)
        {
            var city = _categoryMasterServices.GetCategoryById(id);
          
            if (city != null)
                return Request.CreateResponse(HttpStatusCode.OK, city);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Anshul found for this id");

           
        }

        public int Post([FromBody] CategoryMasterEntity categoryMasterEntity)
        {
            return _categoryMasterServices.CreateCategory(categoryMasterEntity);
        }

        public bool Put(int id, [FromBody] CategoryMasterEntity categoryMasterEntity)
        {
            if (id > 0)
            {
                return _categoryMasterServices.UpdateCategory(id, categoryMasterEntity);
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (id > 0)
                return _categoryMasterServices.DeleteCategory(id);
            return false;
        }

       

    }
}