namespace DaysInBetweenCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Implementation.DaysInBetweenCalculator();

            DateTime startDate = new(2023, 10, 5);
            DateTime endDate = new(2023, 10, 4);

            int daysBetween = calculator.WeekdaysBetweenTwoDates(startDate, endDate);

            Console.WriteLine($"Days between: {daysBetween}");
        }
    }
}

