using DaysInBetweenCalculator.Interface;

namespace DaysInBetweenCalculator.Implementaion
{
    public class BusinessDayCounter : IBusinessDayCounter
    {
        /// <summary>
        /// Calculate number of weekdays between two days
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns></returns>
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            ValidateInputDates(firstDate, secondDate);
            return 0;
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
            ValidateInputDates(firstDate, secondDate);
            return 0;
        }

        /// <summary>
        /// Validate entered date values
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns></returns>
        private static int ValidateInputDates(DateTime firstDate, DateTime secondDate)
        {

            if (DateTime.Compare(firstDate, secondDate) > 0)
            {
                return 0;
            }
            else if (DateTime.Compare(firstDate, secondDate) == 0)
            {
                return 0;
            }
            return 1;
        }

    }
}