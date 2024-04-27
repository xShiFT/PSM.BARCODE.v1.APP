using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace PSM.Barcode.ViewModels;

public class LoginViewModel: ObservableObject
{
	public static LoginViewModel Instance { get; } = new LoginViewModel();

	private LoginViewModel()
	{
		CmdNavBack = new RelayCommand(async () => await Shell.Current.GoToAsync(".."));
	}

	public ICommand CmdNavBack { get; }
}
