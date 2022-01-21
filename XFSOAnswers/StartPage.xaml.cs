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
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();

			Button1Command = new Command(Button1Action);
			Button2Command = new Command(Button2Action);
			BindingContext = this;
		}

		public Command Button1Command { get; set; }
		public Command Button2Command { get; set; }

		private void Button1Action(object obj)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				App.ForceLightTheme();
			});
		}

		private void Button2Action(object obj)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				App.Current.MainPage = new FilePickerPage();
			});
		}
	}
}