﻿using DaysInBetweenCalculator.Helpers;

namespace DaysInBetweenCalculator.Interface
{
    internal interface IBusinessDayCounter
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, Holidays holidays);
    }
}
