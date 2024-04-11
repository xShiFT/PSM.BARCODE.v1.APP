using Android.App;
using Android.Content;
using Android.Device;
using Android.Widget;

namespace PSM.Barcode.Platforms.Android
{
	[BroadcastReceiver(Enabled = true)]
	[IntentFilter([ScanManager.ActionDecode])]
	public class MySampleBroadcastReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			// Do stuff here
			_ = intent.GetByteArrayExtra(ScanManager.DecodeDataTag);
			_ = intent.GetIntExtra(ScanManager.BarcodeLengthTag, 0);
			_ = intent.GetByteExtra(ScanManager.BarcodeTypeTag, 0x00);
			string result = intent.GetStringExtra(ScanManager.BarcodeStringTag);

			if (result != null)
			{
				Toast.MakeText(context, result, ToastLength.Short).Show();
				//Toast.MakeText(Application.Context, result, ToastLength.Short).Show();
				// edittext.SetText( result.ToCharArray, 0, "" + result.Length);
			}
		}
	}
}
