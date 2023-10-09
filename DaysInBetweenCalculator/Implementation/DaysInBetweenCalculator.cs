using DaysInBetweenCaculator.Helpers;
using DaysInBetweenCalculator.Helpers;
using DaysInBetweenCalculator.Interface;

namespace DaysInBetweenCalculator.Implementation
{
    public class DaysInBetweenCalculator : IDaysInBetweenCalculator
    {
        #region public methods
        /// <summary>
        /// Calculate number of weekdays between two days
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns></returns>
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            var numberOfWeekdays = CalculateBusinessDays(firstDate,
                                                         secondDate,
                                                         publicHolidays: new List<DateTime>());
            return numberOfWeekdays;
        }

        /// <summary>
        /// Calculate number of business days between two dates based on public holidays
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            var numberOfBusinessDays = CalculateBusinessDays(firstDate,
                                                             secondDate,
                                                             publicHolidays);
            return numberOfBusinessDays;
        }

        /// <summary>
        /// Calculate public holidays(PH) and day inlieu i.e if PH occurs on a weekend it gets transferred
        /// to the subsequent weekday
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="holidays"></param>
        /// <returns></returns>
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<HolidayRule> publicHolidays)
        {

            var numberOfBusinessDays = CalculateBusinessDays(firstDate,
                                                             secondDate,
                                                             publicHolidays);
            return numberOfBusinessDays;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Validate entered date values
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns></returns>
        private static bool IsValidDateInputs(DateTime firstDate, DateTime secondDate)
        {
            if (DateTime.Compare(firstDate, secondDate) > 0 || DateTime.Compare(firstDate, secondDate) == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check Is Weekday?
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        private static bool IsWeekday(DateTime currentDate)
        {
            if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check is public holiday?
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        private static bool IsPublicHoliday(DateTime currentDate, IList<DateTime> publicHolidays)
        {
            return publicHolidays.Any(holiday => holiday.Date == currentDate.Date);
        }

        /// <summary>
        /// Calculate number of working days and public holidays
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        private static int CalculateBusinessDays(DateTime firstDate,
                                                 DateTime secondDate,
                                                 IList<DateTime> publicHolidays)
        {
            var numberOfDays = 0;

            if (!IsValidDateInputs(firstDate, secondDate))
            {
                return numberOfDays;
            }

            //We do not include the startDate and endDate
            var currentDate = firstDate.AddDays(1);

            while (currentDate < secondDate)
            {
                var isWeekday = IsWeekday(currentDate);
                var isPublicHoliday = IsPublicHoliday(currentDate, publicHolidays);

                if (isWeekday && !isPublicHoliday)
                {
                    numberOfDays++;
                }

                currentDate = currentDate.AddDays(1);
            }

            return numberOfDays;
        }

        /// <summary>
        /// Calculate number of working days and complex public holidays types
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        private static int CalculateBusinessDays(DateTime firstDate,
                                                 DateTime secondDate,
                                                 IList<HolidayRule> publicHolidays)
        {
            var numberOfDays = 0;

            if (!IsValidDateInputs(firstDate, secondDate))
            {
                return numberOfDays;
            }

            //We do not include the startDate and endDate
            var currentDate = firstDate.AddDays(1);

            while (currentDate < secondDate)
            {
                var isWeekday = IsWeekday(currentDate);
                var isPublicHoliday = publicHolidays.Any(ph => ph.IsPublicHoliday(currentDate));

                if (isWeekday && !isPublicHoliday)
                {

                    numberOfDays++;
                }

                currentDate = currentDate.AddDays(1);
            }

            return numberOfDays;
        }
        #endregion
    }
}