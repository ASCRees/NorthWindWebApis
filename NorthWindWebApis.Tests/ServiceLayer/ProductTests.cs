using FluentAssertions;
using NorthWindWebApis.Services;
using NUnit.Framework;
using NorthWindWebApis.DataLayer;
using System;
using NorthWindWebApis.Tests.Base;

namespace NorthWindWebApis.Tests.ServiceLayer
{
    [TestFixture]
    public class ProductTests : BaseTests
    {
        private IBuildModelsService buildModels;

        [SetUp]
        public override void Setup()
        {
            buildModels = new BuildModelsService();
            base.Setup();
        }

        [Test]
        public void Select_A_Single_ProductID()
        {
            //Arrange
            var id = 1;

            //Act
            var product = buildModels.GetProduct(id);

            //Assert
            product.ProductID.Should().Be(id);
        }

        [Test]
        public void Select_A_Single_InvalidProductID()
        {
            //Arrange
            var id = -1;

            //Act
            var product = buildModels.GetProduct(id);

            //Assert
            product.Should().BeNull(because : "Product is found");
        }

        [Test]
        public void Select_Multiple_Products()
        {
            //Arrange
            var startsWith = "M";

            //Act
            var product = buildModels.GetListOfProducts(startsWith);

            //Assert
            product.Count.Should().Be(5);
        }

        [Test]
        public void Update_Product_Name()
        {
            //Arrange
            var product = buildModels.GetProduct(1);

            //Act
            product.ProductName = product.ProductName + "...";

            //Assert
            buildModels.Context.SaveChanges().Should().Be(1);
        }

        [Test]
        public void Update_Product()
        {
            //Arrange
            var product = buildModels.GetProduct(1);
            //Act
            product.ProductName= product.ProductName + "...";
            //Assert
            buildModels.UpdateProduct().Should().Be(1);
        }

        [Test]
        public void Delete_Product()
        {
            //Arrange
            var productName = "Deleted Sause";
            var productID = 0;
            // We will create the product first then check its there then delete it.
            var product = new Product
            {
                ProductName = productName,
                UnitPrice = 2,
                SupplierID = 1,
                CategoryID = 1,
                UnitsInStock = 100
            };

            //Act
            var productCreated = buildModels.CreateNewProduct(product);
            productID = productCreated.ProductID;

            //Assert
            buildModels.DeleteProduct(productID).Should().Be(1);
        }

        [Test]
        public void Create_Product()
        {
            //Arrange
            var product = new Product
            {
                ProductName = "Brown Sauce",
                UnitPrice = 1,
                SupplierID = 1,
                CategoryID = 1,
                UnitsInStock = 100
            };

            //Act
            var productCreated = buildModels.CreateNewProduct(product);
            //Assert
            productCreated.ProductID.Should().BeGreaterThan(0);
        }
    }
}