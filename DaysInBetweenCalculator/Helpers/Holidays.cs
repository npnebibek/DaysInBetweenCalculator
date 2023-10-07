namespace DaysInBetweenCalculator.Helpers
{
    public class HolidayRules
    {
        public IList<Holiday> PublicHolidays { get; set; } = new List<Holiday>();
        public bool CalculateDayInLieu { get; set; }
    }

    public class Holiday
    {
        public DateTime HolidayDate { get; set; }
        public string? Name { get; set; }
        public bool Recurring { get; set; }
        public bool StateHoliday { get; set; }
        public string? State { get; set; }
    }
}
