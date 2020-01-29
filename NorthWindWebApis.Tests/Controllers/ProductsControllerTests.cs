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
    }
}
