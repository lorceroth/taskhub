using System;

namespace Taskhub.Desktop.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public event EventHandler<Type> PageRequested;

    public void RequestPage<TPage>() where TPage : PageViewModelBase =>
        PageRequested.Invoke(this, typeof(TPage));
}
