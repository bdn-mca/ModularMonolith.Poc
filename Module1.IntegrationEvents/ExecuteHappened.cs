using System;

/// <summary>
/// Each integration event needs to have the same namespace - limitation by MassTransit
/// https://masstransit-project.com/usage/messages.html#message-names & https://stackoverflow.com/a/52480419/2567835
/// We allow referencing integration events betweeen modules, so we don't need to follow that
/// </summary>
namespace Module1.IntegrationEvents
{
    public class ExecuteHappened
    {
        public ExecuteHappened(DateTime occuredOn)
        {
            OccuredOn = occuredOn;
        }

        public DateTime OccuredOn { get; }
    }
}
