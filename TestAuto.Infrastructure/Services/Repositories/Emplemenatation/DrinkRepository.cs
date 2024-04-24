using Microsoft.EntityFrameworkCore;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.Exceptions;
using TestAuto.Infrastructure.Services.Repositories.Abstraction;

namespace TestAuto.Infrastructure.Services.Repositories.Emplemenatation
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly ApplicationContext _context;

        public DrinkRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateEntity(Drink entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Drinks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var drink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == id);
            if (drink is null)
                throw new EntityNotFoundException("drink not found");

            _context.Drinks.Remove(drink);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Drink>> GetAllEntity()
            => await _context.Drinks.AsNoTracking().ToListAsync();

        public async Task<Drink> GetEntity(int id)
        {
            var drink = await _context.Drinks
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);

            if (drink is null)
                throw new EntityNotFoundException("drink not found");

            return drink;
        }

        public async Task UpdateEntity(Drink entity)
        {
            var drink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == entity.Id);

            if (drink is null)
                throw new EntityNotFoundException("drink not found");

            drink.Name = entity.Name;
            drink.Price = drink.Price;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateDrinkCount(int drinkId, int count)
        {
            var drink = await _context.Drinks.FirstOrDefaultAsync(d=>d.Id == drinkId);
            if (drink is null)
                throw new EntityNotFoundException("drink not found");

            drink.Count = count;
            await _context.SaveChangesAsync();

        }

        public async  Task UpdateDrinkCountDecrement(int drinkId)
        {
            var drink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == drinkId);
            if (drink is null)
                throw new EntityNotFoundException("drink not found");

            drink.Count--;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDrinkCountIncrement(int drinkId)
        {
            var drink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == drinkId);
            if (drink is null)
                throw new EntityNotFoundException("drink not found");

            drink.Count++;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Drink>> GetAllDrinkByAmount(int dispenserId, int amount)
        {
            var drinks = await _context.Drinks
                .AsNoTracking()
                .Where(d => d.DispenserId == dispenserId && d.Price <= amount)
                .ToListAsync<Drink>() ?? [];

            return drinks;

        }

        public async Task<IEnumerable<Drink>> GetAllEntity(int dispenserId)
        {
            var drinks = await _context.Drinks.AsNoTracking()
                .Where(d => d.DispenserId == dispenserId)
                .ToListAsync() ?? [];

            return drinks;
        }
    }
}
