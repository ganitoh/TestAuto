﻿using Microsoft.EntityFrameworkCore;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Exceptions;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Infrastructure.Services.Repositories.Emplemenatation
{
    public class CoinRepository : ICoinRepository
    {
        private readonly ApplicationContext _context;

        public CoinRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Coin>> GetAllCoinsForDispenserAsync(int dispenserId)
            => await _context.Coins.AsNoTracking().Where(c=>c.DispenserId==dispenserId).ToListAsync();
        public async Task BlockCoinAsync(int coinId)
        {
            var coin = await _context.Coins.FirstOrDefaultAsync(c=>c.Id == coinId);

            if (coin is null)
                throw new EntityNotFoundException("монета не найдена");

            coin.IsBlock = true;
            await _context.SaveChangesAsync();
        }

        public async Task UnBlockCoinAsync(int coinId)
        {
            var coin = await _context.Coins.FirstOrDefaultAsync(c => c.Id == coinId);

            if (coin is null)
                throw new EntityNotFoundException("монета не найдена");

            coin.IsBlock = false;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoinCountAsync(int coinId, int count)
        {
            var coin = await _context.Coins.FirstOrDefaultAsync(c => c.Id == coinId);

            if (coin is null)
                throw new EntityNotFoundException("монета не найдена");

            coin.Count = count;
            await _context.SaveChangesAsync();

        }

        public async Task UpdateCoinCountDecrementAsync(int coinId)
        {
            var coin = await _context.Coins.FirstOrDefaultAsync(c => c.Id == coinId);

            if (coin is null)
                throw new EntityNotFoundException("монета не найдена");

            coin.Count--;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoinCountIncrementAsync(int coinId)
        {
            var coin = await _context.Coins.FirstOrDefaultAsync(c => c.Id == coinId);

            if (coin is null)
                throw new EntityNotFoundException("монета не найдена");

            coin.Count++;
            await _context.SaveChangesAsync();
        }

        public async Task<Coin> GetCoinAsync(int coinId)
        {
            var coin = await _context.Coins.AsNoTracking().FirstOrDefaultAsync(c => c.Id == coinId);
            if (coin is null)
                throw new EntityNotFoundException("coin not found");

            return coin;
        }

        public async Task UpdateCoinCountDecrementAsync(int dispenserId, int denominationCoin)
        {
            var coin = await _context.Coins
                .FirstOrDefaultAsync(
                c=>c.DispenserId == dispenserId 
                && c.Denomination == denominationCoin);

            if (coin is null)
                throw new EntityNotFoundException("монета с таким наминалом не найдена");

            coin.Count++;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoinCountAsync(int denominationCoin, int count, int dispenserId)
        {
            var coin = await _context.Coins
                .FirstOrDefaultAsync(
                c => c.DispenserId == dispenserId
                && c.Denomination == denominationCoin);

            if (coin is null)
                throw new EntityNotFoundException("монета с таким наминалом не найдена");

            coin.Count = count;
            await _context.SaveChangesAsync();
        }

        public async Task BlockCoinAsync(int denominationCoin, int dispenserId = 1)
        {
            var coin = await _context.Coins
                .FirstOrDefaultAsync(
                c => c.DispenserId == dispenserId
                && c.Denomination == denominationCoin);

            if (coin is null)
                throw new EntityNotFoundException("монета с таким наминалом не найдена");

            coin.IsBlock = true;
            await _context.SaveChangesAsync();
        }

        public async Task UnBlockCoinAsync(int denominationCoin, int dispenserId = 1)
        {
            var coin = await _context.Coins
                .FirstOrDefaultAsync(
                c => c.DispenserId == dispenserId
                && c.Denomination == denominationCoin);

            if (coin is null)
                throw new EntityNotFoundException("монета с таким наминалом не найдена");

            coin.IsBlock = false;
            await _context.SaveChangesAsync();
        }
    }
}
