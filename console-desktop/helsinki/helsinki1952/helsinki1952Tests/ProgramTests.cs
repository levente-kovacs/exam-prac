using Microsoft.VisualStudio.TestTools.UnitTesting;
using helsinki1952;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helsinki1952.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void PlacementToPointsTest1()
        {
            int placement = 1;
            int expected = 7;
            int actual = Program.PlacementToPoints(placement);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlacementToPointsTest2()
        {
            int placement = 4;
            int expected = 3;
            int actual = Program.PlacementToPoints(placement);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlacementToPointsTest3()
        {
            int placement = 7;
            int expected = 0;
            int actual = Program.PlacementToPoints(placement);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlacementToPointsTest4()
        {
            int placement = 0;
            int expected = 0;
            int actual = Program.PlacementToPoints(placement);
            Assert.AreEqual(expected, actual);
        }
    }
}