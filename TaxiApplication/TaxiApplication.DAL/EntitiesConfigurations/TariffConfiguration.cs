using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.EntitiesConfigurations;

public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
{
    public void Configure(EntityTypeBuilder<Tariff> builder)
    {
        builder.HasIndex(x => x.id);
        builder.Property(x => x.id).IsRequired();

        builder.Property(x => x.name).IsRequired();
        builder.Property(x => x.name).HasMaxLength(100);
        
        builder.Property(x => x.price).IsRequired();
        
        builder.Property(x => x.fee).IsRequired();
    }
}