using MediatR;

namespace TestAuto.Application.CQRS.Drinks.Queries.GetDrinkPrice
{
    public class GetDrinkPriceRequest : IRequest<decimal>
    {
        public int DrinkId { get; set; }
        public GetDrinkPriceRequest() { }

        public GetDrinkPriceRequest(int drinkId)
        {
            DrinkId = drinkId;
        }
    }
}
