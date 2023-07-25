using CarShopMaui.Views;

namespace CarShopMaui;

public partial class App : Application
{

	public App()
	{
		InitializeComponent();

		MainPage = new MainTabbedPage();
	}
}
