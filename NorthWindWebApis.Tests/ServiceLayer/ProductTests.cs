using FluentAssertions;
using NorthWindWebApis.Services;
using NUnit.Framework;
using NorthWindWebApis.DataLayer;

namespace NorthWindWebApis.Tests.ServiceLayer
{
    [TestFixture]
    public class ProductTests
    {
        private IBuildModelsService buildModels;

        [SetUp]
        public void Setup()
        {
            buildModels = new BuildModelsService();
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