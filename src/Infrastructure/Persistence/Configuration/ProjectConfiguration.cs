using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskhub.Core.Projects;
using Taskhub.Infrastructure.Persistence.Extensions;

namespace Taskhub.Infrastructure.Persistence.Configuration;

/// <summary>
/// Configures the <see cref="Project"/> Entity Framework model.
/// </summary>
public static class ProjectConfiguration
{
    public static void Configure(this EntityTypeBuilder<Project> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(255);
        builder.Property(x => x.Color).HasMaxLength(7);
        builder.Property(x => x.CustomAttributes).HasJsonConversion();
    }
}
