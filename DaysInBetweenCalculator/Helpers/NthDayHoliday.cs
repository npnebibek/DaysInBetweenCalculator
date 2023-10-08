namespace DaysInBetweenCaculator.Helpers
{
    internal class NthDayHoliday : IHoliday
    {
        private readonly int _day;
        private readonly int _month;
        private readonly DayOfWeek _dayOfWeek;

        public NthDayHoliday(int day, int month, DayOfWeek dayOfWeek)
        {
            _day = day;
            _month = month;
            _dayOfWeek = dayOfWeek;
        }

        public bool IsPublicHoliday(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
