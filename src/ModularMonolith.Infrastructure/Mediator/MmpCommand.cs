using System;
using System.Collections.Generic;
using System.Text;

namespace ModularMonolith.Infrastructure.Mediator
{
    public abstract class MmpCommand
    {
        // abstract class instead of interface
        // because it has to be a reference type (mass transit limitation, due to performance)
    }
}
