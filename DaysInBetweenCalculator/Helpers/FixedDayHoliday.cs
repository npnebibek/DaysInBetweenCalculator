namespace DaysInBetweenCaculator.Helpers
{
    public class FixedDayHoliday : IHoliday
    {
        private readonly int _day;
        private readonly int _month;
        private readonly string _name;

        public FixedDayHoliday(int day, int month, string name)
        {
            _day = day;
            _month = month;
            _name = name;
        }
        public bool IsPublicHoliday(DateTime date)
        {
            return date.Day == _day && date.Month == _month;
        }
    }
}
