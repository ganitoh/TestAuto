using AutoMapper;
using MediatR;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Application.CQRS.Drinks.Commands.CreateDrink
{
    public class CreateDrinkCommandHandler 
        : IRequestHandler<CreateDrinkComamnd>
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IMapper _mapper;

        public CreateDrinkCommandHandler(
            IDrinkRepository drinkRepository, 
            IMapper mapper)
        {
            _drinkRepository = drinkRepository;
            _mapper = mapper;
        }

        public async Task Handle(
            CreateDrinkComamnd request, 
            CancellationToken cancellationToken)
        {
            var drinkData = _mapper.Map<Drink>(request);
            await _drinkRepository.CreateEntity(drinkData);
        }
    }
}
