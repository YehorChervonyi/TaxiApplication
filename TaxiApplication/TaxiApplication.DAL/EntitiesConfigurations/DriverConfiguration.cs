using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.EntitiesConfigurations;

public class DriverConfiguration: IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasIndex(x => x.id);
        builder.Property(x => x.id).IsRequired();
        
        builder.Property(x => x.name).IsRequired();
        builder.Property(x => x.name).HasMaxLength(100);
        
        builder.Property(x => x.surname).IsRequired();
        builder.Property(x => x.surname).HasMaxLength(100);
    }
}