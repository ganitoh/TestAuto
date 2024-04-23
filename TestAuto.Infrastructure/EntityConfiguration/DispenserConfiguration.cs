using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAuto.Domain.Models;

namespace TestAuto.Infrastructure.EntityConfiguration
{
    public class DispenserConfiguration : IEntityTypeConfiguration<Dispenser>
    {
        public void Configure(EntityTypeBuilder<Dispenser> builder)
        {
            builder.ToTable("dispensers");
            builder.HasKey(d => d.Id);

            builder
                .HasMany(d => d.Drinks)
                .WithOne(d => d.Dispenser)
                .HasForeignKey(d => d.DispenserId);
            builder
                .HasMany(d=>d.Coins)
                .WithOne(c=>c.Dispenser)
                .HasForeignKey(c=>c.DispenserId);

            builder.HasData(
                new Dispenser() { Id = 1 });
        }
    }
}
