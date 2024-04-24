using MediatR;

namespace TestAuto.Application.CQRS.Drinks.Commands.DecremenetCountDrink
{
    public class DecrementCountDrinkCommand : IRequest
    {
        public int DrinkId { get; set; }
        public DecrementCountDrinkCommand() { }

        public DecrementCountDrinkCommand(int drinkId)
        {
            DrinkId = drinkId;
        }
    }
}
