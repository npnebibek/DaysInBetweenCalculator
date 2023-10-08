using DaysInBetweenCalculator.Interface;
using Microsoft.Extensions.DependencyInjection;


namespace DaysInBetweenCalculator.Tests
{
    public class Startup
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IDaysInBetweenCalculator, Implementation.DaysInBetweenCalculator>();
            return services.BuildServiceProvider();
        }
    }
}
