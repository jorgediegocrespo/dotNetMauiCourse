namespace MauiMemoryGame.Features;

public partial class ThemeSelectorView
{
	public ThemeSelectorView(ThemeSelectorViewModel viewModel)
	{
		ViewModel = viewModel;
		InitializeComponent();
	}

    protected override void CreateBindings(CompositeDisposable disposables)
    {
        base.CreateBindings(disposables);

		this.OneWayBind(ViewModel, vm => vm.SelectDcCommand, v => v.btDc.Command).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.SelectMarvelCommand, v => v.btMarvel.Command).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.SelectSimpsonsCommand, v => v.btSimpsons.Command).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.SelectStarWarsCommand, v => v.btStarWars.Command).DisposeWith(disposables);

        this.OneWayBind(ViewModel, vm => vm.IsSelectingDc, v => v.btDc.IsBusy).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.IsSelectingMarvel, v => v.btMarvel.IsBusy).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.IsSelectingSimpsons, v => v.btSimpsons.IsBusy).DisposeWith(disposables);
        this.OneWayBind(ViewModel, vm => vm.IsSelectingStarWars, v => v.btStarWars.IsBusy).DisposeWith(disposables);
    }
}
