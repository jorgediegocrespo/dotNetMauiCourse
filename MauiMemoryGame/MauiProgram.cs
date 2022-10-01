using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MauiMemoryGame;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseSkiaSharp()
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).
			Services
            .RegisterServices()
			.RegisterViews();

        return builder.Build();
	}

	private static IServiceCollection RegisterViews(this IServiceCollection services)
	{
		return services
            .AddTransient<ThemeSelectorViewModel>().AddTransient<ThemeSelectorView>()
            .AddTransient<LevelSelectorViewModel>().AddTransient<LevelSelectorView>()
            .AddTransient<GameViewModel>().AddTransient<GameView>()
            .AddTransient<GameOverPopupViewModel>().AddTransient<GameOverPopupView>();
    }

	private static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		return services
			.AddSingleton<IDialogService, DialogService>()
			.AddSingleton<ILogService, LogService>()
			.AddSingleton<INavigationService, NavigationService>();
    }
}

