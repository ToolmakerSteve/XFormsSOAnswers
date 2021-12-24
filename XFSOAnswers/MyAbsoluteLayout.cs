using System;
using Xamarin.Forms;

namespace XFSOAnswers
{
	public class MyAbsoluteLayout : AbsoluteLayout
	{
		public MyAbsoluteLayout()
		{
		}

		// Containing page will set this, to act on children during LayoutChildren.
		public Action CustomLayoutAction { get; set; }

		private bool _busy;

		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			// Avoid recursed layout calls as CustomLayoutAction moves children.
			if (_busy)
				return;

			// Xamarin measures the children.
			base.LayoutChildren(x, y, width, height);

			_busy = true;
			try
			{
				CustomLayoutAction?.Invoke();
			}
			finally
			{
				_busy = false;
				// Layout again, to position the children, based on adjusted (x,y)s.
				base.LayoutChildren(x, y, width, height);
			}
		}
	}
}
