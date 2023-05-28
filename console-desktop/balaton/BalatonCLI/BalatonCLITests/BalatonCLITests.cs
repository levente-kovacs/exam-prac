using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalatonCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI.Tests
{
    [TestClass()]
    public class BalatonCLITests
    {
        [TestMethod()]
        public void AdoTestC()
        {
            Building building = new Building("38522 Aradi 1 C 180");
            int expected = 18000;
            int actual = BalatonCLI.Ado(building.Type, building.Area);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AdoTestB()
        {
            Building building = new Building("84103 Besztercei 12 B 56");
            int expected = 33600;
            int actual = BalatonCLI.Ado(building.Type, building.Area);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AdoTestA()
        {
            Building building = new Building("97723 Besztercei 11 A 188");
            int expected = 150400;
            int actual = BalatonCLI.Ado(building.Type, building.Area);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AdoTest0()
        {
            Building building = new Building("42220 Aradi 20A C 90");
            int expected = 0;
            int actual = BalatonCLI.Ado(building.Type, building.Area);
            Assert.AreEqual(expected, actual);
        }
    }
}