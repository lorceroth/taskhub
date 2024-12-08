using Ardalis.Specification;

namespace Taskhub.Core.WorkTasks.Abstractions;

/// <summary>
/// The repository used for querying <see cref="WorkTask"/> entities from the configured store.
/// </summary>
public interface IWorkTaskRepository : IRepositoryBase<WorkTask> { }
