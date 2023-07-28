using Material.Components.Maui.Extensions;
using Microsoft.Extensions.Logging;

namespace CarShopMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMaps()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMaterialComponents(new() { "OpenSans-Regular.ttf", "OpenSans-Semibold.ttf" });


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
