using DaysInBetweenCalculator.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace DaysInBetweenCalculator.Tests
{
    public class TestStartup
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IDaysInBetweenCalculator, Implementation.DaysInBetweenCalculator>();

            return services.BuildServiceProvider();
        }
    }
}


