using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.DAL.EntitiesConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasIndex(x => x.id);
        builder.Property(x => x.id).IsRequired();
        
        builder.Property(x => x.start).IsRequired();
        builder.Property(x => x.start).HasMaxLength(500);
        
        builder.Property(x => x.finish).IsRequired();
        builder.Property(x => x.finish).HasMaxLength(500);
        
        builder.Property(x => x.status).IsRequired();

        builder
            .HasOne(x => x.user)
            .WithMany(x => x.orders)
            .HasForeignKey(x=>x.userId)
            .HasPrincipalKey(x=>x.id);

        builder
            .HasOne(x => x.driver)
            .WithMany(x => x.orders)
            .HasForeignKey(x=>x.driverId)
            .HasPrincipalKey(x=>x.id);
    }
}