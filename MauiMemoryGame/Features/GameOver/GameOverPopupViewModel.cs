namespace MauiMemoryGame.Features;

public class GameOverPopupViewModel : BaseViewModel, IQueryAttributable
{
	public GameOverPopupViewModel(INavigationService navigationService, ILogService logService) : base(navigationService, logService)
    {
	}

    public Themes SelectedTheme { get; internal set; }
    public Level SelectedLevel { get; internal set; }
    [Reactive]public bool IsWinner { get; internal set; }

    public ReactiveCommand<Unit, Unit> PlayAgainCommand { get; private set; }
    public extern bool IsGoingToPlayAgain { [ObservableAsProperty] get; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        SelectedTheme = (Themes)query[nameof(SelectedTheme)];
        SelectedLevel = (Level)query[nameof(SelectedLevel)];
        IsWinner = (bool)query[nameof(IsWinner)];
    }

    protected override void HandleActivation(CompositeDisposable disposables)
    {
        base.HandleActivation(disposables);

        PlayAgainCommand.ThrownExceptions.Subscribe(logService.TraceError).DisposeWith(disposables);
        PlayAgainCommand.IsExecuting.ToPropertyEx(this, x => x.IsGoingToPlayAgain).DisposeWith(disposables);
    }

    protected override void CreateCommands()
    {
        base.CreateCommands();
        PlayAgainCommand = ReactiveCommand.CreateFromTask(PlayAgainAsync);
    }

    private Task PlayAgainAsync()
    {
        return navigationService.PlayAgainFromGameOver(SelectedTheme, SelectedLevel);
    }

    protected override Task NavigateBackAsync()
    {
        return navigationService.NavigateBackToStart();
    }
}

