using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAuto.Application.CQRS.Drinks.Commands.CreateDrink;

namespace TestAuto.WebAPI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/home")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("index/{token}")]
        public IActionResult Index([FromServices] IWebHostEnvironment environment)
        {
            var filepath = Path.Combine(environment.WebRootPath, "html", "AdminPanel.html");
            var contentType = "text/html";
            return PhysicalFile(filepath, contentType);
        }
    }
}
