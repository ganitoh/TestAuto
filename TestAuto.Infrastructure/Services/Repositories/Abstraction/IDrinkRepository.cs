using TestAuto.Domain.Models;

namespace TestAuto.Infrastructure.Services.Repositories.Abstraction
{
    public interface IDrinkRepository 
        : IRepository<Drink>
    {
        Task UpdateDrinkCount(int drinkId, int count);
        Task UpdateDrinkCountIncrement(int drinkId);
        Task UpdateDrinkCountDecrement(int drinkId);
        Task<IEnumerable<Drink>> GetAllDrinkByAmount(int dispenserId,int amount);
        Task<IEnumerable<Drink>> GetAllEntity(int dispenserId);
    }
}
