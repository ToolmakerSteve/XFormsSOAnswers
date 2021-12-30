using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentPage : ContentPage
	{
		//public static int subtotal = 123;



		public PaymentPage()
		{
			InitializeComponent();
			BindingContext = this;

			MessagingCenter.Subscribe<PaymentCalc, int>(this, "NewSubTotal", (sender, value) =>
			{
				Subtotal = value;
			});

			TEST_DeferredSubtotalCalc();
		}

		//public int subtotalProxy => subtotal;
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

		//private void OnNewSubTotal(int value)
		//{
		//	Subtotal = value;
		//}

		private void TEST_DeferredSubtotalCalc()
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				await Task.Delay(2000);
				PaymentCalc.DoCalc();
			});
		}
	}
}