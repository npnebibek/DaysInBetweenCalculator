namespace DaysInBetweenCaculator.Helpers
{
    internal class NthDayHoliday : IHoliday
    {
        private readonly int _month;
        private readonly DayOfWeek _dayOfWeek;
        private readonly string _name;

        public NthDayHoliday(int month, DayOfWeek dayOfWeek, string name)
        {
            _month = month;
            _dayOfWeek = dayOfWeek;
            _name = name;
        }

        public bool IsPublicHoliday(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
