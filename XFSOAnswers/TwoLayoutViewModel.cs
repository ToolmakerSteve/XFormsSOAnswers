using Xamarin.Forms;

namespace XFSOAnswers
{
	public class TwoLayoutViewModel : BindableObject
	{
		private bool _usesecondLayout = false;
		public bool UseSecondLayout {
			get => _usesecondLayout;
			set {
				_usesecondLayout = value;
				OnPropertyChanged();
			}
		}


		public TwoLayoutViewModel()
		{
			SwitchToSecondLayoutCommand = new Command(SwitchToSecondLayout);
		}


		public Command SwitchToSecondLayoutCommand { get; set; }


		private void SwitchToSecondLayout()
		{
			UseSecondLayout = true;
		}
	}
}
