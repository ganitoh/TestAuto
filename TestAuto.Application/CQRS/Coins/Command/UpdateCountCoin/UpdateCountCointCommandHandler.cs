using MediatR;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Coins.Command.UpdateCountCoin
{
    public class UpdateCountCointCommandHandler
        : IRequestHandler<UpdateCountCoinCommand>
    {
        private readonly ICoinRepository _coinRepository;

        public UpdateCountCointCommandHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task Handle(
            UpdateCountCoinCommand request, 
            CancellationToken cancellationToken)
        {
            await _coinRepository.UpdateCoinCountAsync(request.CoinId, request.Count);
        }
    }
}
