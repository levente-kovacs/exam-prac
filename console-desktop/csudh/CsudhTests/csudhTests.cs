using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csudh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csudh.Tests
{
    [TestClass()]
    public class csudhTests
    {
        [TestMethod()]
        public void DomainTest1()
        {
            IpAddress ipAddress = new IpAddress("dhvx20.csudh.edu;155.135.1.1");            
            string expected = "edu";
            string actual = csudh.Domain(1, ipAddress);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void DomainTest2()
        {
            IpAddress ipAddress = new IpAddress("dhvx20.csudh.edu;155.135.1.1");            
            string expected = "csudh";
            string actual = csudh.Domain(1, ipAddress);
            Assert.AreNotEqual(expected, actual);
        }
    }
}