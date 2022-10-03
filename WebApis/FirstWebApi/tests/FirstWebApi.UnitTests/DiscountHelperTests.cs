using FirstWebApi.Helpers;
using NUnit.Framework;

namespace FirstWebApi.UnitTests
{
    public class DiscountHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateDiscount_ValidPrice_ReturnsCorrectDiscount()
        {
            ///aaa
            //Arrange 

            // This is where hard work lays

            //Act
            var result = CalculationHelpers.CalculateDiscount(15);

            //Assert
            Assert.AreEqual(0.10M, result);
        }

        [Test]
        public void CalculateDiscount_ValidPrice_ReturnsLowerDiscount()
        {
            ///aaa
            //Arrange 

            // This is where hard work lays

            //Act
            var result = CalculationHelpers.CalculateDiscount(5);

            //Assert
            Assert.AreEqual(0.05M, result);
        }

        [TestCase(5, 0.05)]
        [TestCase(15, 0.10)]
        public void CalculateDiscount_GivenTestCases_WeLearnAboutTestCase(int price, decimal discount)
        {
            var result = CalculationHelpers.CalculateDiscount(price);

            //Assert
            Assert.AreEqual(discount, result);
        }
    }

}