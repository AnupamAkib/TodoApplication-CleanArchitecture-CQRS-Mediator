using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(t => t.UserId)
            .IsUnique();

        builder.HasIndex(t => t.Email)
            .IsUnique();

        builder.Property(t => t.Name)
            .HasMaxLength(50);
    }
}
