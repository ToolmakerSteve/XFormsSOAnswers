using System.Collections.Generic;
using Xamarin.Forms;

namespace XFSOAnswers
{
	class FlexLayoutImproveMeasure : FlexLayout
	{
		bool force2Lines;

		protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
		{
			//var size = base.OnMeasure(widthConstraint, heightConstraint);

			var size = base.OnMeasure(2 * widthConstraint, heightConstraint);
			force2Lines = false;
			if (size.Request.Width >= widthConstraint - 1)
			{
				force2Lines = true;
				var size2 = base.OnMeasure(widthConstraint, heightConstraint);
				size = size2;   // TODO
								// TODO: What vertical spacing needed between lines?
								//size = new SizeRequest(new Size(widthConstraint, 3 * size.Request.Height));
			}

			return size;
		}

		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			base.LayoutChildren(x, y, width, height);

			if (force2Lines)
			{
				force2Lines = false;   // Clear flag.
				var childBoundss = new List<Rectangle>();
				foreach (var child in Children)
				{
					Rectangle cb = child.Bounds;
					if (true)
					{
						// Make each child slightly wider: I suspect each label is being truncated.
						const int extraW = 1;// 6;
						var childBounds2 = new Rectangle(cb.X, cb.Y, cb.Width + extraW, cb.Height);
						child.Layout(childBounds2);
						var childBounds3 = child.Bounds;
					}
					childBoundss.Add(cb);
				}
				_ = 0;   // TODO
			}
		}
	}
}
