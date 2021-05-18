using MassTransit.ExtensionsDependencyInjectionIntegration;
using Module1.Application.EventConsumers;

namespace Module1.Application.Startup
{
    public static class RegisterConsumers
    {
        public static void RegisterModuleOneConsumers(this IServiceCollectionBusConfigurator configurator)
        {
            configurator.AddConsumer<ExecuteHappenedConsumer>();
            configurator.AddConsumer<ItemOrderedConsumer>();
        }
    }
}
