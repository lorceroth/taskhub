using Microsoft.Extensions.DependencyInjection;
using Taskhub.Desktop.ViewModels;
using Taskhub.Infrastructure.Persistence;

namespace Taskhub.Desktop.Extensions;

/// <summary>
/// Registers the application services in the service container.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<MainWindowViewModel>();

        services.AddDbContext<ApplicationContext>();
    }
}
