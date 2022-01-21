using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFSOAnswers
{
	public class LabelFix : Label
	{
		public LabelFix()
		{
		}

		protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
		{
			//Text = "Once";

			var size = base.OnMeasure(widthConstraint, heightConstraint);

			var display = DeviceDisplay.MainDisplayInfo;
			var widthPixels = display.Width;
			var widthDIPs = display.Width / display.Density;

			return size;
		}
	}
}