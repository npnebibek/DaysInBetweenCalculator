namespace DaysInBetweenCaculator.Helpers
{
    public class FixedDayHoliday : IHoliday
    {
        private readonly int _day;
        private readonly int _month;

        public FixedDayHoliday(int day, int month)
        {
            _day = day;
            _month = month;
        }
        public bool IsPublicHoliday(DateTime date)
        {
            return date.Day == _day && date.Month == _month;
        }
    }
}
