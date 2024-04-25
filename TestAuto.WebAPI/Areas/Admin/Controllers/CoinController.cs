using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAuto.Application.CQRS.Coins.Command.BlockCoin;
using TestAuto.Application.CQRS.Coins.Command.UnblockCoin;
using TestAuto.Application.CQRS.Coins.Command.UpdateCountCoin;

namespace TestAuto.WebAPI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/coin")]
    public class CoinController : Controller
    {
        private readonly IMediator _mediator;

        public CoinController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("update-count/{token}")]
        public async Task<IActionResult> UpdateCountCoin([FromBody] UpdateCountCoinCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("block/{token}")]
        public async Task<IActionResult> BlockCoin([FromBody] BlockCoinCommand commad)
        {
            await _mediator.Send(commad);
            return Ok();
        }

        [HttpPost("unblock/{token}")]
        public async Task<IActionResult> UnblockCoin([FromBody] UnblockCoinCommand commad)
        {
            await _mediator.Send(commad);
            return Ok();
        }
    }
}
