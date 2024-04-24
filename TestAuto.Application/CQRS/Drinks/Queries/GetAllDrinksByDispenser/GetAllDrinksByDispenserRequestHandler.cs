using MediatR;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Queries.GetAllDrinksByDispenser
{
    public class GetAllDrinksByDispenserRequestHandler
        : IRequestHandler<GetAllDrinksByDispenserRequest, IEnumerable<Drink>>
    {
        private readonly IDrinkRepository _drinkRepository;

        public GetAllDrinksByDispenserRequestHandler(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task<IEnumerable<Drink>> Handle(
            GetAllDrinksByDispenserRequest request, 
            CancellationToken cancellationToken)
        {
            return await _drinkRepository.GetAllEntity(request.DispenserId);
        }
    }
}
