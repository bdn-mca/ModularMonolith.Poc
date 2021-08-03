namespace Module1.Application.Filters
{
    using GreenPipes;
    using MassTransit;
    using System;
    using System.Threading.Tasks;

    public class ConsoleConsumeFilter :
        IFilter<ConsumeContext>
    {
        public void Probe(ProbeContext context)
        {
            context.CreateFilterScope("consoleConsumeFilter");
        }

        public Task Send(ConsumeContext context, IPipe<ConsumeContext> next)
        {
            Console.WriteLine("Consume: {0}", context.MessageId);
            return next.Send(context);
        }
    }
}
