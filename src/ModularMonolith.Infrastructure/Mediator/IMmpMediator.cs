using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModularMonolith.Infrastructure.Mediator
{
    public interface IMmpMediator
    {
        Task Send<T>(T command)
            where T : MmpCommand;

        Task<T1> Send<T, T1>(T command)
            where T : MmpCommand
            where T1 : class;
    }
}
