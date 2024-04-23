using MediatR;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Commands.DeleteDrink
{
    public class DeleteDrinkCommandHandler 
        : IRequestHandler<DeleteDrinkCommand>
    {

        private readonly IDrinkRepository _drinkRepository;

        public DeleteDrinkCommandHandler(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task Handle(
            DeleteDrinkCommand request,
            CancellationToken cancellationToken)
        {
            await _drinkRepository.DeleteEntity(request.Id);
        }
    }
}
