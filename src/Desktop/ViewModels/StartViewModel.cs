using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
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

        NewTask = new RelayCommand(NewTaskCommand);
    }

    public RelayCommand NewTask { get; }

    public Task<ICollection<WorkTask>> WorkTasks => GetWorkTasks();

    private async Task<ICollection<WorkTask>> GetWorkTasks() =>
        await _workTaskService.GetWorkTasksForToday();

    public void NaviateToNewTask() => RequestPage<NewWorkTaskViewModel>();

    private void NewTaskCommand()
    {
        RequestPage<NewWorkTaskViewModel>();
    }
}
