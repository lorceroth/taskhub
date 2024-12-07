using System;
using System.Collections.Generic;

namespace Taskhub.Core.Entities;

/// <summary>
/// Represents a project that can be used to group related work tasks together.
/// </summary>
public class Project : ITimestampEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Color { get; set; }

    public IDictionary<string, string> CustomAttributes { get; set; } = new Dictionary<string, string>();

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
