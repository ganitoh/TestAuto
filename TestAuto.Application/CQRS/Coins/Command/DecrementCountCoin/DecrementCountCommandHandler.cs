using MediatR;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Coins.Command.DecrementCountCoin
{
    public class DecrementCountCommandHandler : IRequestHandler<DecrementCountCoinCommand>
    {
        private readonly ICoinRepository _coinRepository;

        public DecrementCountCommandHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task Handle(
            DecrementCountCoinCommand request, 
            CancellationToken cancellationToken)
        {
            await _coinRepository.UpdateCoinCountDecrementAsync(request.id);
        }
    }
}
