
using MediatR;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Coins.Queries.GetCointById
{
    public class GetCoinByIdRequestHandler : IRequestHandler<GetCoinByIdRequest, Coin>
    {
        private readonly ICoinRepository _coinRepository;

        public GetCoinByIdRequestHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<Coin> Handle(
            GetCoinByIdRequest request,
            CancellationToken cancellationToken)
        {
            return await _coinRepository.GetCoinAsync(request.Id);
        }
    }
}
