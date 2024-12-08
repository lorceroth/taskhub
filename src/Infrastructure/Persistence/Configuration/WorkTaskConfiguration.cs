using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskhub.Core.WorkTasks;
using Taskhub.Infrastructure.Persistence.Extensions;

namespace Taskhub.Infrastructure.Persistence.Configuration;

/// <summary>
/// Configures the <see cref="WorkTask"/> Entity Framework model.
/// </summary>
public static class WorkTaskConfiguration
{
    public static void Configure(this EntityTypeBuilder<WorkTask> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.CustomAttributes).HasJsonConversion();
    }
}
