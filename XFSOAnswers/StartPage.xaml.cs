using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

		public string Text { get; set; }
		public Command Button1Command { get; set; }
		public Command Button2Command { get; set; }

		private void Button1Action(object obj)
		{
			MainThread.BeginInvokeOnMainThread(() =>
			{
				App.ForceLightTheme();
			});
		}

		private void Button2Action(object obj)
		{
			MainThread.BeginInvokeOnMainThread(() =>
			{
				App.Current.MainPage = new FilePickerPage();
			});
		}

		private void Entry_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}