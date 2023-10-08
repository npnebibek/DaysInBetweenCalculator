using DaysInBetweenCalculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DaysInBetweenCalculator.Tests
{

    public class DaysInBetweenCalculatorTests
    {
        private readonly IDaysInBetweenCalculator _calculator;
        public DaysInBetweenCalculatorTests(IDaysInBetweenCalculator calculator)
        {
            _calculator = calculator;
        }

        [Fact]
        public void TestSameFirstAndSecondDate()
        {
            _calculator
        }
    }
}
