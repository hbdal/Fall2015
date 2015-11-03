using System;
using Fall2015.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fall2015.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Input500_ShouldReturn0()
        {
            //Arrange - set up objects, variables etc.

            //Act - run method
            double result = DiscountRules.CalculateDiscount(500.0);

            //Assert - see if test fails/passes
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_Input1000_ShouldReturn10()
        {
            double result = DiscountRules.CalculateDiscount(1000);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Test_Input13_ShouldReturn0()
        {
            double result = DiscountRules.CalculateDiscount(13);
            Assert.AreEqual(0, result);
        }

        /*
        [TestMethod]
        public void Test_InputNeg10_ShouldReturnThrowException()
        {
            double result = DiscountRules.CalculateDiscount(-10);
            Assert.AreEqual(0, result);
        }
        */
        [TestMethod]
        public void Test_Input0_ShouldReturn0()
        {
            double result = DiscountRules.CalculateDiscount(0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_Input5000_ShouldReturn15()
        {
            double result = DiscountRules.CalculateDiscount(5000);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Test_Input1million_ShouldReturn20()
        {
            double result = DiscountRules.CalculateDiscount(1000000);
            Assert.AreEqual(20, result);
        }
    }
}
