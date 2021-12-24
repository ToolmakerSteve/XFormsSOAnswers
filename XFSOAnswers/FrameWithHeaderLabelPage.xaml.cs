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
	public partial class FrameWithHeaderLabelPage : ContentPage
	{
		public FrameWithHeaderLabelPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public string HeaderText { get; set; } = "Header Text";
	}
}