using MediatR;
using TestAuto.Domain.Models;

namespace TestAuto.Application.CQRS.Coins.Queries.GetAllCoinByDispenser
{
    public class GetAllCoinByDispenserRequest 
        : IRequest<IEnumerable<Coin>>
    {
        public int DispenserId { get; set; }
        public GetAllCoinByDispenserRequest() { }

        public GetAllCoinByDispenserRequest(int dispenserId)
        {
            DispenserId = dispenserId;
        }
    }
}
