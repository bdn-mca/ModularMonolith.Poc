using System;

/// <summary>
/// Each integration event needs to have the same namespace - limitation by MassTransit
/// https://masstransit-project.com/usage/messages.html#message-names & https://stackoverflow.com/a/52480419/2567835
/// We allow referencing integration events betweeen modules, so we don't need to follow that
/// </summary>
namespace Module2.IntegrationEvents
{
    public class ItemOrdered
    {
        public ItemOrdered(DateTime processedOn)
        {
            ProcessedOn = processedOn;
        }
        
        public DateTime ProcessedOn { get; }
    }
}
