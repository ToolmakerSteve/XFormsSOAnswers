using Sharpnado.Tabs;
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
	public partial class SharpnadoTabsPage : ContentPage
	{
		public SharpnadoTabsPage()
		{
			InitializeComponent();
			ProfileViewCommand = new Command(ProfileView);
			Test();
			BindingContext = this;
		}

		public Command ProfileViewCommand { get; set; }

		private void ProfileView()// object obj)
		{
			var tb = this.TabButton;
			var children = tb.Children;
			if (children.Count > 0)
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					var tbScale = tb.Scale;
					var tbBounds = tb.Bounds;
					var ch0 = children[0];
					var visCh = ch0 as VisualElement;
					var b = visCh.Bounds;
					var scale = visCh.Scale;
					_ = 0;
				});
			}
		}

		private void TabHostLogo_SelectedTabIndexChanged(object sender, SelectedPositionChangedEventArgs e)
		{
			var index = this.TabHostLogo.SelectedIndex;
			if (index != prevIndex)
			{
				prevIndex = index;
			}
		}

		private int prevIndex = -1;

		private void Test()
		{
			var tb = new TabButton();
			var dummy = tb.Scale;
			var padding = tb.Padding;
		}
	}
}