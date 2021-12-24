using System;
using Xamarin.Forms;

namespace XFSOAnswers
{
	public class MyAbsoluteLayout : AbsoluteLayout
	{
		public MyAbsoluteLayout()
		{
		}

		// Containing page will set this, to act on children after LayoutChildren.
		public Action MeasureAction { get; set; }

		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			base.LayoutChildren(x, y, width, height);

			MeasureAction?.Invoke();
		}
	}
}
