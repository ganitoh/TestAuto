using MediatR;
using TestAuto.Application.CQRS.Coins.Queries.GetAllCoinByDispenser;
using TestAuto.Application.CQRS.Drinks.Queries.GetDrinkById;
using TestAuto.Application.Exeptions;
using TestAuto.Application.Services.Abstraction;
using TestAuto.Domain.Models;

namespace TestAuto.Application.Services.Emplementation
{
    public class AccountService : IAccountService
    {       
        private readonly IMediator _mediator;

        public AccountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Coin>> PayDrinkAndChangeReturn(int drinkId, int balance)
        {
            var drink = await _mediator.Send(new GetDrinkByIdRequest(drinkId));

            if (drink.Count < 1)
                throw new PaymentFailedException("напитков нет");
            else if(drink.Price == balance)
                throw new PaymentFailedException("недостаточно средств");
            else
            {
                var changeValue = balance - drink.Price;
                return CalculateChange((int)changeValue);
            }
        }

        private async IEnumerable<Coin> CalculateChange(int changeValue,int dispenserId = 1)
        {
            var coinsDispenser = await _mediator.Send(new GetAllCoinByDispenserRequest(dispenserId));
            var coinsChange = new List<Coin>();

            while (changeValue != 0)
            {
                Coin? coin = null;

                if (changeValue >= 10)
                    coin = coinsDispenser.FirstOrDefault(c => c.Denomination == 10)!;
                else if (changeValue < 10 && changeValue >= 5)
                    coin = coinsDispenser.FirstOrDefault(c => c.Denomination == 5)!;
                else if
            }
        }
    }
}
