using MediatR;using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Coins.Command.IncrementCountCoin
{
    public class IncrementCountCoinCommandHandler
        : IRequestHandler<IncrementCountCoinCommand>
    {
        private readonly ICoinRepository _coinRepository;

        public IncrementCountCoinCommandHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public Task Handle(IncrementCountCoinCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
