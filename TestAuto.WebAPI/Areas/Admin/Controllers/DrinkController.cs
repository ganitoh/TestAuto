using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAuto.Application.CQRS.Drinks.Commands.CreateDrink;
using TestAuto.Application.CQRS.Drinks.Commands.DeleteDrink;
using TestAuto.Application.CQRS.Drinks.Commands.UpdateDrink;
using TestAuto.WebAPI.Contracts;

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
        public async Task<IActionResult> AddDrink([FromForm] AddDrinkRequest request)
        {
            var fullPathFile = $"{Directory.GetCurrentDirectory()}/wwwroot/img/{request.file.FileName}";
            var relativePath = $"/img/{request.file.FileName}";

            using FileStream stream = new FileStream(fullPathFile, FileMode.Create);
            await request.file.CopyToAsync(stream);

            await _mediator.Send(new CreateDrinkComamnd(
                request.count,request.price,request.name,relativePath,request.dispenserId));
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
