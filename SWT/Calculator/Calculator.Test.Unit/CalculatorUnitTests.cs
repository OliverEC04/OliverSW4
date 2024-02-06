using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Test.Unit
{
    internal class CalculatorUnitTests
    {
        private Calculator uut;

        [SetUp]
        public void Setup()
        {
            uut = new Calculator();
        }

        // Basic tests:

        [Test]
        public void Add_PositiveNumbers_SumIsCorrect()
        {
            Assert.That(uut.Add(10, 20), Is.EqualTo(30));
        }

        [Test]
        public void Subtract_PositiveNumbers_SumIsCorrect()
        {
            Assert.That(uut.Subtract(39, 11), Is.EqualTo(28));
        }

        [Test]
        public void Multiply_PositiveNumbers_SumIsCorrect()
        {
            Assert.That(uut.Multiply(3, 4), Is.EqualTo(12));
        }

        [Test]
        public void Power_PositiveNumbers_SumIsCorrect()
        {
            Assert.That(uut.Power(8, 3), Is.EqualTo(512));
        }

        // TestCase:

        [TestCase(1, 1, 2)]
        [TestCase(22, 8, 30)]
        [TestCase(3.9, 1.4, 5.3)]
        public void Add_SumIsCorrect(double a, double b, double result)
        {
            Assert.That(uut.Add(a, b), Is.EqualTo(result));
        }
        
        [TestCase(-4, 2, -8)]
        public void Multiply_NegativeNumbers_SumIsCorrect(double a, double b, double result)
        {
            Assert.That(uut.Multiply(a, b), Is.EqualTo(result));
        }
    }
}
