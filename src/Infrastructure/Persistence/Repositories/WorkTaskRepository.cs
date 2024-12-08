using Ardalis.Specification.EntityFrameworkCore;
using Taskhub.Core.WorkTasks;
using Taskhub.Core.WorkTasks.Abstractions;

namespace Taskhub.Infrastructure.Persistence.Repositories;

/// <summary>
/// The Entity Framework repository for the <see cref="WorkTask"/> entities.
/// </summary>
public class WorkTaskRepository : RepositoryBase<WorkTask>, IWorkTaskRepository
{
    public WorkTaskRepository(ApplicationContext context)
        : base(context) { }
}
