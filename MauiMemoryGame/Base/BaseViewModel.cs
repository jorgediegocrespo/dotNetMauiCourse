namespace MauiMemoryGame.Base;

public class BaseViewModel : ReactiveObject, IActivatableViewModel
{
	public BaseViewModel()
	{
		CreateCommands();

		Activator = new ViewModelActivator();
		this.WhenActivated(disposables =>
		{
			HandleActivation(disposables);

			Disposable
			.Create(() => HandleDesactivation())
			.DisposeWith(disposables);
		});
	}

    public ViewModelActivator Activator { get; }

    public ReactiveCommand<Unit, Unit> NavigateBackCommand { get; private set; }
    public extern bool IsNavigatingBack { [ObservableAsProperty] get; }

    private void CreateCommands()
    {
        NavigateBackCommand = ReactiveCommand.CreateFromTask(NavigateBackAsync);
    }

    private Task NavigateBackAsync()
    {
        //TODO
        return Task.CompletedTask;
    }

    protected virtual void HandleActivation(CompositeDisposable disposables)
    {
        //TODO NavigateBackCommand.ThrownExceptions.Subscribe(logService.TraceError).DisposeWith(disposables);
        NavigateBackCommand.IsExecuting.ToPropertyEx(this, x => x.IsNavigatingBack).DisposeWith(disposables);
    }

    protected virtual void HandleDesactivation()
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

