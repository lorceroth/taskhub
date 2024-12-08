using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Taskhub.Core.Categories;
using Taskhub.Core.Common.Abstractions;
using Taskhub.Core.Projects;
using Taskhub.Core.WorkTasks;
using Taskhub.Infrastructure.Persistence.Configuration;

namespace Taskhub.Infrastructure.Persistence;

/// <summary>
/// The database context of the application.
/// </summary>
public class ApplicationContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<WorkTask> WorkTasks { get; set; }

    public override int SaveChanges()
    {
        SetTimestamps();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var taskhubDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Taskhub");

        if (Directory.Exists(taskhubDataPath) is false)
        {
            Directory.CreateDirectory(taskhubDataPath);
        }

        builder.UseSqlite($"Data Source={Path.Combine(taskhubDataPath, "Taskhub.sqlite")}");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>().Configure();
        builder.Entity<Project>().Configure();
        builder.Entity<WorkTask>().Configure();
    }

    private void SetTimestamps()
    {
        foreach (var (state, entity) in ChangeTracker.Entries()
            .Where(x => x.Entity is ITimestampEntity)
            .Select(x => (x.State, x as ITimestampEntity)))
        {
            switch (state)
            {
                case EntityState.Added:
                    entity!.CreatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entity!.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }
    }
}
