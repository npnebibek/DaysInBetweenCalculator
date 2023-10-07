using DaysInBetweenCalculator.Interface;

namespace DaysInBetweenCalculator.Implementaion
{
    public class BusinessDayCounter : IBusinessDayCounter
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
            var numberOfWeedays = 0;

            if (!IsValidDateInputs(firstDate, secondDate))
            {
                return numberOfWeedays;
            }

            //We do not include the startDate and endDate
            var currentDate = firstDate.AddDays(1);

            while(currentDate < secondDate)
            {
                if(IsWeekday(currentDate))
                {
                    numberOfWeedays++;
                }
                currentDate = currentDate.AddDays(1);
            }

            return numberOfWeedays;
        }

        /// <summary>
        /// Calculate number of business days between two dates based on public holidays
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="publicHolidays"></param>
        /// <returns></returns>
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IEnumerable<DateTime> publicHolidays)
        {
            var numberOfBusinessDays = 0;

            if (!IsValidDateInputs(firstDate, secondDate))
            {
                return numberOfBusinessDays;
            }

            //We do not include the startDate and endDate
            var currentDate = firstDate.AddDays(1);

            while (currentDate < secondDate)
            {
                if (IsWeekday(currentDate))
                {
                    numberOfBusinessDays++;
                }
                currentDate = currentDate.AddDays(1);
            }


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
            if(currentDate.DayOfWeek != DayOfWeek.Saturday || currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }

        private static bool IsBusinessDay(DateTime currentDate)
        {
            return false;
        }

        #endregion

    }
}