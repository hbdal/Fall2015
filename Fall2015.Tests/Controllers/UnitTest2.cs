using System;
using Fall2015.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fall2015.Tests.Controllers
{
    [TestClass]
    public class UnitTest2
    {
        OurTimeSpan our1 = new OurTimeSpan
        {
            FromTime = new DateTime(2015, 1, 1, 12, 0, 0),
            ToTime = new DateTime(2015, 1, 1, 13, 30, 0)
        };

        [TestMethod]
        public void Test_Overlap1()
        {
            OurTimeSpan our2 = new OurTimeSpan
            {
                FromTime = new DateTime(2015, 1, 1, 10, 0, 0),
                ToTime = new DateTime(2015, 1, 1, 11, 0, 0)
            };
            Boolean result = our1.Overlap(our2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Overlap2()
        {
            OurTimeSpan our2 = new OurTimeSpan
            {
                FromTime = new DateTime(2015, 1, 1, 11, 0, 0),
                ToTime = new DateTime(2015, 1, 1, 12, 0, 0)
            };
            Boolean result = our1.Overlap(our2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Overlap3()
        {
            OurTimeSpan our2 = new OurTimeSpan
            {
                FromTime = new DateTime(2015, 1, 1, 11, 30, 0),
                ToTime = new DateTime(2015, 1, 1, 12, 30, 0)
            };
            Boolean result = our1.Overlap(our2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Overlap4()
        {
            OurTimeSpan our2 = new OurTimeSpan
            {
                FromTime = new DateTime(2015, 1, 1, 13, 30, 0),
                ToTime = new DateTime(2015, 1, 1, 14, 0, 0)
            };
            Boolean result = our1.Overlap(our2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Overlap5()
        {
            OurTimeSpan our2 = new OurTimeSpan
            {
                FromTime = new DateTime(2015, 1, 1, 13, 0, 0),
                ToTime = new DateTime(2015, 1, 1, 15, 0, 0)
            };
            Boolean result = our1.Overlap(our2);
            Assert.IsFalse(result);
        }
    }
}
