namespace MauiMemoryGame.Features;

[QueryProperty(nameof(SelectedTheme), nameof(SelectedTheme))]
public class LevelSelectorViewModel : BaseViewModel
{
	public LevelSelectorViewModel(INavigationService navigationService, ILogService logService) : base(navigationService, logService)
    {
	}

    public static Themes SelectedTheme { get; private set; }
}

