using PSM.Barcode.DataAccess;
using PSM.Barcode.Mvvm;

namespace PSM.Barcode.ViewModels;

public class BarcodeItem : NotifyPropertyBase
{
	private static readonly XDbContext _dbContext = new();

	private readonly string _barcode;
	private readonly string _outCode;

	public BarcodeItem(string barcode)
	{
		_barcode = barcode;
		_outCode = ""; // find in sqlite db

		var pair = _dbContext.BarcodePairs.FirstOrDefault(bp => bp.Barcode == _barcode);
		if (pair != null)
			_outCode = pair.Outcode;
	}

	public string Barcode => _barcode;
	public string Outcode => _outCode;


	public override bool Equals(object? obj)
	{
		return obj is BarcodeItem item && Barcode == item.Barcode;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Barcode);
	}
}
