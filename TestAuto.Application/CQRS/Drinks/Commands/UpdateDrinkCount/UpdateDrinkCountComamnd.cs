using MediatR;

namespace TestAuto.Application.CQRS.Drinks.Commands.UpdateDrinkCount
{
    public class UpdateDrinkCountComamnd : IRequest
    {
        public int DrinkId { get; set; }
        public int Count { get; set; }
        public UpdateDrinkCountComamnd() { }

        public UpdateDrinkCountComamnd(int drinkId, int count)
        {
            DrinkId = drinkId;
            Count = count;
        }
    }
}
