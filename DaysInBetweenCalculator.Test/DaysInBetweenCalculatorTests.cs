using DaysInBetweenCalculator.Interface;

using Xunit;
using FluentAssertions;
using DaysInBetweenCalculator.Helpers;

namespace DaysInBetweenCalculator.Tests
{

    public class DaysInBetweenCalculatorTests
    {
        private readonly IDaysInBetweenCalculator _calculator;
        public DaysInBetweenCalculatorTests()
        {
            _calculator = new Implementation.DaysInBetweenCalculator();
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
        public void Given_BusinessDaysWithHolidayRulesAndNoDaysInLieu_ShouldReturnNumberOfBusinessDays()
        {
            var firstDate = new DateTime(2023, 10, 10);
            var secondDate = new DateTime(2023, 10, 22);

            var holiday1 = new Holiday
            {
                Name = "Holiday1",
                Recurring = true,
                HolidayDate = new(2023, 10, 13),
                StateHoliday = false,
            };

            var holiday2 = new Holiday
            {
                Name = "Holiday1",
                Recurring = true,
                HolidayDate = new(2023, 10, 14),
                StateHoliday = false,
            };

            var holidays = new HolidayRules
            {
                PublicHolidays = new List<Holiday> { holiday1, holiday2 },
                CalculateDayInLieu = false
            };

            var daysInbetween = _calculator.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays);

            daysInbetween.Should().Be(7);
        }

        [Fact]
        public void Given_NumberOfBusinessDaysWithHolidayRulesAndDaysInLieu_ShouldReturnNumberOfBusinessDays()
        {
            var firstDate = new DateTime(2023, 10, 10);
            var secondDate = new DateTime(2023, 10, 22);

            var holiday1 = new Holiday
            {
                Name = "Holiday1",
                Recurring = true,
                HolidayDate = new(2023, 10, 13),
                StateHoliday = false,
            };

            var holiday2 = new Holiday
            {
                Name = "Holiday1",
                Recurring = true,
                HolidayDate = new(2023, 10, 14),
                StateHoliday = false,
            };

            var holidays = new HolidayRules
            {
                PublicHolidays = new List<Holiday> { holiday1, holiday2 },
                CalculateDayInLieu = false
            };

            var daysInbetween = _calculator.BusinessDaysBetweenTwoDates(firstDate, secondDate, holidays);

            daysInbetween.Should().Be(6);
        }
    }
}
