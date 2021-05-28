using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Infrastructure.Mediator;
using Module1.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Module1.Application.Controllers
{
    [ApiController]
    [Route("module-one/command")]
    public class CommandController : ControllerBase
    {
        private readonly IMmpMediator mediator;

        public CommandController(IMmpMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("demo")]
        public async Task<IActionResult> PostDemo()
        {
            var result = await mediator.Send<Demo.Command, Demo.Response>(new Demo.Command());
            return Ok(result);
        }

        [Route("no-result")]
        public async Task<IActionResult> PostNoResult()
        {
            await mediator.Send(new NoResult.Command());
            return Ok();
        }
    }
}
