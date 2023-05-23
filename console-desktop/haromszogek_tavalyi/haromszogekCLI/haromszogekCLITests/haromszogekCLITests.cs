using Microsoft.VisualStudio.TestTools.UnitTesting;
using haromszogekCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI.Tests
{
    [TestClass()]
    public class haromszogekCLITests
    {
        // tesztmetódus
        [TestMethod()]
        public void IsRightAngledTest()
        {            
            Triangle triangle = new Triangle("3 4 5");  // példányosított háromszög
            bool expected = true;  // elvárt érték
            bool actual = haromszogekCLI.IsRightAngled(triangle);  // függvény futtatásakor kapott érték
            Assert.AreEqual(expected, actual);  // ellenőrizzük, hogy az elvárt és a kapott értékek egyenlőek e
        }
    }
}