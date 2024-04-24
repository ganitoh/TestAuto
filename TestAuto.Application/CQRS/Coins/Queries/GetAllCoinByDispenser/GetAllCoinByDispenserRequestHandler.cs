using MediatR;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Coins.Queries.GetAllCoinByDispenser
{
    public class GetAllCoinByDispenserRequestHandler
        : IRequestHandler<GetAllCoinByDispenserRequest, IEnumerable<Coin>>
    {
        private readonly ICoinRepository _coinRepository;

        public GetAllCoinByDispenserRequestHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<IEnumerable<Coin>> Handle(
            GetAllCoinByDispenserRequest request,
            CancellationToken cancellationToken)
        {
            return await _coinRepository.GetAllCoinsForDispenserAsync(request.DispenserId);
        }
    }
}
