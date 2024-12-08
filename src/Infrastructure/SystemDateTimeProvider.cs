using System;
using Taskhub.Core.Common.Abstractions;

namespace Taskhub.Infrastructure;

/// <summary>
/// This provider uses the built in <see cref="DateTime"/>.
/// </summary>
public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
