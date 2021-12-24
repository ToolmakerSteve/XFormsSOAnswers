using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyAbsoluteLayoutPage : ContentPage
	{
		public MyAbsoluteLayoutPage()
		{
			InitializeComponent();

			TheLayout.MeasureAction = PositionLabels;
		}

		private void PositionLabels()
		{
			// Manually check that the bounds have values.
			var bounds1 = Label1.Bounds;
			var bounds2 = Label2.Bounds;
			var bounds3 = Label3.Bounds;
			var bounds4 = Label4.Bounds;

			double x = 10;
			double y = 20;
			MoveAbsoluteChildTo(Label1, x, y);
			x += Label1.Width;
			y += Label1.Height;

			MoveAbsoluteChildTo(Label2, x, y);
			x += Label2.Width;
			y += Label2.Height;

			MoveAbsoluteChildTo(Label3, x, y);
			x += Label3.Width;
			y += Label3.Height;

			MoveAbsoluteChildTo(Label4, x, y);
		}

		private static void MoveAbsoluteChildTo(View child, double x, double y)
		{
			AbsoluteLayout.SetLayoutBounds(child, new Rect(x, y, child.Width, child.Height));
		}
	}
}