using Microsoft.EntityFrameworkCore;
using TestAuto.Domain.Models;
using TestAuto.Infrastructure.EntityConfiguration;

namespace TestAuto.Infrastructure.Services.Repositories.Emplemenatation
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Dispenser> Dispensers { get; set; }
        public DbSet<Coin> Coins   { get; set; }

        public ApplicationContext(DbContextOptions options) 
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureCreated();
            //Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DrinkConfiguration());
            modelBuilder.ApplyConfiguration(new CoinConfiguration());
            modelBuilder.ApplyConfiguration(new DispenserConfiguration());
        }
    }
}
