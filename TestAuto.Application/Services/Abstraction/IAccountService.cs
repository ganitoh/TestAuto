using TestAuto.Domain.Models;

namespace TestAuto.Application.Services.Abstraction
{
    public interface IAccountService
    {
        Task<IEnumerable<Coin>> PayDrinkAndChangeReturn(int drinkId, int balance);
    }
}
