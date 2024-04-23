using MediatR;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Coins.Command.BlockCoin
{
    public class BlockCoinCommandHandler : IRequestHandler<BlockCoinCommand>
    {
        private readonly ICoinRepository _coinRepository;

        public BlockCoinCommandHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task Handle(
            BlockCoinCommand request, 
            CancellationToken cancellationToken)
        {
            await _coinRepository.BlockCoinAsync(request.Id);
        }
    }
}
