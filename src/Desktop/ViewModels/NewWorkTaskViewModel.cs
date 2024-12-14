using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using Taskhub.Core.WorkTasks.Abstractions;

namespace Taskhub.Desktop.ViewModels;

public partial class NewWorkTaskViewModel : PageViewModelBase
{
    private readonly IWorkTaskService _workTaskService;

    [ObservableProperty] private string _title;
    [ObservableProperty] private string _description;
    [ObservableProperty] private DateTimeOffset? _day = DateTimeOffset.UtcNow;

    public NewWorkTaskViewModel() { }

    public NewWorkTaskViewModel(IWorkTaskService workTaskService)
    {
        _workTaskService = workTaskService;

        Save = new AsyncRelayCommand(SaveCommand);
        Cancel = new RelayCommand(CancelCommand);
    }

    public IAsyncRelayCommand Save { get; }

    public RelayCommand Cancel { get; }

    private async Task SaveCommand()
    {
        await _workTaskService.Create(new()
        {
            Title = Title,
            Description = Description,
            Day = Day!.Value.DateTime.Date,
        });

        ResetForm();

        RequestPage<StartViewModel>();
    }

    private void CancelCommand()
    {
        ResetForm();

        RequestPage<StartViewModel>();
    }

    private void ResetForm()
    {
        Title = "";
        Description = "";
        Day = DateTimeOffset.UtcNow;
    }
}
