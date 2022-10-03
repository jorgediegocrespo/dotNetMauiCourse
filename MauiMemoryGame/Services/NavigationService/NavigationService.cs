namespace MauiMemoryGame.Services;

public class NavigationService : INavigationService
{
    public Task NavigateBack()
    {
        return Shell.Current.GoToAsync("..", false);
    }

    public Task NavigateBackToStart()
    {
        return Shell.Current.Navigation.PopToRootAsync(false);
    }

    public Task NavigateToGame(Themes selectedTheme, Level selectedLevel)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(GameViewModel.SelectedTheme), selectedTheme },
            { nameof(GameViewModel.SelectedLevel), selectedLevel }
        };

        return Shell.Current.GoToAsync(nameof(GameView), navigationParameter);
    }

    public Task NavigateToGameOverPopup(Themes selectedTheme, Level selectedLevel, bool isWinner)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(GameOverPopupViewModel.SelectedTheme), selectedTheme },
            { nameof(GameOverPopupViewModel.SelectedLevel), selectedLevel },
            { nameof(GameOverPopupViewModel.IsWinner), isWinner }
        };

        return Shell.Current.GoToAsync(nameof(GameOverPopupView), navigationParameter);
    }

    public Task NavigateToLevelSelection(Themes selectedTheme)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(LevelSelectorViewModel.SelectedTheme), selectedTheme }
        };

        return Shell.Current.GoToAsync(nameof(LevelSelectorView), navigationParameter);
    }

    public async Task PlayAgainFromGameOver(Themes selectedTheme, Level selectedLevel)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(GameViewModel.SelectedTheme), selectedTheme },
            { nameof(GameViewModel.SelectedLevel), selectedLevel }
        };

        RemovePreviousPage();
        await Shell.Current.GoToAsync($"../{nameof(GameView)}", navigationParameter);        
    }

    private void RemovePreviousPage()
    {
        Page pageToRemove = Shell.Current.Navigation.NavigationStack[Shell.Current.Navigation.NavigationStack.Count - 2];
        Shell.Current.Navigation.RemovePage(pageToRemove);
    }
}

