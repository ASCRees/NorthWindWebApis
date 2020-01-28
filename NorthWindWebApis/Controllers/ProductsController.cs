using System;
using System.Web.Http;
using AutoMapper;
using NorthWindWebApis.Models;
using NorthWindWebApis.Services;
using StructureMap;

namespace NorthWindWebApis.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private IBuildModelsService _buildModelsService;

        [DefaultConstructor]
        public ProductsController (IBuildModelsService buildModelsService)
        {
            _buildModelsService = buildModelsService;
        }

        // GET /api/<controller>/5

        [HttpGet]
        [Route("{id}")]
        public ProductViewModel Get(Int32 Id)
        {
            var productServiceModel = _buildModelsService.GetProduct(Id);
            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(productServiceModel);

            return productViewModel;
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}