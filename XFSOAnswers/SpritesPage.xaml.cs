using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpritesPage : ContentPage
	{
		public SpritesPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public ObservableCollection<Model3> Sprites { get; set; } = new ObservableCollection<Model3> {
			new Model3(),
			new Model3("b", 0.4, 0),
			new Model3("c", 0, 0.2),
		};

		protected override void OnAppearing()
		{
			base.OnAppearing();

			AnimationLoop();
		}

		private void AnimationLoop()
		{
			// Animation test.
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				// HACK to make sure page is displayed before begin animation loop.
				await Task.Delay(500);

				for (int i = 0; i < 100; i++)
				{
					await Task.Delay(100);
					Sprites[0].X += 0.01;
					Sprites[0].Y += 0.01;

					// Might need this on some platforms.
					//this.GameArea.ForceLayout();

				}
			});
		}
	}

}