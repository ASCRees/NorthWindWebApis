using FluentAssertions;
using NorthWindWebApis.Services;
using NUnit.Framework;

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
    }
}