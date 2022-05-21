using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeriodicInteractPage : ContentPage
	{
		public PeriodicInteractPage()
		{
			InitializeComponent();
			StartPeriodicTask(5, GetUserConfirmation, Done);
		}

		delegate Task<bool> TaskBoolDeleg();
		delegate Task TaskDeleg();

		private void StartPeriodicTask(float seconds, TaskBoolDeleg periodicTask, TaskDeleg doneTask)
		{
			// On MainThread, so can interact with user.
			// "async" + "await Delay" ensures UI is not blocked until time is up.
			Device.BeginInvokeOnMainThread(async () =>
			{
				bool alive = true;
				while (alive)
				{
					await Task.Delay((int)(1000 * seconds));
					alive = await periodicTask();
				}
				await doneTask();
			});
		}

		private async Task<bool> GetUserConfirmation()
		{
			// Block UI until user responds.
			bool answer = await DisplayAlert("", "Are you still there?", "Yes", "No");
			Debug.WriteLine($"--- Still there: {answer} ---");
			return answer;
		}

		private async Task Done()
		{
			Debug.WriteLine($"--- DONE ---");
			await DisplayAlert("", "Logout", "OK");
		}



		protected override void OnAppearing()
		{
			base.OnAppearing();

			var holdItems = theCollectionView.ItemsSource;
			// Set to an empty collection of the type of your ItemsSource.
			//theCollectionView.ItemsSource = ...;

			Device.BeginInvokeOnMainThread(async () =>
			{
				await Task.Delay(1000);
				theCollectionView.ItemsSource = holdItems;
			});
		}

	}
}