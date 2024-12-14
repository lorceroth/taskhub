using Avalonia.Controls;
using Taskhub.Desktop.ViewModels;

namespace Taskhub.Desktop.Views;

public partial class StartView : UserControl
{
    public StartView()
    {
        InitializeComponent();
    }

    protected StartViewModel? Model => DataContext as StartViewModel;

    public void OnNewWorkTaskButtonClicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e) =>
        Model!.RequestPage<NewWorkTaskViewModel>();
}
