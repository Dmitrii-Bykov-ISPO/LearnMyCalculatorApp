using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnMyCalculatorApp1;
using FluentAssertions;
using Moq;

namespace LearnMyCalculatorApp.Tests
{
    public interface ICalculator
    {
        int Add(int x, int y);
        int Subtract(int x, int y);
        int Multiply(int x, int y);
        int? Divide(int x, int y);

    }
    [TestClass]
    public class CalculatorTest
    {

        [TestMethod]
        public void CalculatorNullTest()
        {
            var calculator = new Calculator();
            Assert.IsNotNull(calculator);
        }
        [TestMethod]
        public void AddTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(1, 1);

            // Assert
            Assert.AreEqual(2, actual);
        }

        public int? Divide(int x, int y)
        {
            try
            {
                return x / y;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
                return null;
            }
        }
        [TestMethod]
        public void SubtractTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Subtract(1, 1);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Multiply(1, 1);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void DivideTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Divide(1, 1);

            // Assert
            Assert.AreEqual(1, actual);
        }
        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(2, 2, 4)]
        [DataRow(3, 3, 6)]
        [DataRow(1, 0, 1)] // The test run with this row fails
        public void AddDataTests(int x, int y, int expected)
        {
            var calculator = new Calculator();
            var actual = calculator.Add(x, y);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DivideByZeroTest()
        {

            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Divide(1, 0);

            // Assert
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void AddTestFluentassertion()
        {
            var calculator = new Calculator();
            var actual = calculator.Add(1, 1);

            // Non-fluent asserts:
            // Assert.AreEqual(actual, 2);
            // Assert.AreNotEqual(actual, 1);

            // Same asserts as what is commented out above, but using Fluent Assertions
            actual.Should().Be(2).And.NotBe(1);
        }

        [TestMethod]
        public void DivideByZeroByMOQ()
        {
            var mock = new Mock<ICalculator>();
            mock.Setup(calc => calc.Divide(1, 0)).Returns(1);
            var actual = mock.Object.Divide(1, 0);
            Assert.AreEqual(1, actual);
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(2, 2, 4)]
        [DataRow(3, 3, 6)]
        [DataRow(1, 0, 1)] // The test run with this row fails

        public void DivideByZeroMoq(int x, int y, int expected)
        {
            var calculator = new Mock<ICalculator>();
            calculator.Setup(calc => calc.Divide(x, y)).Returns(expected);
            var actual = calculator.Object.Divide(x, y);
            Assert.AreEqual(expected, actual);
        }
    }
}
