using MassTransit.ExtensionsDependencyInjectionIntegration;
using Module2.Application.EventConsumers;

namespace Module2.Application.Startup
{
    public static class RegisterConsumers
    {
        public static void RegisterModuleTwoConsumers(this IServiceCollectionBusConfigurator configurator)
        {
            configurator.AddConsumer<ExecuteHappenedConsumer>();
        }
    }
}
