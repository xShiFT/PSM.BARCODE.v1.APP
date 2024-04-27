using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace PSM.Barcode.ViewModels;

public class BarcodesViewModel: ObservableObject
{
	public static BarcodesViewModel Instance { get; } = new BarcodesViewModel();

	private BarcodesViewModel()
	{
		Barcodes = new BarcodeList();

		CmdAddNew = new RelayCommand(AddNew);
		CmdNavBack = new RelayCommand(async () => await Shell.Current.GoToAsync(".."));
	}

	public BarcodeList Barcodes { get; }

	public ICommand CmdAddNew { get; }
	public ICommand CmdNavBack { get; }

	private void AddNew()
	{
		Barcodes.AddNewItem(Random.Shared.Next(24000000, 24999999).ToString());
	}
}
