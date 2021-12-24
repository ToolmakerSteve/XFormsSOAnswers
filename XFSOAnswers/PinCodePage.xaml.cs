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
	public partial class PinCodePage : ContentPage
	{
		public PinCodePage()
		{
			InitializeComponent();
		}

		private async void NumberCommand(object sender, EventArgs e)
		{
			var button = sender;
		}
	}
}