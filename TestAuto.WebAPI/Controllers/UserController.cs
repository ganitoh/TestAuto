using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAuto.Application.CQRS.Coins.Command.DecrementCountCoin;
using TestAuto.Application.CQRS.Coins.Queries.GetCointById;
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
        public async Task<IActionResult> DepositCoin([FromQuery] int coinId)
        {
            await _mediator.Send(new DecrementCountCoinCommand(coinId));
            var coin = await   _mediator.Send(new GetCoinByIdRequest(coinId));

            if (HttpContext.Session.Keys.Contains("balance"))
            {
                var amountCoins = HttpContext.Session.GetInt32("balance");
                amountCoins += coin.Denomination;
                HttpContext.Session.SetString("balance", amountCoins.ToString()!);
                return Ok();
            }
            else
            {
                var amountCoins = coin.Denomination;
                HttpContext.Session.SetString("balance", amountCoins.ToString()!);
                return Ok();
            }
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            int balance = 0;
            if (HttpContext.Session.Keys.Contains("balance"))
                balance = (int)HttpContext.Session.GetInt32("balance")!;

            return Ok(balance);
            
        }

        [HttpGet("pay")]
        public async Task<IActionResult> PayDrink([FromQuery] int drinkId)
        {
            if (HttpContext.Session.Keys.Contains("balance"))
            {
                var balance = (int)HttpContext.Session.GetInt32("balance")!;
                var changeCoin = await _accountService.PayDrinkAndChangeReturn(drinkId, balance);
                return Ok(new {change = changeCoin, drinkid = drinkId});
            }
            else
                return BadRequest(new { message = "пополните баланс" });
        }
    }
}
