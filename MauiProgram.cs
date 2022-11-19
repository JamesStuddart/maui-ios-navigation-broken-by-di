using Microsoft.Extensions.Logging;

namespace NavigationCrashTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif


		// Comment out these three lines and the navigation works
        //builder.Services.AddSingleton<MainPage>();
        //builder.Services.AddSingleton<SecondPage>();
        //builder.Services.AddSingleton<ThirdPage>();


        return builder.Build();
	}
}

