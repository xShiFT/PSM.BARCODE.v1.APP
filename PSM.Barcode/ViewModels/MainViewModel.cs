using Microsoft.Maui.Controls;
using PSM.Barcode.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PSM.Barcode.ViewModels;

public class MainViewModel : ViewModel
{
	public static MainViewModel Instance { get; } = new MainViewModel();

	private MainViewModel()
    {
		BarcodeItems.CollectionChanged += (sender, e) => {
			OnPropertyChanged(nameof(Count));
			OnPropertyChanged(nameof(BarcodeItems));
		};

        CmdAddNew = new Command(AddNew);
	}

	public ObservableCollection<BarcodeItem> BarcodeItems { get; } = new();
	//public List<BarcodeItem> BarcodeItems { get; } = new();
	public int Count => BarcodeItems.Count;

    public ICommand CmdAddNew { get; set; }
    private void AddNew(object param)
    {
		AddNewItem(Random.Shared.Next(24000000, 24999999).ToString());
	}

	public void AddNewItem(string barcode)
	{
		BarcodeItems.Add(new BarcodeItem(barcode));
		//OnPropertyChanged(nameof(Count));
		//OnPropertyChanged(nameof(BarcodeItems));
	}
}
