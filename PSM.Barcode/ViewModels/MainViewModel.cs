using Microsoft.Maui.Controls;
using PSM.Barcode.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PSM.Barcode.ViewModels;

public class MainViewModel : ViewModel
{
	public ObservableCollection<BarcodeItem> BarcodeItems = new();

    public MainViewModel()
    {
		BarcodeItems.CollectionChanged += (sender, e) => OnPropertyChanged("Count");

        CmdAddNew = new Command(AddNew);
	}

    public int Count => BarcodeItems.Count;

    public ICommand CmdAddNew { get; set; }

    private void AddNew(object param)
    {
		var num = Random.Shared.Next(20000000, 29999999);
		var bi = new BarcodeItem(num.ToString());
		BarcodeItems.Add(bi);
	}
}
