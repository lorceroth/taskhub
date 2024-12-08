using System;

namespace Taskhub.Core.Common.Abstractions;

/// <summary>
/// This class provides an abstraction for built in <see cref="DateTime"/> type.
/// </summary>
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
