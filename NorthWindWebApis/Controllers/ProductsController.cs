using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
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
        [HttpPost]
        [Route("PostProduct")]
        public HttpResponseMessage PostProduct(ProductViewModel productModel)
        {

            var prodContext = Mapper.Map<DataLayer.Product>(productModel);
            prodContext= _buildModelsService.CreateNewProduct(prodContext);
            var returnProduct = Mapper.Map<ProductViewModel>(prodContext);
            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new ObjectContent<ProductViewModel>(returnProduct, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }

        // PUT api/<controller>/5

        //public HttpResponseMessage Put(ProductViewModel productModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid model");

        //    var prodContext = new DataLayer.Product();

        //    if (productModel.ProductID > 0)
        //    {
        //        prodContext = _buildModelsService.GetProduct(productModel.ProductID);

        //        if (prodContext != null)
        //        {

        //            prodContext.ProductName = productModel.ProductName;
        //            prodContext.CategoryID = productModel.CategoryID;
        //            prodContext.Discontinued = productModel.Discontinued;
        //            prodContext.QuantityPerUnit = productModel.QuantityPerUnit;
        //            prodContext.ReorderLevel = productModel.ReorderLevel;
        //            prodContext.SupplierID = productModel.SupplierID;
        //            prodContext.UnitPrice = productModel.UnitPrice;
        //            prodContext.UnitsInStock = productModel.UnitsInStock;
        //            prodContext.UnitsOnOrder = productModel.UnitsOnOrder;

        //            prodContext = _buildModelsService.UpdateProduct(prodContext);
        //            productModel = Mapper.Map<ProductViewModel>(prodContext);
        //            return Ok();
        //        }
        //        else
        //            return NotFound();

        //    }


        //    using (var ctx = new SchoolDBEntities())
        //    {
        //        var existingStudent = ctx.Students.Where(s => s.StudentID == student.Id)
        //                                                .FirstOrDefault<Student>();

        //        if (existingStudent != null)
        //        {
        //            existingStudent.FirstName = student.FirstName;
        //            existingStudent.LastName = student.LastName;

        //            ctx.SaveChanges();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }

        //    return Ok();
        //}

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}