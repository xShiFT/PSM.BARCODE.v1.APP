using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PSM.Barcode.Views;
using System.Windows.Input;

namespace PSM.Barcode.ViewModels;

public class MainViewModel : ObservableObject
{
	public static MainViewModel Instance { get; } = new MainViewModel();

	private MainViewModel()
	{
		CmdToLogin = new RelayCommand(async () => { await Shell.Current.GoToAsync(nameof(LoginPage)); });
		CmdToBarcodes = new RelayCommand(async () => { await Shell.Current.GoToAsync(nameof(BarcodesPage)); });
		CmdUpdate = new RelayCommand(() => {; });
	}

	public ICommand CmdToLogin { get; }
	public ICommand CmdToBarcodes { get; }
	public ICommand CmdUpdate { get; }
}
