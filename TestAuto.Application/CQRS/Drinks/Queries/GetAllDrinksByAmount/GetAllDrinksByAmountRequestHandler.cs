using MediatR;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Queries.GetAllDrinksByAmount
{
    public class GetAllDrinksByAmountRequestHandler
        : IRequestHandler<GetAllDrinksByAmountRequest, IEnumerable<Drink>>
    {
        private readonly IDrinkRepository _DrinkRepository;

        public GetAllDrinksByAmountRequestHandler(IDrinkRepository repository)
        {
            _DrinkRepository = repository;
        }

        public async Task<IEnumerable<Drink>> Handle(
            GetAllDrinksByAmountRequest request, 
            CancellationToken cancellationToken)
        {
            return await _DrinkRepository.GetAllDrinkByAmount(request.DispenserId, request.Amount);
        }
    }
}
