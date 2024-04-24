using MediatR;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Queries.GetDrinkById
{
    public class GetDrinkByIdRequestHandler
        : IRequestHandler<GetDrinkByIdRequest, Drink>
    {
        private readonly IDrinkRepository _drinkRepository;

        public GetDrinkByIdRequestHandler(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task<Drink> Handle(
            GetDrinkByIdRequest request, 
            CancellationToken cancellationToken)
        {
            return await _drinkRepository.GetEntity(request.DrinkId);
        }
    }
}
