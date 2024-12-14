using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using Taskhub.Core.WorkTasks;
using Taskhub.Core.WorkTasks.Abstractions;

namespace Taskhub.Desktop.ViewModels;

public partial class StartViewModel : PageViewModelBase
{
    private readonly IWorkTaskService _workTaskService;

    public StartViewModel() { }

    public StartViewModel(IWorkTaskService workTaskService) : this()
    {
        _workTaskService = workTaskService;
    }

    public ObservableCollection<WorkTask> WorkTasks { get; set; } = new();

    public override void Reloaded()
    {
        RxApp.MainThreadScheduler.Schedule(async () => await LoadWorkTasks());
    }

    private async Task LoadWorkTasks()
    {
        var workTasks = await _workTaskService.GetWorkTasksForToday();

        if (workTasks.Any())
        {
            WorkTasks.Clear();

            foreach (var workTask in workTasks)
            {
                WorkTasks.Add(workTask);
            }
        }
    }
}
