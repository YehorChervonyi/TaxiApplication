using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Data.EntityConfigurations;

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

        builder
            .HasMany(x => x.orders)
            .WithOne(x => x.driver)
            .HasForeignKey(x=>x.driverId)
            .HasPrincipalKey(x=>x.id);
        
        builder
            .HasMany(x => x.cars)
            .WithOne(x => x.driver)
            .HasForeignKey(x=>x.driverId)
            .HasPrincipalKey(x=>x.carId);
    }
}