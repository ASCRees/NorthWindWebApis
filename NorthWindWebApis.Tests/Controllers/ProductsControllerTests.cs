using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NorthWindWebApis.Services;
using NUnit.Framework;
using NorthWindWebApis.Controllers;
using NorthWindWebApis.Models;
using AutoMapper;
using NorthWindWebApis.App_Start;
using System.Net;

namespace NorthWindWebApis.Tests.Controllers
{
    public class ProductsControllerTests
    {
        [SetUp]
        public void Setup()
        {
            AutoMapperConfig.CreateMappings();
        }

        [Test]
        public void Get_Product_By_ID()
        {
            // Arrange
            var productID = 1;
            ProductsController productsController = new ProductsController(new BuildModelsService());

            // Act
            ProductViewModel productViewModel = productsController.GetSingleProduct(productID);

            // Assert
            productViewModel.ProductID.Should().Be(productID);

        }

        [Test]
        public void Get_Products_By_Starting_String()
        {
            // Arrange
            var prodString = "M";
            ProductsController productsController = new ProductsController(new BuildModelsService());

            // Act
            ProductsViewModel productViewModel = productsController.GetMultipleProducts(prodString);

            // Assert
            productViewModel.Products.Count.Should().BeGreaterThan(0);

        }

        [Test]
        public void PostProduct_Create_New_Product()
        {
            // Arrange
            ProductViewModel product = new ProductViewModel
            {
                ProductName = "Tomatoe Ketchup",
                UnitPrice = 1.59m,
                UnitsInStock = 200,
                SupplierID = 1,
                CategoryID = 1,
                UnitsOnOrder = 0
            };

            ProductsController productsController = new ProductsController(new BuildModelsService());

            // Act
            var productHttpResponse = productsController.PostProduct(product);
            var productViewModel =(ProductViewModel)((System.Net.Http.ObjectContent)productHttpResponse.Content).Value;

            // Assert
            productViewModel.ProductID.Should().BeGreaterThan(0);

        }

        [Test]
        public void PostProduct_Update_Product()
        {
            // Arrange
            ProductViewModel product = new ProductViewModel
            {
                ProductID=84,
                ProductName = "BBQ Sauce",
                UnitPrice = 1.39m,
                UnitsInStock = 90,
                SupplierID = 1,
                CategoryID = 1,
                UnitsOnOrder = 100,

            };

            ProductsController productsController = new ProductsController(new BuildModelsService());

            // Act
            var productHttpResponse = productsController.PutProduct(product);
       
            var productViewModel = (ProductViewModel)((System.Net.Http.ObjectContent)productHttpResponse.Content).Value;

            // Assert
            productViewModel.UnitsInStock.Should().Be(90);

        }

        [Test]
        public void PostProduct_Update_Product_NotFound()
        {
            // Arrange
            ProductViewModel product = new ProductViewModel
            {
                ProductID = 191919191,
                ProductName = "BBQ Sauce",
                UnitPrice = 1.39m,
                UnitsInStock = 90,
                SupplierID = 1,
                CategoryID = 1,
                UnitsOnOrder = 100,

            };

            ProductsController productsController = new ProductsController(new BuildModelsService());

            // Act
            var productHttpResponse = productsController.PutProduct(product);

            // Assert
            productHttpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }

        [Test]
        public void PostProduct_Update_Product_Model_Not_Valid()
        {
            // Arrange
            ProductViewModel product = new ProductViewModel
            {
                ProductID = 191919191,
                ProductName = string.Empty,
                UnitPrice = 1.39m,
                UnitsInStock = 90,
                SupplierID = 1,
                CategoryID = 1,
                UnitsOnOrder = 100,

            };

            ProductsController productsController = new ProductsController(new BuildModelsService());
            productsController.ModelState.AddModelError("ProductName", "Is required");
            // Act
            var productHttpResponse = productsController.PutProduct(product);

            // Assert
            productHttpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

    }
}
