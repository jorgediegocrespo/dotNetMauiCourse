namespace MauiMemoryGame.Features;

public class ThemeSelectorViewModel : BaseViewModel
{
	public ThemeSelectorViewModel(INavigationService navigationService, ILogService logService) : base(navigationService, logService)
    {
	}

    public override Task OnAppearingAsync()
    {
        return base.OnAppearingAsync();
    }

    public override Task OnDisappearingAsync()
    {
        return base.OnDisappearingAsync();
    }
}

