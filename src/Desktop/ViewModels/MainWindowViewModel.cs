using CommunityToolkit.Mvvm.ComponentModel;

namespace Taskhub.Desktop.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public string Greeting { get; } = "Welcome to Avalonia!";
}
