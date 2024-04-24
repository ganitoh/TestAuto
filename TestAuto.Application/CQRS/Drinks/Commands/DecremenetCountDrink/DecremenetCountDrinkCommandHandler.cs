using MediatR;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Commands.DecremenetCountDrink
{
    public class DecremenetCountDrinkCommandHandler 
        : IRequestHandler<DecrementCountDrinkCommand>
    {

        private readonly IDrinkRepository _drinkRepository;

        public DecremenetCountDrinkCommandHandler(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task Handle(
            DecrementCountDrinkCommand request,
            CancellationToken cancellationToken)
        {
            await _drinkRepository.UpdateDrinkCountDecrement(request.DrinkId);
        }
    }
}
