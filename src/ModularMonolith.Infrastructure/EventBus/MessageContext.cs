namespace ModularMonolith.Infrastructure.EventBus
{
    public class MessageContext<T> where T : class
    {
        public MessageContext(T message, string correlationId)
        {
            Message = message;
            CorrelationId = correlationId;
        }

        public T Message { get; }

        public string CorrelationId { get; }
    }
}
