using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CollectionViewWithCellButtonPage : ContentPage
	{
		private Model _selectedContact;
		private bool _suppressSelection;
		private System.Timers.Timer _buttonTimer;

		public CollectionViewWithCellButtonPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			// Make sure _suppressSelection can't get "stuck on".
			_buttonTimer = new System.Timers.Timer { Interval = 500, AutoReset = false };
			_buttonTimer.Elapsed += Timer_Elapsed;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			// Stop timer. Release reference.
			if (_buttonTimer != null)
			{
				_buttonTimer.Stop();
				_buttonTimer = null;
			}
			// Clean up state, in case navigate back to page.
			_suppressSelection = false;
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			// FIRST LINE in method - do this as early as possible.
			_suppressSelection = true;

			//... your main logic here ...

			// Make sure _suppressSelection can't get "stuck on".
			_buttonTimer.Start();
		}

		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			// "if" line can be commented out. I just have it so breakpoint on following line is only hit if
			// timer is needed to do its job. Some sequences of item selection and button presses do hit that breakpoint.
			if (_suppressSelection)
				_suppressSelection = false;
		}

		public ObservableCollection<Model> Contacts { get; set; } = new ObservableCollection<Model> {
			new Model(),
			new Model(),
			new Model(),
		};

		public Model SelectedContact
		{
			get => _selectedContact;
			set
			{
				Device.BeginInvokeOnMainThread(async () =>
				{
					await DelayedSetSelectedContact(value);
				});

			}
		}

		private async Task DelayedSetSelectedContact(Model value)
		{
			await Task.Delay(100);
			if (_suppressSelection)
			{
				// Button was pressed. DO NOTHING - DON'T select the item.

				// Clear state for next time.
				_suppressSelection = false;
			}
			else
			{
				_selectedContact = value;
				// ... Do your other work here ...
			}
		}
	}
}