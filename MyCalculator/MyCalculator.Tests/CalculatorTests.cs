using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AddSimple()
        {
            Calculator calculator = new Calculator();
            int sum = calculator.Add(1, 2);
            Assert.AreEqual(3, sum);
        }
    }
}
