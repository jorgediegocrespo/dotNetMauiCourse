namespace MauiMemoryGame.Features;

public class GameViewModel : BaseViewModel, IQueryAttributable
{
	public GameViewModel(INavigationService navigationService, ILogService logService) : base(navigationService, logService)
	{
	}

    public static Themes SelectedTheme { get; private set; }
    public static Level SelectedLevel { get; private set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        SelectedTheme = (Themes)query[nameof(SelectedTheme)];
        SelectedLevel = (Level)query[nameof(SelectedLevel)];
    }
}

