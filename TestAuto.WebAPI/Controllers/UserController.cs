using Microsoft.AspNetCore.Mvc;
using TestAuto.Domain.Models;

namespace TestAuto.WebAPI.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        [HttpGet("deposit")]
        public IActionResult DepositCoin([FromQuery] Coin coin)
        {

        }
    }
}
