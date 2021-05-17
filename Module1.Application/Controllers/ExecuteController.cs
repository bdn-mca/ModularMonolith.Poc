﻿using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Infrastructure.EventBus;
using Module1.IntegrationEvents;
using System;
using System.Threading.Tasks;

namespace Module1.Application
{
    [ApiController]
    [Route("module-one")]
    public class ExecuteController : ControllerBase
    {
        private IEventBusDispatcher eventDispatch;

        public ExecuteController(IEventBusDispatcher eventDispatch)
        {
            this.eventDispatch = eventDispatch;
        }

        [HttpGet("execute")]
        public async Task<IActionResult> Get()
        {
            await eventDispatch.Dispatch(new ExecuteHappened(DateTime.Now));

            return Ok("Module 1 ok");
        }
    }
}
