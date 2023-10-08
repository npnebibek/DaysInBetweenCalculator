# DaysInBetweenCalculator

The `DaysInBetweenCalculator` class is a utility for calculating the number of weekdays and business days between two given dates, considering public holidays and optional day-in-lieu calculations.

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
-   `publicHolidays`: List of public holidays to consider.
-   Returns the number of business days between the two dates.

### `int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, HolidayRules holidays)`

Calculates the number of business days considering public holidays and optional day-in-lieu calculations.

-   `firstDate`: The start date.
-   `secondDate`: The end date.
-   `holidays`: Holiday rules specifying public holidays, recurring holiday rules, state only rules and day-in-lieu calculations.
-   Returns the number of business days between the two dates.

## Private Methods

### `private static bool IsValidDateInputs(DateTime firstDate, DateTime secondDate)`

Validates the entered date values to ensure `firstDate` is before `secondDate`. In this case if they are equal returns false.

### `private static bool IsWeekday(DateTime currentDate)`

Checks if a given date falls on a weekday (Monday through Friday).

### `private static bool IsPublicHoliday(DateTime currentDate, IList<DateTime>? publicHolidays)`

Checks if a given date is a public holiday based on the provided list of public holidays.

### `private static int CalculateBusinessDays(DateTime firstDate, DateTime secondDate, IList<DateTime>? publicHolidays = null, bool calculateDaysInLieu = false)`

Calculates the number of business days between two dates considering public holidays and optional day-in-lieu calculations.

-   `firstDate`: The start date.
-   `secondDate`: The end date.
-   `publicHolidays`: List of public holidays to consider.
-   `calculateDaysInLieu`: Indicates whether to calculate day-in-lieu.
-   Returns the number of business days between the two dates.

## Usage

You can use the `DaysInBetweenCalculator` class to calculate weekdays, business days, and more based on your specific requirements. Make sure to provide the necessary input parameters as described in the method documentation.

Example:

```csharp

            DateTime startDate = new(2023, 12, 20);
            DateTime endDate = new(2024, 01, 02);

            var publicHolidays = new List<DateTime>
            {
                new(2023, 12, 25), new(2023, 12, 26), new(2023, 12, 31)
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


            var holiday3 = new Holiday
            {
                HolidayDate = new(2023, 12, 31),
                Name = "New Year's Eve",
                StateHoliday = true,
                Recurring = true,
            };

            var holidayRules = new HolidayRules
            {
                PublicHolidays = new List<Holiday> { holiday1, holiday2, holiday3},
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
```
