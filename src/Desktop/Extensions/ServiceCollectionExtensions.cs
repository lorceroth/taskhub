using Microsoft.Extensions.DependencyInjection;
using Taskhub.Core.Common.Abstractions;
using Taskhub.Core.WorkTasks.Abstractions;
using Taskhub.Core.WorkTasks.Services;
using Taskhub.Desktop.ViewModels;
using Taskhub.Infrastructure;
using Taskhub.Infrastructure.Persistence;
using Taskhub.Infrastructure.Persistence.Repositories;

namespace Taskhub.Desktop.Extensions;

/// <summary>
/// Registers the application services in the service container.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddViews();
        services.AddInfrastructure();
        services.AddWorkTasks();
    }

    private static void AddViews(this IServiceCollection services)
    {
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<StartViewModel>();
        services.AddTransient<NewWorkTaskViewModel>();
    }

    private static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>();
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
    }

    private static void AddWorkTasks(this IServiceCollection services)
    {
        services.AddSingleton<IWorkTaskRepository, WorkTaskRepository>();
        services.AddSingleton<IWorkTaskService, WorkTaskService>();
    }
}
