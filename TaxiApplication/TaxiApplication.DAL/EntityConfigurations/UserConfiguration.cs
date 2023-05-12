using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Data.Entities;

namespace Data.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.id);
        builder.Property(x => x.id).IsRequired();

        builder.Property(x => x.name).IsRequired();
        builder.Property(x => x.name).HasMaxLength(100);
        
        builder.Property(x => x.surname).HasMaxLength(100);
        
        builder.Property(x => x.phone).IsRequired();
        
        builder.Property(x => x.login).IsRequired();
        builder.Property(x => x.login).HasMaxLength(100);
        
        builder.Property(x => x.password).IsRequired();
        builder.Property(x => x.password).HasMaxLength(100);

        builder
            .HasMany(x => x.orders)
            .WithOne(x => x.user)
            .HasForeignKey(x=>x.userId)
            .HasPrincipalKey(x=>x.id);
    }
}