namespace DaysInBetweenCalculator.Interface
{
    internal interface IBusinessDayCounter
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IEnumerable<DateTime> publicHolidays);

    }
}
