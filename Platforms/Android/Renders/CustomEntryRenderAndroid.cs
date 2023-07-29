using CarShopMaui.Controls;
using CarShopMaui.Platforms.Android.Renders;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderAndroid))]
namespace CarShopMaui.Platforms.Android.Renders
{
    public class CustomEntryRenderAndroid : EntryRenderer
    {
        public CustomEntryRenderAndroid(global::Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Background = null;
                Control.SetBackgroundColor(Color.Transparent);
            }
        }
    }
}
