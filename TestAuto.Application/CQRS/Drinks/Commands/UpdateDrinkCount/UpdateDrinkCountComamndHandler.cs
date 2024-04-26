using MediatR;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Commands.UpdateDrinkCount
{
    public class UpdateDrinkCountComamndHandler 
        : IRequestHandler<UpdateDrinkCountComamnd>
    {
        private readonly IDrinkRepository _drinkRepository;

        public UpdateDrinkCountComamndHandler(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task Handle(
            UpdateDrinkCountComamnd request,
            CancellationToken cancellationToken)
        {
            await _drinkRepository.UpdateDrinkCount(request.DrinkId, request.Count);
        }
    }
}
