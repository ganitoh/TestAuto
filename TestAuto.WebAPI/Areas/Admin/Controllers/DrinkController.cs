using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAuto.Application.CQRS.Drinks.Commands.CreateDrink;
using TestAuto.Application.CQRS.Drinks.Commands.DeleteDrink;
using TestAuto.Application.CQRS.Drinks.Commands.UpdateDrink;

namespace TestAuto.WebAPI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/drink")]
    public class DrinkController : Controller
    {
        private readonly IMediator _mediator;

        public DrinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{token}")]
        public async Task<IActionResult> AddDrink([FromBody] CreateDrinkComamnd command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("Delete/{token}")]
        public async Task<IActionResult> DeleteDrink([FromBody] DeleteDrinkCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("update/{token}")]
        public async Task<IActionResult> UpdateDrinkInfo([FromBody] UpdateDrinkCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
