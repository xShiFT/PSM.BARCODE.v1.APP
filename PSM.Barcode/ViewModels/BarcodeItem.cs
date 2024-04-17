using PSM.Barcode.Mvvm;

namespace PSM.Barcode.ViewModels;

public class BarcodeItem : NotifyPropertyBase
{
	private string _barcode;
	private string _outCode;


    public BarcodeItem(string barcode)
    {
        _barcode = barcode;
		_outCode = ""; // find in sqlite db
    }


    public string Barcode
	{
		get => _barcode;
		set => SetValue(ref _barcode, value);
	}

	public string Outcode
	{
		get => _outCode;
		set => SetValue(ref _outCode, value);
	}
}
