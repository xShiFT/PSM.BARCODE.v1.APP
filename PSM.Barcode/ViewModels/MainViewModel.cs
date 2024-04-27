using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PSM.Barcode.ViewModels;

public class MainViewModel : ObservableObject
{
	public static MainViewModel Instance { get; } = new MainViewModel();

	public MainViewModel()
	{
		BarcodeItems.CollectionChanged += (sender, e) => {
			OnPropertyChanged(nameof(Count));
			OnPropertyChanged(nameof(BarcodeItems));
		};

		CmdAddNew = new Command(AddNew);
	}

	public ObservableCollection<BarcodeItem> BarcodeItems { get; } = new();
	public int Count => BarcodeItems.Count;

	public ICommand CmdAddNew { get; set; }
	private void AddNew(object param)
	{
		AddNewItem(Random.Shared.Next(24000000, 24999999).ToString());
	}

	public void AddNewItem(string barcode)
	{
		if (!BarcodeItems.Any(b => b.BarCode == barcode))
			BarcodeItems.Add(new BarcodeItem(barcode));
	}
}
