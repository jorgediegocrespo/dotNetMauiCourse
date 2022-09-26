using System.Reactive.Linq;
using System.Windows.Input;

namespace MauiMemoryGame.Controls;

public partial class CardView
{
    public static readonly BindableProperty CardProperty = BindableProperty.Create(nameof(Card), typeof(Card), typeof(CardView), propertyChanged: CardChanged);
    public event EventHandler Clicked;

    public CardView()
	{
		InitializeComponent();
	}

    public bool IsShowingContent => frContent.IsVisible;

    public Card Card
    {
        get => (Card)GetValue(CardProperty);
        set => SetValue(CardProperty, value);
    }

    public async Task ShowContent()
    {
        frContent.RotationY = -270;
        await frBack.RotateYTo(-90);
        frBack.IsVisible = false;
        frContent.IsVisible = true;
        await frContent.RotateYTo(-360);
        frContent.RotationY = 0;
    }

    public async Task HideContent()
    {
        frBack.RotationY = -270;
        await frContent.RotateYTo(-90);
        frContent.IsVisible = false;
        frBack.IsVisible = true;
        await frBack.RotateYTo(-360);
        frBack.RotationY = 0;
    }

    protected override void CreateEvents(CompositeDisposable disposables)
    {
        base.CreateEvents(disposables);

        Observable
            .FromEventPattern(h => tapContent.Tapped += h, h => tapContent.Tapped -= h)
            .Subscribe(x => Clicked?.Invoke(this, null))
            .DisposeWith(disposables);

        Observable
            .FromEventPattern(h => tapBack.Tapped += h, h => tapBack.Tapped -= h)
            .Subscribe(x => Clicked?.Invoke(this, null))
            .DisposeWith(disposables);
    }

    private static void CardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        Card newCard = newValue as Card;
        ((CardView)bindable).imgContent.Source = newCard != null ?
            ImageSource.FromFile(newCard.ImagePath) :
            null;
    }
}
