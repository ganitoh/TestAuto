using TestAuto.Domain.Models;

namespace TestAuto.Application.Services.Abstraction
{
    public interface IAccountService
    {
        Task<IEnumerable<int>> PayDrinkAndChangeReturn(int drinkId, int balance);
    }
}
