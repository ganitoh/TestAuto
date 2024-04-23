using AutoMapper;
using TestAuto.Application.CQRS.Coins.Command.UpdateCountCoin;
using TestAuto.Application.CQRS.Drinks.Commands.CreateDrink;
using TestAuto.Application.CQRS.Drinks.Commands.UpdateDrink;
using TestAuto.Domain.Models;

namespace TestAuto.Application.CQRS
{
    public class CQRSMapProfile : Profile
    {
        public CQRSMapProfile()
        {
            CreateMap<CreateDrinkComamnd, Drink>();
            CreateMap<UpdateDrinkCommand, Drink>();
        }
    }
}
