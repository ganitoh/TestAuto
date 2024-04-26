using MediatR;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Queries.GetDrinkPrice
{
    public class GetDrinkPriceRequestHandler
        : IRequestHandler<GetDrinkPriceRequest, decimal>
    {
        private readonly IDrinkRepository _drinkRepository;

        public GetDrinkPriceRequestHandler(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task<decimal> Handle(
            GetDrinkPriceRequest request,
            CancellationToken cancellationToken)
        {
            var drink = await _drinkRepository.GetEntity(request.DrinkId);
            return drink.Price;
        }
    }
}
