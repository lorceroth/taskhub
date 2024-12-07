using System;

namespace Taskhub.Core.Entities;

/// <summary>
/// Represents an entity that records its creation and update dates.
/// </summary>
public interface ITimestampEntity
{
    DateTime CreatedAt { get; set; }

    DateTime? UpdatedAt { get; set; }
}
