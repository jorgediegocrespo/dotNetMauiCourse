namespace MauiMemoryGame.Base;

public class BaseViewModel : ReactiveObject, IActivatableViewModel
{
    protected readonly INavigationService navigationService;
    protected readonly ILogService logService;

    public BaseViewModel(INavigationService navigationService, ILogService logService)
	{
		CreateCommands();

		Activator = new ViewModelActivator();
		this.WhenActivated(disposables =>
		{
			HandleActivation(disposables);

			Disposable
			.Create(() => HandleDeactivation())
			.DisposeWith(disposables);
		});
        this.navigationService = navigationService;
        this.logService = logService;
    }

    public ViewModelActivator Activator { get; }

    public ReactiveCommand<Unit, Unit> NavigateBackCommand { get; private set; }
    public extern bool IsNavigatingBack { [ObservableAsProperty] get; }

    protected virtual void CreateCommands()
    {
        NavigateBackCommand = ReactiveCommand.CreateFromTask(NavigateBackAsync);
    }

    protected virtual Task NavigateBackAsync()
    {
        return navigationService.NavigateBack();
    }

    protected virtual void HandleActivation(CompositeDisposable disposables)
    {
        NavigateBackCommand.ThrownExceptions.Subscribe(logService.TraceError).DisposeWith(disposables);
        NavigateBackCommand.IsExecuting.ToPropertyEx(this, x => x.IsNavigatingBack).DisposeWith(disposables);
    }

    protected virtual void HandleDeactivation()
    {
        
    }

    public virtual Task OnAppearingAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnDisappearingAsync()
    {
        return Task.CompletedTask;
    }
}

