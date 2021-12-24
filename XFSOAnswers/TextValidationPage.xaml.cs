using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TextValidationPage : ContentPage
	{
		private UserViewModel _userViewModel;

		public TextValidationPage()
		{
			InitializeComponent();
			_userViewModel = new UserViewModel(false, false);
			BindingContext = _userViewModel;
		}

		private void OnSave(object sender, EventArgs e)
		{
			Console.WriteLine("[User View Model Firstname] : " + _userViewModel.Firstname + "  " + _userViewModel.IsFirstnameValid);
			Console.WriteLine("[User View Model Lastname] : " + _userViewModel.Lastname + "  " + _userViewModel.IsLastnameValid);
		}
	}
}