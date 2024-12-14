using Ardalis.Specification;
using System;

namespace Taskhub.Core.WorkTasks.Specifications;

/// <summary>
/// This specification enables filtering <see cref="WorkTask"/> entities by their date.
/// </summary>
public class WorkTaskByDaySpecification : Specification<WorkTask>
{
    public WorkTaskByDaySpecification(DateTime day) => Query
        .Where(x => x.Day.Date == day.Date)
        .OrderBy(x => x.Day);
}
