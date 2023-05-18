using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iskola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola.Tests
{
    [TestClass()]
    public class IskolaTests
    {
        // test 1
        [TestMethod()]
        public void GenerateCodeTest1()
        {
            string expected1 = "6cbodszi";
            Student BodnarSzilvia = new Student("2006;c;Bodnar Szilvia");
            string actual1 = Iskola.GenerateCode(BodnarSzilvia);
            Assert.AreEqual(expected1, actual1);
        }

        // test 2
        [TestMethod()]
        public void GenerateCodeTest2()
        {
            string expected2 = "6ckriviv";
            Student KrizsanVivienEvelin = new Student("2006;c;Krizsan Vivien Evelin");
            string actual2 = Iskola.GenerateCode(KrizsanVivienEvelin);
            Assert.AreEqual(expected2, actual2);
        }

        // test 3
        [TestMethod()]
        public void GenerateCodeTest3()
        {
            string expected3 = "6ckriviv";
            Student BodnarSzilvia = new Student("2006;c;Bodnar Szilvia");
            string actual3 = Iskola.GenerateCode(BodnarSzilvia);
            Assert.AreNotEqual(expected3, actual3);
        }

        // test 4
        [TestMethod()]
        public void GenerateCodeTest4()
        {
            string expected4 = "6cbodszi";
            Student KrizsanVivienEvelin = new Student("2006;c;Krizsan Vivien Evelin");
            string actual4 = Iskola.GenerateCode(KrizsanVivienEvelin);
            Assert.AreNotEqual(expected4, actual4);
        }
    }
}
