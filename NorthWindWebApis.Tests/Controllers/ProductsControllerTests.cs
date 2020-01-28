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
          //  AutoMapperConfig.CreateMappings();
        }

        [Test]
        public void Get_Product_By_ID()
        {
            //var productID = 1;
            //// Arrange
            //ProductsController productsController = new ProductsController(new BuildModelsService());

            //// Act
            //ProductViewModel productViewModel = productsController.Get(productID);

            //// Assert
            //productViewModel.ProductID.Should().Be(productID);
           
        }
    }
}
