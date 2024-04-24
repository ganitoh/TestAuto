using MediatR;
using TestAuto.Domain.Models;

namespace TestAuto.Application.CQRS.Drinks.Queries.GetAllDrinksByDispenser
{
    public class GetAllDrinksByDispenserRequest : IRequest<IEnumerable<Drink>>
    {
        public int DispenserId { get; set; }
        public GetAllDrinksByDispenserRequest(){ }

        public GetAllDrinksByDispenserRequest(int dispenserId)
        {
            DispenserId = dispenserId;
        }
    }
}
