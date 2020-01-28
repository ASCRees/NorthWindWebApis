using System;
using System.Collections.Generic;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSingleProduct/{id}")]
        public ProductViewModel GetSingleProduct(Int32 Id)
        {
            var productServiceModel = _buildModelsService.GetProduct(Id);
            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(productServiceModel);

            return productViewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMultipleProducts/{stringValue}")]
        public ProductsViewModel GetMultipleProducts(string stringValue)
        {
            var productsServiceModel = _buildModelsService.GetListOfProducts(stringValue);
            var products = Mapper.Map<List<ProductViewModel>>(productsServiceModel);
            ProductsViewModel productsViewModel = new ProductsViewModel();
            productsViewModel.Products = products;
            return productsViewModel;
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