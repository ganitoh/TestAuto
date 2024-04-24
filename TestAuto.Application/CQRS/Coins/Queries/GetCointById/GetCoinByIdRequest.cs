using MediatR;
using TestAuto.Domain.Models;

namespace TestAuto.Application.CQRS.Coins.Queries.GetCointById
{
    public class GetCoinByIdRequest : IRequest<Coin>
    {
        public int Id { get; set; }
        public GetCoinByIdRequest() { }

        public GetCoinByIdRequest(int id)
        {
            Id = id;
        }
    }
}
