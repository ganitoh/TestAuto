using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TestAuto.Domain.Models;

namespace TestAuto.Infrastructure.Services.Repositories.Abstraction
{
    public interface ICoinRepository
    {
        Task<IEnumerable<Coin>> GetAllCoinsForDispenserAsync(int dispenserId);
        Task<Coin> GetCoinAsync(int coinId);
        Task BlockCoinAsync(int coinId);
        Task UnBlockCoinAsync(int coinId);
        Task UpdateCoinCountAsync(int coinId, int count);
        Task UpdateCoinCountDecrementAsync(int coinId);
        Task UpdateCoinCountDecrementAsync(int dispenserId, int denominationCoin);
        Task UpdateCoinCountIncrementAsync(int coinId);

    }
}
