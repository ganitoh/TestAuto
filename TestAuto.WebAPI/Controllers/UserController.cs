using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAuto.Application.CQRS.Coins.Command.DecrementCountCoin;
using TestAuto.Application.CQRS.Drinks.Queries.GetDrinkPrice;
using TestAuto.Application.Services.Abstraction;

namespace TestAuto.WebAPI.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;

        public UserController(
            IMediator mediator, 
            IAccountService accountService)
        {
            _mediator = mediator;
            _accountService = accountService;
        }

        [HttpGet("deposit")]
        public async Task<IActionResult> DepositCoin([FromQuery] int denominationCoin)
        {
            await _mediator.Send(new DecrementCountCoinCommand(denominationCoin));

            if (HttpContext.Session.Keys.Contains("balance"))
            {
                var amountCoins = Convert.ToInt32(HttpContext.Session.GetString("balance"));
                amountCoins += denominationCoin;
                HttpContext.Session.SetString("balance", amountCoins.ToString()!);
                return Ok();
            }
            else
            {
                HttpContext.Session.SetString("balance", denominationCoin.ToString()!);
                return Ok();
            }
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            int balance = 0;
            if (HttpContext.Session.Keys.Contains("balance"))
                balance = Convert.ToInt32(HttpContext.Session.GetString("balance")!);

            return Ok(new { balance = balance});
            
        }

        [HttpGet("pay")]
        public async Task<IActionResult> PayDrink([FromQuery] int drinkId)
        {
            if (HttpContext.Session.Keys.Contains("balance"))
            {
                var balance = Convert.ToInt32(HttpContext.Session.GetString("balance"));
                var changeCoin = await _accountService.PayDrinkAndChangeReturn(drinkId,  balance);
                var priceDrink = await _mediator.Send(new GetDrinkPriceRequest(drinkId));
                balance -= (int)priceDrink;
                HttpContext.Session.SetString("balance",balance.ToString()!);
                return Ok(new {change = changeCoin, drinkid = drinkId});
            }
            else
                return BadRequest(new { message = "пополните баланс" });
        }
    }
}
