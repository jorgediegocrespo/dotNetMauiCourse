namespace MauiMemoryGame.Features;

public partial class GameView
{
	public GameView(GameViewModel viewModel)
	{
		ViewModel = viewModel;
		InitializeComponent();
	}
}
