using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentPage : ContentPage
	{
		public PaymentPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public int Subtotal
		{
			get => _subtotal;
			set
			{
				_subtotal = value;
				OnPropertyChanged();
			}
		}
		private int _subtotal;


		protected override void OnAppearing()
		{
			base.OnAppearing();

			MessagingCenter.Subscribe<PaymentCalc, int>(this, "NewSubTotal", (sender, value) =>
			{
				Subtotal = value;
			});


			TEST_DeferredSubtotalCalc();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			MessagingCenter.Unsubscribe<PaymentCalc, int>(this, "NewSubTotal");
		}


		private void TEST_DeferredSubtotalCalc()
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				await Task.Delay(2000);
				PaymentCalc.DoCalc();
			});
		}
	}
}