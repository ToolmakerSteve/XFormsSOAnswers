using System;
using System.Collections.ObjectModel;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvenlySpaceItemsScrolling : ContentPage
	{
		public EvenlySpaceItemsScrolling()
		{
			InitializeComponent();

			BindingContext = this;
		}

		const int NItemsToShow = 5;
		const int ItemWidth = 30;

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (false)
			{
				// If the amount of space to left and right of scrolling area is known,
				// we can handle it before the page is laid out.
				// See xaml: the width of left column is 44, right column is 44.
				const int SubtractThisWidth = 44 + 44;
				int collectionWidth = (int)ScreenLogicalWidth() - SubtractThisWidth;
				SetSpacingAndMargin(NItemsToShow, ItemWidth, collectionWidth);
			}
		}

		private void SetSpacingAndMargin(int nItemsToShow, int itemWidth, int collectionWidth)
		{
			int widthPerItem = collectionWidth / nItemsToShow;
			int spacing = Math.Max(0, widthPerItem - itemWidth);
			int leftMargin = spacing / 2;

			this.MyItemsLayout.ItemSpacing = spacing;
			this.clv.Margin = new Thickness(leftMargin, 0, 0, 0);

			// --- Manually test values that work well at a specific screen width. ---
			//this.MyItemsLayout.ItemSpacing = 30;
			//this.clv.Margin = new Thickness(15, 0, 0, 0);
		}

		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			var t1 = this.clv.Width;
			base.LayoutChildren(x, y, width, height);

			// Dynamically calculate based on collection width.
			int collectionWidth = (int)this.clv.Width;
			SetSpacingAndMargin(NItemsToShow, ItemWidth, collectionWidth);
		}

		public static double ScreenLogicalWidth()
		{
			return DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
		}

		// For demo, this is only used to get a count of items.
		// Replace with your actual source.
		public ObservableCollection<Model> ImagesArray { get; set; } = new ObservableCollection<Model> {
			new Model(),
			new Model(),
			new Model(),
			new Model(),
			new Model(),
		};
	}
}