using FluentValidation;

namespace TestAuto.Application.CQRS.Drinks.Commands.CreateDrink
{
    public class CreateDrinkCommandValidation 
        : AbstractValidator<CreateDrinkComamnd>
    {
        public CreateDrinkCommandValidation()
        {
            RuleFor(d=>d.Name).NotEmpty();
            RuleFor(d=>d.Price).NotEmpty().GreaterThan(0);
            RuleFor(d=>d.Count).NotEmpty().GreaterThan(0);
        }
    }
}
