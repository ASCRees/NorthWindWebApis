using NUnit.Framework;
using NorthWindWebApis.Service;
using FluentAssertions;

namespace NorthWindWebApis.Tests.ServiceLayer
{

    [TestFixture]
    public class ProductTests
    {
        IBuildModels buildModels;

        [SetUp]
        public void Setup()
        {
            buildModels = new BuildModels();
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
    }
}
