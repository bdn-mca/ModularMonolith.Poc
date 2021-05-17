using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Infrastructure.EventBus;
using Module2.IntegrationEvents;
using System;
using System.Threading.Tasks;

namespace Module2.Application
{
    [ApiController]
    [Route("module-two")]
    public class OrderController : ControllerBase
    {
        IEventBusDispatcher eventDispatch;

        public OrderController(IEventBusDispatcher eventDispatch)
        {
            this.eventDispatch = eventDispatch;
        }

        [HttpGet("order")]
        public async Task<IActionResult> Get()
        {
            await eventDispatch.Dispatch(new ItemOrdered(DateTime.Now));

            return Ok("Module 2 ok");
        }
    }
}
