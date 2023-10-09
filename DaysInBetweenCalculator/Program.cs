using DaysInBetweenCaculator.Helpers;
using DaysInBetweenCalculator.Helpers;

namespace DaysInBetweenCalculator
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Implementation.DaysInBetweenCalculator();

            DateTime startDate = new(2023, 12, 20);
            DateTime endDate = new(2024, 01, 02);

            var publicHolidays = new List<DateTime>
            {
                new(2023, 12, 25), new(2023, 12, 26), new(2023, 12, 31)
            };

            var holiday1 = new HolidayRule("Christmas Day", HolidayType.FixedDate, 25, 12);
            var holiday2 = new HolidayRule("Box Day", HolidayType.FixedDate, 26, 12);
            var holiday3 = new HolidayRule("New Year's Eve", HolidayType.WeekendAdjusted, 31, 12);
            var holiday4 = new HolidayRule("Queen's Birthday",6, DayOfWeek.Monday, 2);


            var holidayRules = new List <HolidayRule>
            {
                holiday1, holiday2, holiday3, holiday4
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

