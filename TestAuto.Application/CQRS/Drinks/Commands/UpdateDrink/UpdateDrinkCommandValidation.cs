using FluentValidation;

namespace TestAuto.Application.CQRS.Drinks.Commands.UpdateDrink
{
    public sealed class UpdateDrinkCommandValidation
        : AbstractValidator<UpdateDrinkCommand>
    {
        public UpdateDrinkCommandValidation()
        {
            RuleFor(d => d.Price).NotEmpty().GreaterThan(0);
            RuleFor(d => d.Count).NotEmpty().GreaterThan(-1);
            RuleFor(d => d.RelativePathPicture).NotEmpty();
        }
    }
}
