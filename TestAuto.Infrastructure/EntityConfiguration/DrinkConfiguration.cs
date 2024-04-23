using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAuto.Domain.Models;

namespace TestAuto.Infrastructure.EntityConfiguration
{
    internal class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.ToTable("drinks");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Price).IsRequired();
            builder.Property(d => d.Count).IsRequired();
        }
    }
}
