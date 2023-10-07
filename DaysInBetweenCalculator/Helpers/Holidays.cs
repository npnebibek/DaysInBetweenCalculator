using System;
using System.Collections.Generic;

namespace DaysInBetweenCalculator.Helpers
{
    public class Holidays
    {
        public IList<DateTime> PublicHolidays { get; set; } = new List<DateTime>();
        public int DaysInLieu { get; set; }
    }
}
