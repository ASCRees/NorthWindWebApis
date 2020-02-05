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
        public ProductsController(IBuildModelsService buildModelsService)
        {
            _buildModelsService = buildModelsService;
        }

        // GET /api/<controller>/5

        /// <summary>
        /// Returns a Single product
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
        /// Returns multiple products 
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
            prodContext = _buildModelsService.CreateNewProduct(prodContext);
            var returnProduct = Mapper.Map<ProductViewModel>(prodContext);

            return ReturnResponse(returnProduct, new JsonMediaTypeFormatter(), "application/json", HttpStatusCode.Created, string.Empty);
        }


        // PUT api/<controller>/5
        [HttpPut]
        [Route("PutProduct")]
        public HttpResponseMessage PutProduct(ProductViewModel productModel)
        {
            if (!ModelState.IsValid)
                return ReturnResponse(new Object(), null, string.Empty, HttpStatusCode.BadRequest, "Not a valid model" ); 

            var prodContext = new DataLayer.Product();

            if (productModel.ProductID > 0)
            {
                prodContext = _buildModelsService.GetProduct(productModel.ProductID);

                if (prodContext != null)
                {

                    prodContext.ProductName = productModel.ProductName;
                    prodContext.CategoryID = productModel.CategoryID;
                    prodContext.Discontinued = productModel.Discontinued;
                    prodContext.QuantityPerUnit = productModel.QuantityPerUnit;
                    prodContext.ReorderLevel = productModel.ReorderLevel;
                    prodContext.SupplierID = productModel.SupplierID;
                    prodContext.UnitPrice = productModel.UnitPrice;
                    prodContext.UnitsInStock = productModel.UnitsInStock;
                    prodContext.UnitsOnOrder = productModel.UnitsOnOrder;

                    _buildModelsService.UpdateProduct();
                    productModel = Mapper.Map<ProductViewModel>(prodContext);
                    return ReturnResponse(productModel, new JsonMediaTypeFormatter(), "application/json", HttpStatusCode.OK, string.Empty);
                }
                else
                {
                    return ReturnResponse(new Object(), null, string.Empty, HttpStatusCode.NotFound, "Unable to find the product");
                }
            }

            return PostProduct(productModel);

        }

        [HttpPatch]
        [Route("PatchProduct")]
        public HttpResponseMessage PatchProduct(ProductPatchViewModel productModel)
        {
            if (!ModelState.IsValid)
                return ReturnResponse(new Object(), null, string.Empty, HttpStatusCode.BadRequest, "Not a valid model");

            var prodContext = new DataLayer.Product();

            if (productModel.ProductID > 0)
            {
                prodContext = _buildModelsService.GetProduct(productModel.ProductID);

                if (prodContext != null)
                {

                    prodContext.ProductName = productModel.ProductName;
                    prodContext.ReorderLevel = productModel.ReorderLevel;
                    prodContext.UnitPrice = productModel.UnitPrice;
                    prodContext.UnitsInStock = productModel.UnitsInStock;
                    prodContext.UnitsOnOrder = productModel.UnitsOnOrder;

                    _buildModelsService.UpdateProduct();
                    productModel = Mapper.Map<ProductPatchViewModel>(prodContext);
                    return ReturnResponse(productModel, new JsonMediaTypeFormatter(), "application/json", HttpStatusCode.OK, string.Empty);
                }
            }
            return ReturnResponse(productModel, new JsonMediaTypeFormatter(), "application/json", HttpStatusCode.NotFound, "Unable to find the product");
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private HttpResponseMessage ReturnResponse<T>(T returnObject, MediaTypeFormatter formatter, string formatString, HttpStatusCode statusCode, string returnPhrase)
        {
            //var content = 

            var response = new HttpResponseMessage(statusCode)
            {

                Content = returnObject.GetType() == new Object().GetType() ? null : new ObjectContent<T>(returnObject, formatter, formatString),
                ReasonPhrase = returnPhrase
            };

            return response;
        }


    }
}