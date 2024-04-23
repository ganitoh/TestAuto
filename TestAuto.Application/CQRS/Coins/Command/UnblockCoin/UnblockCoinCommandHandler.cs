using MediatR;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Coins.Command.UnblockCoin
{
    public class UnblockCoinCommandHandler : IRequestHandler<UnblockCoinCommand>
    {
        private readonly ICoinRepository _coinRepository;

        public UnblockCoinCommandHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task Handle(
            UnblockCoinCommand request,
            CancellationToken cancellationToken)
        {
            await _coinRepository.UnBlockCoinAsync(request.Id);
        }
    }
}
