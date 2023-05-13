using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.EntitiesConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasIndex(x => x.id);
        builder.Property(x => x.id).IsRequired();

        builder.Property(x => x.plate).IsRequired();
        builder.Property(x => x.plate).HasMaxLength(50);
        
        builder.Property(x => x.brand).IsRequired();
        builder.Property(x => x.brand).HasMaxLength(100);
        
        builder.Property(x => x.model).IsRequired();
        builder.Property(x => x.model).HasMaxLength(100);
        
        builder.Property(x => x.seats).IsRequired();

        builder
            .HasOne(x => x.driver)
            .WithMany(x => x.cars)
            .HasForeignKey(x=> x.id)
            .HasPrincipalKey(x=> x.carId);
        
        builder
            .HasOne(x => x.tariff)
            .WithMany(x => x.cars)
            .HasForeignKey(x=> x.tariffId)
            .HasPrincipalKey(x=>x.id);
    }
}