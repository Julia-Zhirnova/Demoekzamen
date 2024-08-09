using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Tests
{
    [TestClass()]
    public class utilsTests
    {
        [TestMethod()]
        public void MinAVGTest_DivZero()
        {
            string[] marks = { };
            double expected = -1;
            double actual = utils.MinAVG(marks);
            Assert.AreEqual(expected, actual);
        }
    }
}