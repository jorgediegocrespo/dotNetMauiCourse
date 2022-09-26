namespace MauiMemoryGame.Features;

public partial class LevelSelectorView
{
	public LevelSelectorView(LevelSelectorViewModel viewModel)
	{
		ViewModel = viewModel;
		InitializeComponent();
	}

    protected override void CreateBindings(CompositeDisposable disposables)
    {
        base.CreateBindings(disposables);

        this.OneWayBind(ViewModel, vm => vm.SelectHighCommand, v => v.btHigh.Command).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.SelectMediumCommand, v => v.btMedium.Command).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.SelectLowCommand, v => v.btLow.Command).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.NavigateBackCommand, v => v.btBack.Command).DisposeWith(disposables);

        this.OneWayBind(ViewModel, vm => vm.IsSelectingHigh, v => v.btHigh.IsBusy).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.IsSelectingMedium, v => v.btMedium.IsBusy).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.IsSelectingLow, v => v.btLow.IsBusy).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.IsNavigatingBack, v => v.btBack.IsBusy).DisposeWith(disposables);
    }
}
