using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskhub.Core.Common.Abstractions;
using Taskhub.Core.WorkTasks.Abstractions;
using Taskhub.Core.WorkTasks.Specifications;

namespace Taskhub.Core.WorkTasks.Services;

public class WorkTaskService : IWorkTaskService
{
    private readonly IWorkTaskRepository _workTaskRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public WorkTaskService(IWorkTaskRepository repository, IDateTimeProvider dateTimeProvider)
    {
        _workTaskRepository = repository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ICollection<WorkTask>> GetWorkTasksForToday() => await _workTaskRepository
        .ListAsync(new WorkTaskByDaySpecification(_dateTimeProvider.UtcNow));

    public async Task<ICollection<WorkTask>> GetWorkTasksForDate(DateTime date) => await _workTaskRepository
        .ListAsync(new WorkTaskByDaySpecification(date));

    public async Task<WorkTask?> GetWorkTask(Guid id) => await _workTaskRepository
        .GetByIdAsync(id);

    public async Task<WorkTask?> Create(WorkTask workTask) => await _workTaskRepository
        .AddAsync(workTask);
}
