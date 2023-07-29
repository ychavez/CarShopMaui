using CarShopMaui.Controls;
using CommunityToolkit.Maui;
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
			.UseMauiCommunityToolkit()
			.UseMauiCompatibility()
			.ConfigureMauiHandlers((handler) => {
#if ANDROID             
				handler.AddCompatibilityRenderer(typeof(CustomEntry), typeof(CarShopMaui.Platforms.Android.Renders.CustomEntryRenderAndroid));
#elif IOS

#endif

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
