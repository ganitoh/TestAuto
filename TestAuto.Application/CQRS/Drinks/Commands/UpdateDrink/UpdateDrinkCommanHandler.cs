using AutoMapper;
using MediatR;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Commands.UpdateDrink
{
    public class UpdateDrinkCommanHandler 
        : IRequestHandler<UpdateDrinkCommand>
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IMapper _mapper;

        public UpdateDrinkCommanHandler(
            IDrinkRepository drinkRepository,
            IMapper mapper)
        {
            _drinkRepository = drinkRepository;
            _mapper = mapper;
        }

        public async Task Handle(
            UpdateDrinkCommand request, 
            CancellationToken cancellationToken)
        {
            var drink = _mapper.Map<Drink>(request);
            await _drinkRepository.UpdateEntity(drink);
        }
    }
}
