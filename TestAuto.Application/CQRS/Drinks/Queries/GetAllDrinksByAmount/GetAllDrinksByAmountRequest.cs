using MediatR;
using TestAuto.Domain.Models;

namespace TestAuto.Application.CQRS.Drinks.Queries.GetAllDrinksByAmount
{
    public class GetAllDrinksByAmountRequest 
        : IRequest<IEnumerable<Drink>>
    {
        public int DispenserId { get; set; }
        public int Amount { get; set; }
        public GetAllDrinksByAmountRequest() { }

        public GetAllDrinksByAmountRequest(int dispenserId, int amount)
        {
            DispenserId = dispenserId;
            Amount = amount;
        }
    }
}
