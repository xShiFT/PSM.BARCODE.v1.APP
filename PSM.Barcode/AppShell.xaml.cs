using PSM.Barcode.Views;

namespace PSM.Barcode;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(BarcodesPage), typeof(BarcodesPage));
		Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
	}
}
