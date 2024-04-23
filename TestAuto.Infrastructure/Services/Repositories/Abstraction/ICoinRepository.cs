using TestAuto.Domain.Models;

namespace TestAuto.Infrastructure.Services.Repositories.Abstraction
{
    public interface ICoinRepository
    {
        Task<IEnumerable<Coin>> GetAllCoinsForDispenserAsync(int dispenserId);
        Task BlockCoinAsync(int coinId);
        Task UnBlockCoinAsync(int coinId);
        Task UpdateCoinCountAsync(int coinId, int count);
        Task UpdateCoinCountDecrementAsync(int coinId);
        Task UpdateCoinCountIncrementAsync(int coinId);

    }
}
