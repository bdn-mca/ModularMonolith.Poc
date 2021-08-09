using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.DependencyInjection;
using Module1.Application.EventConsumers;
using Module1.Application.Services;

namespace Module1.Application.Startup
{
    public static class RegisterConsumers
    {
        public static IServiceCollection RegisterModuleOne(this IServiceCollection services)
        {
            services.AddScoped<IDummyService, DummyService>();
            return services;
        }

        public static void RegisterModuleOneConsumers(this IServiceCollectionBusConfigurator configurator)
        {
            configurator.AddConsumer<ExecuteHappenedConsumer>();
            configurator.AddConsumer<ItemOrderedConsumer>();
        }
    }
}
