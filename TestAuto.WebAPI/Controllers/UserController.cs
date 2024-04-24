using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using TestAuto.Application.CQRS.Coins.Command.DecrementCountCoin;
using TestAuto.Application.CQRS.Coins.Queries.GetCointById;
using TestAuto.Application.CQRS.Drinks.Queries.GetDrinkById;

namespace TestAuto.WebAPI.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("deposit")]
        public async Task<IActionResult> DepositCoin([FromQuery] int coinId)
        {
            await _mediator.Send(new DecrementCountCoinCommand(coinId));
            var coin = await   _mediator.Send(new GetCoinByIdRequest(coinId));

            if (HttpContext.Session.Keys.Contains("amount"))
            {
                var amountCoins = HttpContext.Session.GetInt32("amount");
                amountCoins += coin.Denomination;
                HttpContext.Session.SetString("amount", amountCoins.ToString()!);
                return Ok();
            }
            else
            {
                var amountCoins = coin.Denomination;
                HttpContext.Session.SetString("amount", amountCoins.ToString()!);
                return Ok();
            }
        }

        [HttpGet("balance")]
        public IActionResult GetBAlance()
        {
            int balance = 0;
            if (HttpContext.Session.Keys.Contains("amount"))
                balance = (int)HttpContext.Session.GetInt32("amount")!;

            return Ok(balance);
            
        }

        [HttpGet("pay")]
        public async Task<IActionResult> PayDrink([FromQuery] int drinkId)
        {

            
        }
    }
}
