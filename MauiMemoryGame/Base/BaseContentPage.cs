using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace MauiMemoryGame.Base;

public class BaseContentPage<TViewModel> : ReactiveContentPage<TViewModel> where TViewModel : BaseViewModel
{
	public BaseContentPage()
	{
        On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetUseSafeArea(true);

        this.WhenActivated(disposables =>
        {
            HandleActivation(disposables);

            Disposable
                .Create(() => HandleDeactivation())
                .DisposeWith(disposables);
        });
    }

    protected virtual void HandleActivation(CompositeDisposable disposables)
    {
        CreateBindings(disposables);
        ObserveValues(disposables);
        CreateEvents(disposables);
    }

    protected virtual void CreateBindings(CompositeDisposable disposables)
    {
        
    }

    protected virtual void ObserveValues(CompositeDisposable disposables)
    {
        
    }

    protected virtual void CreateEvents(CompositeDisposable disposables)
    {
        
    }

    protected virtual void HandleDeactivation()
    {
        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ViewModel?.OnAppearingAsync();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();

        await ViewModel?.OnDisappearingAsync();
    }
}

