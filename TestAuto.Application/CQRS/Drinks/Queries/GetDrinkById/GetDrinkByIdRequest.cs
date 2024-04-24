using MediatR;
using TestAuto.Domain.Models;

namespace TestAuto.Application.CQRS.Drinks.Queries.GetDrinkById
{
    public class GetDrinkByIdRequest : IRequest<Drink>
    {
        public int DrinkId { get; set; }
        public GetDrinkByIdRequest() { }

        public GetDrinkByIdRequest(int drinkId)
        {
            DrinkId = drinkId;
        }
    }
}
