using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Taskhub.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private PageViewModelBase currentPage;

    private List<PageViewModelBase> _views = [];

    public MainWindowViewModel() { }

    public MainWindowViewModel(IServiceProvider services) : this()
    {
        _views.Add(services.GetRequiredService<StartViewModel>());
        _views.Add(services.GetRequiredService<NewWorkTaskViewModel>());

        foreach (var view in _views)
        {
            view.PageRequested += OnPageRequested;
        }

        CurrentPage = _views[0];
        CurrentPage.Reloaded();
    }

    private void OnPageRequested(object? sender, Type e)
    {
        var page = _views.FirstOrDefault(x => x.GetType() == e);

        if (page is not null)
        {
            CurrentPage = page;
            CurrentPage.Reloaded();
        }
    }
}
