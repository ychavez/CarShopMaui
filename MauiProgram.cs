using CarShopMaui.Controls;
using CarShopMaui.Platforms.Android.Renders;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;


namespace CarShopMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMaps()
			.UseMauiCompatibility()
			.ConfigureMauiHandlers((handler) => { 
			
				//handler.AddCompatibilityRenderer(typeof(CustomEntry), typeof(CustomEntryRenderAndroid));

			})
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
