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

        [Test]
        public void Add_PositiveNumbers_SumIsCorrect()
        {
            Assert.That(uut.Add(10, 20), Is.EqualTo(30));
        }
    }
}
