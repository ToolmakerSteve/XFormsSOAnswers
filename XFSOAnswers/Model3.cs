using Xamarin.Forms;

namespace XFSOAnswers
{
	public class Model3 : BindableObject
	{
		public string Name { get; set; }

		// (x, Y) = (0.0, 0.0) at top-left, (1.0, 1.0) at bottom-right.
		// Currently, it doesn't seem to be possible to bind these directly.
		// RelativeLayout.XConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width, Factor={Binding X}}"
		// gave error "No property, BindableProperty, or event found for "Factor", or mismatching type between value and property."
		public double X
		{
			get => _x;
			set
			{
				_x = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(XConstraint));
			}
		}
		private double _x;
		public Constraint XConstraint => Constraint.RelativeToParent((parent) => { return parent.Width * X; });

		public double Y
		{
			get => _y;
			set
			{
				_y = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(YConstraint));
			}
		}
		private double _y;
		public Constraint YConstraint => Constraint.RelativeToParent((parent) => { return parent.Height * Y; });


		public Model3(string name = "a", double x = 0, double y = 0)
		{
			Name = name;
			X = x;
			Y = y;
		}
	}
}
