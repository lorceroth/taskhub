using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Taskhub.Infrastructure.Persistence.Extensions;

/// <summary>
/// Extensions of the <see cref="PropertyBuilder{TProperty}"/> type.
/// </summary>
public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> HasJsonConversion<TProperty>(this PropertyBuilder<TProperty> builder) => builder
        .HasConversion(value => JsonSerializer.Serialize(value, JsonSerializerOptions.Default),
            value => JsonSerializer.Deserialize<TProperty>(value, JsonSerializerOptions.Default));
}
