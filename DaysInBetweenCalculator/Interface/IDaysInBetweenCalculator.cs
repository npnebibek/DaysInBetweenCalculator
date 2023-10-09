using DaysInBetweenCalculator.Helpers;

namespace DaysInBetweenCalculator.Interface
{
    public interface IDaysInBetweenCalculator
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<HolidayRule> publicHolidays);
    }
}
