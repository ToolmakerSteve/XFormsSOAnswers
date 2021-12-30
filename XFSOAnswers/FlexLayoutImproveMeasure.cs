using System.Collections.Generic;
using Xamarin.Forms;

namespace XFSOAnswers
{
	class FlexLayoutImproveMeasure : FlexLayout
	{
		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			base.LayoutChildren(x, y, width, height);

			//var childBoundss = new List<Rectangle>();
			foreach (var child in Children)
			{
				Rectangle cb = child.Bounds;
				// Make each child slightly wider: labels were being truncated.
				// Less than 2 didn't always work. Increase as needed, up to right margin.
				const int extraW = 2;

				double newX = cb.X;
				// TBD whether part of the problem is label that isn't pixel-aligned.
				// (So far, seems more reliable to increase extraW instead.)
				//MAYBE double newX = Math.Floor(cb.X);

				double newW = cb.Width + extraW;
				// TBD whether it helps to ensure width extends to next pixel.
				// (So far, seems more reliable to increase extraW instead.)
				//MAYBE double newW = Math.Ceiling(cb.Width) + extraW;
				//double ceilingRight = Math.Ceiling(cb.X + cb.Width);
				//MAYBE double newW = ceilingRight - Math.Floor(cb.X) + extraW;

				var childBounds2 = new Rectangle(newX, cb.Y, newW, cb.Height);
				child.Layout(childBounds2);
				//childBoundss.Add(child.Bounds);
				//childBoundss.Add(cb);
			}
		}
	}
}
