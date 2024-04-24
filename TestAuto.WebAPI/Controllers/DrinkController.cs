using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TestAuto.Application.CQRS.Drinks.Queries.GetAllDrinksByAmount;
using TestAuto.Application.CQRS.Drinks.Queries.GetAllDrinksByDispenser;

namespace TestAuto.WebAPI.Controllers
{
    [Route("drink")]
    public class DrinkController : Controller
    {
        private readonly IMediator _mediator;

        public DrinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-by-deposit")]
        public async Task<IActionResult> GetAllDrinksByDeposit([FromQuery] int dispenserId = 1)
        {
            if (HttpContext.Session.Keys.Contains("amount"))
            {
                var amount = HttpContext.Session.GetInt32("amount")!;
                var resultDrinks = await _mediator.Send(new GetAllDrinksByAmountRequest(dispenserId, (int)amount));
                return Ok(resultDrinks);
            }
            else
               return BadRequest(new { message = "error" });
        }

        [HttpGet("all-by-dispenser")]
        public async Task<IActionResult> GetAllDrinksByDispenser([FromQuery] int dispenserId = 1)
        {
            var resultDrinkd = await _mediator.Send(new GetAllDrinksByDispenserRequest(dispenserId));
            return Ok(resultDrinkd);
        }

        
    }
}
