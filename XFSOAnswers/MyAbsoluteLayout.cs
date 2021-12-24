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

		private bool _busy;

		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			// Avoid recursed layout calls as MeasureAction moves children.
			if (_busy)
				return;

			base.LayoutChildren(x, y, width, height);

			_busy = true;
			try
			{
				MeasureAction?.Invoke();
			}
			finally
			{
				_busy = false;
				// Layout again, now that all children have been positioned.
				base.LayoutChildren(x, y, width, height);
			}
		}
	}
}
