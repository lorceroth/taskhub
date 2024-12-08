using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskhub.Core.WorkTasks;

namespace Taskhub.Core.WorkTasks.Abstractions;

/// <summary>
/// A service class used to work with <see cref="WorkTask"/> entities.
/// </summary>
public interface IWorkTaskService
{
    Task<ICollection<WorkTask>> GetWorkTasksForToday();

    Task<ICollection<WorkTask>> GetWorkTasksForDate(DateTime date);

    Task<WorkTask?> GetWorkTask(Guid id);
}
