using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnalaizerClassLibrary.Tests
{
    [TestClass]
    public class AnalaizerClassTests
    {
        public TestContext TestContext { get; set; }
        
        
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml", "ValidTest", DataAccessMethod.Sequential)]
        public void Format_WhenIncomingExpressionIsValid_ReturnsExpression()
        {
            //Arrange
            string expected = Convert.ToString(TestContext.DataRow["expected"]);
            AnalaizerClass.expression = Convert.ToString(TestContext.DataRow["incomingData"]);
            //Actual
            string actualResult = AnalaizerClass.Format();
            //Assert
            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml", "InValidTest", DataAccessMethod.Sequential)]
        public void Format_WhenIncomingExpressionIsInValid_ReturnsError()
        {
            //Arrange
            string expected = Convert.ToString(TestContext.DataRow["expected"]);
            AnalaizerClass.expression = Convert.ToString(TestContext.DataRow["incomingData"]);
            //Actual
            string actualResult = AnalaizerClass.Format();
            //Assert
            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod]
        public void Format_WhenExpressionLenghtIsBiggerThanMaxLenght_ReturnsError()
        {
            //Arrange
            string expected = "&Error 07 — Дуже довгий вираз. Максмальная довжина — 65536 символів.";
            AnalaizerClass.expression = new string('1', 65537);
            //Actual
            string actualResult = AnalaizerClass.Format();
            //Assert
            Assert.AreEqual(expected, actualResult);
        }
    }
}