using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.DependencyInjection;
using Module2.Application.EventConsumers;

namespace Module2.Application.Startup
{
    public static class RegisterConsumers
    {
        public static IServiceCollection RegisterModuleTwo(this IServiceCollection services)
        {
            return services;
        }

        public static void RegisterModuleTwoConsumers(this IServiceCollectionBusConfigurator configurator)
        {
            configurator.AddConsumer<ExecuteHappenedConsumer>();
        }
    }
}
