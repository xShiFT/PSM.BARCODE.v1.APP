using CommunityToolkit.Mvvm.ComponentModel;
using PSM.Barcode.DB;

namespace PSM.Barcode.ViewModels;

public class BarcodeItem : ObservableObject
{
	private static readonly XDbContext _dbContext = new();

	private readonly string _barCode;
	private readonly string _outCode;

	public BarcodeItem(string barcode)
	{
		_barCode = barcode;
		_outCode = ""; // find in sqlite db

		var pair = _dbContext.BarcodePairs.FirstOrDefault(bp => bp.BarCode == _barCode);
		if (pair != null)
			_outCode = pair.OutCode;
	}

	public string BarCode => _barCode;
	public string OutCode => _outCode;


	public override bool Equals(object? obj)
	{
		return obj is BarcodeItem item && BarCode == item.BarCode;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(BarCode);
	}
}
