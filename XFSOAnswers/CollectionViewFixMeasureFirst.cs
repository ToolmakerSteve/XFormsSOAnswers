using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XFSOAnswers
{
	// ----- DID NOT SUCCEED in finding a fix to MeasureFirstItem when Grouped. -----
	class CollectionViewFixMeasureFirst : CollectionView
	{
		public CollectionViewFixMeasureFirst()
		{
		}

		//protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
		//{
		//	var size = base.OnMeasure(widthConstraint, heightConstraint);
		//	return size;
		//}

		//[System.Obsolete]
		//protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
		//{
		//	return base.OnSizeRequest(widthConstraint, heightConstraint);
		//}

		public override SizeRequest GetSizeRequest(double widthConstraint, double heightConstraint)
		{
			return base.GetSizeRequest(widthConstraint, heightConstraint);
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
		}

		protected override void OnRemainingItemsThresholdReached()
		{
			base.OnRemainingItemsThresholdReached();
		}

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
		}

		protected override void OnChildAdded(Element child)
		{
			base.OnChildAdded(child);
		}

		protected override void OnSelectionChanged(SelectionChangedEventArgs args)
		{
			base.OnSelectionChanged(args);
		}
	}
}
