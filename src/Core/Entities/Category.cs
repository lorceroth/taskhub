using System;

namespace Taskhub.Core.Entities;

/// <summary>
/// Represents a category that can be used to categorize various work tasks.
/// </summary>
public class Category
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Color { get; set; }
}
