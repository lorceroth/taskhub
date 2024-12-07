using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskhub.Core.Entities;

namespace Taskhub.Infrastructure.Persistence.Configuration;

/// <summary>
/// Configures the <see cref="Category"/> Entity Framework model.
/// </summary>
public static class CategoryConfiguration
{
    public static void Configure(this EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(255);
        builder.Property(x => x.Color).HasMaxLength(7);
    }
}
