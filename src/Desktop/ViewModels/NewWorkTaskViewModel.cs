using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using Taskhub.Core.WorkTasks.Abstractions;

namespace Taskhub.Desktop.ViewModels;

public partial class NewWorkTaskViewModel : PageViewModelBase
{
    private IWorkTaskService _workTaskService;

    public NewWorkTaskViewModel() { }

    public NewWorkTaskViewModel(IWorkTaskService workTaskService)
    {
        _workTaskService = workTaskService;

        SaveCommand = ReactiveCommand.CreateFromTask(Save);
        CancelCommand = ReactiveCommand.Create(Cancel);
    }

    public ReactiveCommand<Unit, Unit> SaveCommand { get; }

    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    private DateTimeOffset? day = DateTimeOffset.UtcNow;

    public override void Reloaded()
    {
        Title = "";
        Description = "";
        Day = DateTimeOffset.UtcNow;
    }

    private async Task Save()
    {
        await _workTaskService.Create(new()
        {
            Title = Title,
            Description = Description,
            Day = Day.Value.DateTime.Date,
        });

        RequestPage<StartViewModel>();
    }

    private void Cancel() => RequestPage<StartViewModel>();
}
