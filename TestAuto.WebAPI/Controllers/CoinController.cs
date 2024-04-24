using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAuto.Application.CQRS.Coins.Queries.GetAllCoinByDispenser;

namespace TestAuto.WebAPI.Controllers
{
    [Route("coin")]
    public class CoinController : Controller
    {
        private readonly IMediator _mediator;

        public CoinController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all-coins-dispenser")]
        public async Task<IActionResult> GetAllCoinsByDispenser([FromQuery]int dispenserId = 1)
        {
            var resultCoins = await _mediator.Send(new GetAllCoinByDispenserRequest(dispenserId));
            return Ok(resultCoins);
        }
    }
}
