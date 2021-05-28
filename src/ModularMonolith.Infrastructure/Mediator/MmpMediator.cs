using MassTransit.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModularMonolith.Infrastructure.Mediator
{
    public class MmpMediator : IMmpMediator
    {
        IMediator massTransitMediator;

        public MmpMediator(IMediator massTransitMediator)
        {
            this.massTransitMediator = massTransitMediator;
        }

        public async Task Send<T>(T command)
            where T : MmpCommand
        {
            await massTransitMediator.Send(command);
        }

        public async Task<T1> Send<T, T1>(T command)
            where T : MmpCommand
            where T1 : class
        {
            var requestClient = massTransitMediator.CreateRequestClient<T>();

            var response = await requestClient.GetResponse<T1>(command);
            return response.Message;
        }
    }
}
