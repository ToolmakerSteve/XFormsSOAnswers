using Xamarin.Forms;

namespace XFSOAnswers
{
	class FlexLayoutImproveMeasure : FlexLayout
	{

		protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
		{
			var size = base.OnMeasure(double.PositiveInfinity, heightConstraint);
			if (size.Request.Width >= widthConstraint - 1)
			{
				var size2 = base.OnMeasure(widthConstraint, heightConstraint);
				size = size2;   // TODO
				// TODO: What vertical spacing needed between lines?
				//size = new SizeRequest(new Size(widthConstraint, 3 * size.Request.Height));
			}

			return size;
		}
	}
}
