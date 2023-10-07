using DaysInBetweenCalculator.Interface;
using DaysInBetweenCalculator.Implementation;

namespace DaysInBetweenCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Implementation.DaysInBetweenCalculator();

            DateTime startDate = new(2023, 10, 1);
            DateTime endDate = new(2023, 10, 15);

            int daysBetween = calculator.WeekdaysBetweenTwoDates(startDate, endDate);

            Console.WriteLine($"Days between: {daysBetween}");
        }
    }
}

