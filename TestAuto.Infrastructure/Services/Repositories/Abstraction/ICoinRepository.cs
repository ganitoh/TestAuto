using TestAuto.Domain.Models;

namespace TestAuto.Infrastructure.Services.Repositories.Abstraction
{
    public interface ICoinRepository
    {
        Task<IEnumerable<Coin>> GetAllCoinsForDispenserAsync(int dispenserId);
        Task<Coin> GetCoinAsync(int coinId);
        Task BlockCoinAsync(int coinId);
        Task BlockCoinAsync(int denominationCoin, int dispenserId = 1);
        Task UnBlockCoinAsync(int coinId);
        Task UnBlockCoinAsync(int denominationCoin, int dispenserId = 1);
        Task UpdateCoinCountAsync(int coinId, int count);
        Task UpdateCoinCountAsync(int denominationCoin, int count,int dispenserId);
        Task UpdateCoinCountDecrementAsync(int coinId);
        Task UpdateCoinCountDecrementAsync(int dispenserId, int denominationCoin);
        Task UpdateCoinCountIncrementAsync(int coinId);

    }
}
