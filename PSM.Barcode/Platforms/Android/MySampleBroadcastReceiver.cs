﻿using Android.App;
using Android.Content;
using Android.Device;
using Android.Widget;
using PSM.Barcode.ViewModels;

namespace PSM.Barcode.Platforms.Android
{
	[BroadcastReceiver(Enabled = true, Exported = true)]
	[IntentFilter([ScanManager.ActionDecode])]
	public class MySampleBroadcastReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			if (context is null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			if (intent is null)
			{
				throw new ArgumentNullException(nameof(intent));
			}
			// Do stuff here
			_ = intent.GetByteArrayExtra(ScanManager.DecodeDataTag);
			_ = intent.GetIntExtra(ScanManager.BarcodeLengthTag, 0);
			_ = intent.GetByteExtra(ScanManager.BarcodeTypeTag, 0x00);
			string result = intent?.GetStringExtra(ScanManager.BarcodeStringTag) ?? "";

			if (result != null)
			{
				BarcodesViewModel.Instance?.Barcodes.AddNewItem(result);
				Toast.MakeText(context, result, ToastLength.Short)?.Show();
				//Toast.MakeText(Application.Context, result, ToastLength.Short).Show();
				// edittext.SetText( result.ToCharArray, 0, "" + result.Length);
			}
		}
	}
}
