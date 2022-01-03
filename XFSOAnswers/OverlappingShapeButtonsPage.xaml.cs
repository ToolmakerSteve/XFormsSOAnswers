using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OverlappingShapeButtonsPage : ContentPage
	{
		public OverlappingShapeButtonsPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// This is called when any of the BoxViews are touched.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnTapped1(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// This is called when the grid is touched anywhere that is not inside one of the BoxViews.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnTapped2(object sender, EventArgs e)
		{

		}
	}
}