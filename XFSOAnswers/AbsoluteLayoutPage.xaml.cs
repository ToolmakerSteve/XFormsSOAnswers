using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AbsoluteLayoutPage : ContentPage
	{
		public AbsoluteLayoutPage()
		{
			ButtonCommand = new Command(ButtonClick);
			InitializeComponent();
			BindingContext = this;
		}

		public void Clicked(object sender, EventArgs a)
		{
			var btn = (Button)sender;

			var w = btn.Width;
			var h = btn.Height;

			DisplayAlert("Dimensions", $"{w}x{h}", "OK");

		}
		private void ButtonClick(object ob)
		{
			var button = ob as View;
			var bounds = btn.Bounds;
			var width = btn.Width;
			var height = btn.Height;
			Debug.WriteLine($"--- ButtonClick {bounds}, ({width},{height})---");

		}

		public Command ButtonCommand { get; set; }
	}
}