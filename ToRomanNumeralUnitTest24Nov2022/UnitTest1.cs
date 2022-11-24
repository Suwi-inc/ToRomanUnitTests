using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToRomanNumeral;

namespace ToRomanNumeralUnitTest24Nov2022
{
    [TestClass]
    public class UnitTest1
    {
        private Roman roman;

        [TestInitialize]
        public void Initialize()
        {
          roman = new Roman();
        }

        [TestMethod]
        public void IsCorrectFor5isV()
        {
            //test for 5
            string expectedValue = "V";
            string actualValue = roman.CalculateRomanValue(5);

            Assert.AreEqual(expectedValue, actualValue);
            

        }

        [TestMethod]
        public void IsCorrectFor9isX()
        {
            //test for 9
            string expectedValue = "IX";
            string actualValue = roman.CalculateRomanValue(9);

            Assert.AreEqual(expectedValue, actualValue);
        }


        [TestMethod]
        public void IsCorrectFor188isC()
        {
            //test for 188
            string expectedValue = "CLXXXVIII";
            string actualValue = roman.CalculateRomanValue(188);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsExceptionForLessThan1()
        {
            roman.CalculateRomanValue(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsExceptionForMoreThan3999()
        {
            roman.CalculateRomanValue(4000);
        }

       

        [TestMethod]
        public void IsTrue()
        {
            Assert.IsTrue(string.Equals(roman.CalculateRomanValue(3000), "MMM"));
        }

        [TestMethod]
        public void IsFalse()
        {
            Assert.IsFalse(string.Equals(roman.CalculateRomanValue(19), "IX"));
        }






    }
}
