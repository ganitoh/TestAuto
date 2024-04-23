using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAuto.Domain.Models;

namespace TestAuto.Infrastructure.EntityConfiguration
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.ToTable("coins");
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Denomination);

            builder.HasData(
                new Coin() { Id = 1, Denomination=1,Count = 10 , IsBlock = false, DispenserId = 1 },
                new Coin() { Id = 2, Denomination=2,Count = 10 , IsBlock = false, DispenserId = 1 },
                new Coin() { Id = 3, Denomination=5,Count = 10 , IsBlock = false, DispenserId = 1 },
                new Coin() { Id = 4, Denomination=10,Count = 10 , IsBlock = false, DispenserId = 1 });
        }
    }
}
