using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDLL2;

namespace TestProgram
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ispairTets()
        {
            int t1 = 1;
            Assert.AreEqual(t1.is_pair(), false);
            int t2 = 2;
            int t3 = 3;
            Assert.AreEqual(t2.is_pair(), true);
            Assert.AreEqual(t3.is_pair(), false);

        }
    }
}
