using MediatR;
using Microsoft.AspNetCore.Components;
using TestAuto.Application.CQRS.Coins.Command.DecrementCountCoin;
using TestAuto.Application.CQRS.Coins.Queries.GetAllCoinByDispenser;
using TestAuto.Application.CQRS.Drinks.Commands.DecremenetCountDrink;
using TestAuto.Application.CQRS.Drinks.Queries.GetDrinkById;
using TestAuto.Application.Exeptions;
using TestAuto.Application.Services.Abstraction;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Exceptions;

namespace TestAuto.Application.Services.Emplementation
{
    public class AccountService : IAccountService
    {       
        private readonly IMediator _mediator;

        public AccountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<int>> PayDrinkAndChangeReturn(int drinkId, int balance)
        {
            var drink = await _mediator.Send(new GetDrinkByIdRequest(drinkId));

            if (drink.Count < 1)
                throw new PaymentFailedException("напитков нет");
            else if(drink.Price > balance)
                throw new PaymentFailedException("недостаточно средств");
            else
            {
                await _mediator.Send(new DecrementCountDrinkCommand(drinkId));
                var changeValue = balance - drink.Price;
                return await CalculateChangeAsync((int)changeValue);
            }
        }

        private async Task<IEnumerable<int>> CalculateChangeAsync(int changeValue,int dispenserId = 1)
        {
            var coinsDispenser = await _mediator.Send(new GetAllCoinByDispenserRequest(dispenserId));
            var coinsChange = new List<int>();

            while (changeValue > 0)
            {
                Coin? coin = null;

                if (changeValue >= 10)
                    coin = coinsDispenser.FirstOrDefault(c => c.Count > 0 && c.Denomination ==10)!;
                else if (changeValue >= 5 && changeValue < 10)
                    coin = coinsDispenser.FirstOrDefault(c => c.Count > 0 && c.Denomination == 5)!;
                else if (changeValue >= 2 && changeValue < 5)
                    coin = coinsDispenser.FirstOrDefault(c => c.Count > 0 && c.Denomination == 2)!;
                else if (changeValue == 1 )
                    coin = coinsDispenser.FirstOrDefault(c => c.Count > 0 && c.Denomination == 1)!;

                if (coin is null)
                    throw new EntityNotFoundException("монеты не найдены");

                changeValue -= coin.Denomination;
                coinsChange.Add(coin.Denomination);
                await _mediator.Send(new DecrementCountCoinCommand(coin.Denomination));
            }

            return coinsChange;
        }
    }
}
