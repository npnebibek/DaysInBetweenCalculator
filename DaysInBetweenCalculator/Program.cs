using DaysInBetweenCalculator.Helpers;

namespace DaysInBetweenCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Implementation.DaysInBetweenCalculator();

            DateTime startDate = new(2023, 10, 6);
            DateTime endDate = new(2023, 10, 14);

            var publicHolidays = new List<DateTime>
            {
                new(2023, 10, 9), new(2023, 10, 10)
            };

            var holiday1 = new Holiday
            {
                HolidayDate = new(2023, 12, 25),
                Name = "Christmas Day",
                StateHoliday = false,
                Recurring = true,
            };

            var holiday2 = new Holiday
            {
                HolidayDate = new(2023, 12, 26),
                Name = "Boxing Day",
                StateHoliday = false,
                Recurring = true,
            };

            var holidayRules = new HolidayRules
            {
                PublicHolidays = new List<Holiday> { holiday1, holiday2},
                CalculateDayInLieu = true
            };

            var weekDays = calculator.WeekdaysBetweenTwoDates(startDate, endDate);
            var businessDays = calculator.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);
            var businessDaysWithLieu = calculator.BusinessDaysBetweenTwoDates(startDate, endDate, holidayRules);

            Console.WriteLine($"Start Date: {startDate.Date}");
            Console.WriteLine($"End Date: {endDate.Date}");

            Console.WriteLine($"Week Days: {weekDays}");
            Console.WriteLine($"Business Days: {businessDays}");
            Console.WriteLine($"Business Days with Lieu: {businessDaysWithLieu}");

        }
    }
}

