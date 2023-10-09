using DaysInBetweenCalculator.Interface;

using Xunit;
using FluentAssertions;
using DaysInBetweenCalculator.Helpers;
using Microsoft.Extensions.DependencyInjection;
using DaysInBetweenCaculator.Helpers;

namespace DaysInBetweenCalculator.Tests
{

    public class DaysInBetweenCalculatorTests
    {
        private readonly IDaysInBetweenCalculator _calculator;
        public DaysInBetweenCalculatorTests()
        {
            var serviceProvider = Startup.ConfigureServices();
            _calculator = serviceProvider.GetRequiredService<IDaysInBetweenCalculator>();
        }

        [Fact]
        public void Given_SameFirstAndSecondDate_ShouldReturnZero()
        {
            var firstDate = new DateTime(2023, 10, 10);
            var secondDate = new DateTime(2023, 10, 10);

            var daysInbetween = _calculator.WeekdaysBetweenTwoDates(firstDate, secondDate);

            daysInbetween.Should().Be(0);
        }

        [Fact]
        public void Given_NoDaysInBetweenFirstAndSecondDate_ShouldReturnZero()
        {
            var firstDate = new DateTime(2023, 10, 10);
            var secondDate = new DateTime(2023, 10, 11);

            var daysInbetween = _calculator.WeekdaysBetweenTwoDates(firstDate, secondDate);

            daysInbetween.Should().Be(0);
        }

        [Fact]
        public void Given_SmallSecondDateThanFirstDate_ShouldReturnZero()
        {
            var firstDate = new DateTime(2023, 10, 10);
            var secondDate = new DateTime(2023, 10, 5);

            var daysInbetween = _calculator.WeekdaysBetweenTwoDates(firstDate, secondDate);

            daysInbetween.Should().Be(0);
        }

        [Fact]
        public void Given_ValidFirstAndSecondDate_ShoudReturnNumberOfWeekdays()
        {
            var firstDate = new DateTime(2023, 10, 10);
            var secondDate = new DateTime(2023, 10, 20);

            var daysInbetween = _calculator.WeekdaysBetweenTwoDates(firstDate, secondDate);

            daysInbetween.Should().Be(7);
        }

        [Fact]
        public void Given_NumberOfBusinessDaysWithNoPublicHolidays_ShouldReturnNumberOfBusinessDays()
        {
            var firstDate = new DateTime(2023, 10, 10);
            var secondDate = new DateTime(2023, 10, 22);
            var publicHolidays = new List<DateTime>();

            var daysInbetween = _calculator.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            daysInbetween.Should().Be(8);
        }

        [Fact]
        public void Given_NumberOfBusinessDaysWithPublicHolidays_ShouldReturnNumberOfBusinessDays()
        {
            var firstDate = new DateTime(2023, 10, 10);
            var secondDate = new DateTime(2023, 10, 22);
            var publicHolidays = new List<DateTime> {
                                            new(2023, 10, 11),
                                            new(2023, 10, 12)
                                                };

            var daysInbetween = _calculator.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            daysInbetween.Should().Be(6);
        }

        [Fact]
        public void Given_BusinessDaysWithFixedHolidayRules_ShouldReturnNumberOfBusinessDays()
        {
            DateTime firstDate = new(2023, 12, 20);
            DateTime secondDate = new(2023, 12, 30);

            var holiday1 = new HolidayRule("Christmas Day", HolidayType.FixedDate, 25, 12);
            var holiday2 = new HolidayRule("Box Day", HolidayType.FixedDate, 26, 12);

            var holidayRules = new List<HolidayRule>
            {
                holiday1, holiday2
            };

            var daysInbetween = _calculator.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidayRules);

            daysInbetween.Should().Be(5);
        }

        [Fact]
        public void Given_NumberOfBusinessDaysWithWeekendAdjustedHolidayRules_ShouldReturnNumberOfBusinessDays()
        {
            var firstDate = new DateTime(2023, 12, 27);
            var secondDate = new DateTime(2024, 01, 02);

            var holiday1 = new HolidayRule("New Year's Eve", HolidayType.WeekendAdjusted, 31, 12);
            var holidayRules = new List<HolidayRule>
            {
                holiday1
            };

            var daysInbetween = _calculator.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidayRules);

            daysInbetween.Should().Be(2);
        }


        [Fact]
        public void Given_NumberOfBusinessDaysWithNthDayHolidayRule_ShouldReturnNumberOfBusinessDays()
        {
            var firstDate = new DateTime(2023, 06, 1);
            var secondDate = new DateTime(2023, 07, 1);

            var holiday1 = new HolidayRule("Queen's Birthday", 6, DayOfWeek.Monday, 2);

            var holidayRules = new List<HolidayRule>
            {
                holiday1
            };

            var daysInbetween = _calculator.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidayRules);

            daysInbetween.Should().Be(20);
        }
    }
}
