using System.Threading.Tasks;

namespace ModularMonolith.Infrastructure.EventBus
{
    public interface IEventBusDispatcher
    {
        Task Dispatch<T>(T message) where T : class;
    }
}
