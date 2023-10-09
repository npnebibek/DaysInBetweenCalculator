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

        public HolidayRule(string? name, int day, int month, DayOfWeek? dayOfWeek, int occurenceWeek)
        {
            Name = name;
            Type = HolidayType.NthDayOfMonth;
            Day = day;
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
                    return currentDate.Day == Day && currentDate.Month == Month;

                case HolidayType.WeekendAdjusted:
                    var holidayDate = new DateTime(currentYear, Month, Day);

                    if(holidayDate.DayOfWeek == System.DayOfWeek.Saturday)
                    {
                        return holidayDate.AddDays(2).Date == currentDate;
                    }

                    if(holidayDate.DayOfWeek == System.DayOfWeek.Sunday)
                    {
                        return holidayDate.AddDays(1).Date == currentDate;
                    }
                    return false;

                case HolidayType.NthDayOfMonth:
                    var firstDateOfMonth = new DateTime(currentYear, Month, 1);
                    var occurence = 0;

                    for(var dateToCheck = firstDateOfMonth; dateToCheck.Month == Month; dateToCheck = dateToCheck.AddDays(1))
                    {
                        if (dateToCheck.DayOfWeek == DayOfWeek)
                        {
                            occurence++;
                            if (occurence == OccurrenceWeek)
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
