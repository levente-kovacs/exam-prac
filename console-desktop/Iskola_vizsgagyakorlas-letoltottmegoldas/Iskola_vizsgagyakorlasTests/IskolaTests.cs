using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iskola_vizsgagyakorlas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola_vizsgagyakorlas.Tests
{
    [TestClass()]
    public class IskolaTests
    {
        [TestMethod()]
        public void idGeneratorTest1()
        {
            Student student = new Student(2006, 'c', "Bodnar Szilvia");
            string expected = "6cbodszi";
            string result = Iskola.idGenerator(student);
            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void idGeneratorTest2()
        {
            Student student = new Student(2006, 'c', "Krizsan Vivien Evelin");
            string expected = "6ckriviv";
            string result = Iskola.idGenerator(student);
            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void idGeneratorTest3()
        {
            Student student = new Student(2006, 'c', "Krizsan Vivien Evelin");
            string expected = "66krivim";
            string result = Iskola.idGenerator(student);
            Assert.AreNotEqual(result, expected);
        }
    }
}