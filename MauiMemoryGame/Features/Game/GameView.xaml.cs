namespace MauiMemoryGame.Features;

public partial class GameView
{
	public GameView(GameViewModel viewModel)
	{
		ViewModel = viewModel;
		InitializeComponent();

        cvTest.Card = new Card() { Found = false, ImagePath = "dc_1.jpg" };
#if ANDROID
        cvTest.Clicked += CvTest_Clicked;
#else
        cvTestTap.Tapped += CvTest_Clicked;
#endif

    }

    protected override void HandleActivation(CompositeDisposable disposables)
    {
        base.HandleActivation(disposables);
        cvTest.HandleActivation(disposables);
    }

    protected override void HandleDeactivation()
    {
        base.HandleDeactivation();
        cvTest.HandleDeactivation();
    }

    private async void CvTest_Clicked(object sender, EventArgs e)
    {
        await cvTest.ShowContent();
        await Task.Delay(2000);
        await cvTest.HideContent();
    }
}
