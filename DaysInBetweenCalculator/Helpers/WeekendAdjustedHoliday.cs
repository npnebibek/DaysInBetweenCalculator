namespace DaysInBetweenCaculator.Helpers
{
    public class WeekendAdjustedHoliday : IHoliday
    {
        private readonly int _day;
        private readonly int _month;

        public WeekendAdjustedHoliday(int day, int month)
        {
            _day = day;
            _month = month;
        }
        public bool IsPublicHoliday(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
