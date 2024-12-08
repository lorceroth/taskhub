using System;
using System.Collections.Generic;
using Taskhub.Core.Categories;
using Taskhub.Core.Common.Abstractions;
using Taskhub.Core.Projects;

namespace Taskhub.Core.WorkTasks;

/// <summary>
/// Represents a work task that can be added to a specified day.
/// </summary>
public class WorkTask : ITimestampEntity
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public IDictionary<string, string> CustomAttributes { get; set; } = new Dictionary<string, string>();

    public Project? Project { get; set; }

    public Guid? ProjectId { get; set; }

    public Category? Category { get; set; }

    public Guid? CategoryId { get; set; }

    public TimeSpan TimeSpent { get; set; }

    public DateTime Day { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
