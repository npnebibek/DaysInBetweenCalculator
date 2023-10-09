# DaysInBetweenCalculator

The `DaysInBetweenCalculator` class is a utility for calculating the number of weekdays and business days between two given dates, considering public holidays like Fixed, WeekendAdjusted and NthDayofMonth holidays.

## Public Methods

### `int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)`

Calculates the number of weekdays (Monday through Friday) between two dates.

-   `firstDate`: The start date.
-   `secondDate`: The end date.
-   Returns the number of weekdays between the two dates.

### `int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)`

Calculates the number of business days (weekdays excluding public holidays) between two dates.

-   `firstDate`: The start date.
-   `secondDate`: The end date.
-   `publicHolidays`: List of public holidays to considerof type DateTime.
-   Returns the number of business days between the two dates.

### `int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<HolidayRule> publicHolidays)`

Calculates the number of business days for a List of HolidayRules holidays Fixed, WeekendAdjusted and NthDayOfTheMonth Types

-   `firstDate`: The start date.
-   `secondDate`: The end date.
-   `publicholidays`: Holiday rules specifying public holidays of type HolidayRule for Fixed, WeekendAdjusted and NthDayOfTheMonth Holiday
-   Returns the number of business days between the two dates.

## Private Methods

### `private static bool IsValidDateInputs(DateTime firstDate, DateTime secondDate)`

Validates the entered date values to ensure `firstDate` is before `secondDate`. In this case if they are equal returns false.

### `private static bool IsWeekday(DateTime currentDate)`

Checks if a given date falls on a weekday (Monday through Friday).

### `private static bool IsPublicHoliday(DateTime currentDate, IList<DateTime> publicHolidays)`

Checks if a given date is a public holiday based on the provided list of public holidays.

### `private static int CalculateBusinessDays(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)`

Calculates the number of business days between two dates considering public holidays.

### `private static int CalculateBusinessDays(DateTime firstDate, DateTime secondDate, IList<HolidayRule> publicHolidays)`

Calculates the number of business days between two dates considering public holidays with complex rules extended by HolidayRule.

### `Holiday Rule Class Implementation`

```csharp
using DaysInBetweenCaculator.Helpers;

namespace DaysInBetweenCalculator.Helpers
{
    public class HolidayRule
    {
        public string? Name { get; set; }
        public HolidayType Type { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public int OccurrenceWeek { get; set; }


        public HolidayRule(string? name, HolidayType holidayType, int day, int month)
        {
            Name = name;
            Type = holidayType;
            Day = day;
            Month = month;
        }

        public HolidayRule(string? name, int month, DayOfWeek? dayOfWeek, int occurenceWeek)
        {
            Name = name;
            Type = HolidayType.NthDayOfMonth;
            Month = month;
            DayOfWeek = dayOfWeek;
            OccurrenceWeek = occurenceWeek;
        }

        public bool IsPublicHoliday(DateTime currentDate)
        {
            var currentYear = currentDate.Year;

            switch(Type)
            {
                case HolidayType.FixedDate:
                case HolidayType.WeekendAdjusted:
                    return currentDate.Day == Day && currentDate.Month == Month;

                case HolidayType.NthDayOfMonth:
                    var firstDateOfMonth = new DateTime(currentYear, currentDate.Month, 1);
                    var occurence = 0;

                    for(var dateToCheck = firstDateOfMonth; dateToCheck.Month == Month; dateToCheck = dateToCheck.AddDays(1))
                    {
                        if (dateToCheck.DayOfWeek == DayOfWeek)
                        {
                            occurence++;
                            if (occurence == OccurrenceWeek && dateToCheck.Day == currentDate.Day)
                            {
                                return true;
                            }
                        }
                    }
                    return false;

                default:
                    return false;

            }
        }
    }
}

```

The HolidayRules class is used to configure holiday rules for Fixed, WeekendAdjusted and NthDayofMonth Holiday. Holiday class can further be configured or extended as per use case.

## Usage

You can use the `DaysInBetweenCalculator` class to calculate weekdays, business days, and more based on your specific requirements. Make sure to provide the necessary input parameters as described in the method documentation.

Example:

```csharp
 public static class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Implementation.DaysInBetweenCalculator();

            DateTime startDate = new(2023, 12, 20);
            DateTime endDate = new(2024, 01, 02);

            //DateTime startDate = new(2023, 06, 1);
            //DateTime endDate = new(2023, 07, 01);

            var publicHolidays = new List<DateTime>
            {
                new(2023, 12, 25), new(2023, 12, 26), new(2023, 12, 31)
            };

            var holiday1 = new HolidayRule("Christmas Day", HolidayType.FixedDate, 25, 12);
            var holiday2 = new HolidayRule("Box Day", HolidayType.FixedDate, 26, 12);
            var holiday3 = new HolidayRule("New Year's Eve", HolidayType.WeekendAdjusted, 31, 12);
            var holiday4 = new HolidayRule("Queen's Birthday", 6, DayOfWeek.Monday, 2);


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
            Console.WriteLine($"Business Days with Holiday Rules: {businessDaysWithLieu}");

        }
    }
```
