using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Device;
using Android.OS;
using PSM.Barcode.Platforms.Android;

namespace PSM.Barcode
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
	public class MainActivity : MauiAppCompatActivity
	{
		private readonly MySampleBroadcastReceiver _receiver;
		private readonly ScanManager _scanManager;

        public MainActivity()
        {
			// Initialize the ScanManager
			_scanManager = new ScanManager();
			// Initialize the Receiver
			_receiver = new MySampleBroadcastReceiver();
		}

		//protected override void OnCreate(Bundle? savedInstanceState)
		//{
		//	base.OnCreate(savedInstanceState);
		//}

		protected override void OnResume()
		{
			base.OnResume();
			//
			RegisterReceiver(_receiver, new IntentFilter(ScanManager.ActionDecode));

			// Open the scanner when activity resumes
			_scanManager.OpenScanner();
		}
		protected override void OnPause()
		{
			base.OnPause();
			//
			UnregisterReceiver(_receiver);

			// Close the scanner when activity pauses
			_scanManager.CloseScanner();
		}
	}
}
