using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PSM.Barcode.ViewModels
{
	public class BarcodeList: ObservableObject
	{
		//private static XDbContext _ctx = new XDbContext();

		public BarcodeList()
		{
			Items.CollectionChanged += (sender, e) => {
				OnPropertyChanged(nameof(Count));
				OnPropertyChanged(nameof(Items));
			};
		}

		public ObservableCollection<BarcodeItem> Items { get; } = [];

		public int Count => Items.Count;

		public void AddNewItem(string barcode)
		{
			if (!Items.Any(b => b.BarCode == barcode))
				Items.Add(new BarcodeItem(barcode));
		}
	}
}