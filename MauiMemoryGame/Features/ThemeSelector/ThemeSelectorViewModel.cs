namespace MauiMemoryGame.Features;

public class ThemeSelectorViewModel : BaseViewModel
{
	public ThemeSelectorViewModel(INavigationService navigationService, ILogService logService) : base(navigationService, logService)
    {
	}

    public ReactiveCommand<Unit, Unit> SelectDcCommand { get; private set; }
    public extern bool IsSelectingDc { [ObservableAsProperty] get; }

    public ReactiveCommand<Unit, Unit> SelectMarvelCommand { get; private set; }
    public extern bool IsSelectingMarvel { [ObservableAsProperty] get; }

    public ReactiveCommand<Unit, Unit> SelectSimpsonsCommand { get; private set; }
    public extern bool IsSelectingSimpsons { [ObservableAsProperty] get; }

    public ReactiveCommand<Unit, Unit> SelectStarWarsCommand { get; private set; }
    public extern bool IsSelectingStarWars { [ObservableAsProperty] get; }

    protected override void HandleActivation(CompositeDisposable disposables)
    {
        base.HandleActivation(disposables);

        SelectDcCommand.IsExecuting.ToPropertyEx(this, x => x.IsSelectingDc).DisposeWith(disposables);
        SelectMarvelCommand.IsExecuting.ToPropertyEx(this, x => x.IsSelectingMarvel).DisposeWith(disposables);
        SelectSimpsonsCommand.IsExecuting.ToPropertyEx(this, x => x.IsSelectingSimpsons).DisposeWith(disposables);
        SelectStarWarsCommand.IsExecuting.ToPropertyEx(this, x => x.IsSelectingStarWars).DisposeWith(disposables);

        SelectDcCommand.ThrownExceptions.Subscribe(logService.TraceError).DisposeWith(disposables);
        SelectMarvelCommand.ThrownExceptions.Subscribe(logService.TraceError).DisposeWith(disposables);
        SelectSimpsonsCommand.ThrownExceptions.Subscribe(logService.TraceError).DisposeWith(disposables);
        SelectStarWarsCommand.ThrownExceptions.Subscribe(logService.TraceError).DisposeWith(disposables);
    }

    protected override void CreateCommands()
    {
        base.CreateCommands();

        SelectDcCommand = ReactiveCommand.CreateFromTask(SelectDcAsync);
        SelectMarvelCommand = ReactiveCommand.CreateFromTask(SelectMarvelAsync);
        SelectSimpsonsCommand = ReactiveCommand.CreateFromTask(SelectSimpsonsAsync); 
        SelectStarWarsCommand = ReactiveCommand.CreateFromTask(SelectStarWarsAsync); 
    }

    private Task SelectStarWarsAsync()
    {
        return navigationService.NavigateToLevelSelection(Themes.StarWars);
    }

    private Task SelectSimpsonsAsync()
    {
        return navigationService.NavigateToLevelSelection(Themes.Simpsons);
    }

    private Task SelectMarvelAsync()
    {
        return navigationService.NavigateToLevelSelection(Themes.Marvel);
    }

    private Task SelectDcAsync()
    {
        return navigationService.NavigateToLevelSelection(Themes.DC);
    }
}

