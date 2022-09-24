namespace MauiMemoryGame.Features;

public class GameOverPopupViewModel : BaseViewModel, IQueryAttributable
{
	public GameOverPopupViewModel(INavigationService navigationService, ILogService logService) : base(navigationService, logService)
    {
	}

    public static Themes SelectedTheme { get; internal set; }
    public static Level SelectedLevel { get; internal set; }
    public static bool IsWinner { get; internal set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        SelectedTheme = (Themes)query[nameof(SelectedTheme)];
        SelectedLevel = (Level)query[nameof(SelectedLevel)];
        IsWinner = (bool)query[nameof(IsWinner)];
    }
}

