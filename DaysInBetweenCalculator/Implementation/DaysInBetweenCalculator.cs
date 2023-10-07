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
            var numberOfWeekdays = CalculateDays(firstDate, secondDate);
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
            var numberOfBusinessDays = CalculateDays(firstDate, secondDate, publicHolidays);
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
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, HolidayRules holidays)
        {
            var publicHolidayDates = GetHolidayDatesInRange(firstDate, secondDate, holidays.PublicHolidays);
            var numberOfBusinessDays = CalculateDays(firstDate, secondDate, publicHolidayDates, calculateDaysInLieu: holidays.CalculateDayInLieu);
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
        /// Check if date is public holiday
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        private static bool IsPublicHoliday(DateTime currentDate, IList<DateTime>? publicHolidays)
        {
            if (publicHolidays != null)
            {
                return publicHolidays.Any(holiday => holiday.Date == currentDate.Date);
            }
            else
            {
                return false;

            }
        }

        /// <summary>
        /// Calculate number of working days
        /// Use Optional parameters calculate working days, public holidays and day in lieu
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="publicHolidays"></param>
        /// <param name="calculateDaysInLieu"></param>
        /// <returns></returns>
        private static int CalculateDays(DateTime firstDate,
                                         DateTime secondDate,
                                         IList<DateTime>? publicHolidays = null,
                                         bool calculateDaysInLieu = false)
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

                if (isWeekday)
                {
                    if (!isPublicHoliday)
                    {
                        numberOfDays++;
                    }
                }
                else
                {
                    if (isPublicHoliday && calculateDaysInLieu)
                    {
                        numberOfDays--;
                    }
                }
                currentDate = currentDate.AddDays(1);
            }

            return numberOfDays;
        }

        /// <summary>
        /// Get a list of applicable dates in range of input dates
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="publicHolidayDates"></param>
        /// <returns></returns>
        private IList<DateTime> GetHolidayDatesInRange(DateTime firstDate, 
                                                       DateTime secondDate, 
                                                       IList<Holiday> publicHolidayDates)
        {
            var datesInRange = new List<DateTime>();
            return datesInRange;
        }

        #endregion
    }
}