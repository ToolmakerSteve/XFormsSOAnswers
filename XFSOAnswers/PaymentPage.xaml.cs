using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentPage : ContentPage
	{
		public static int subtotal = 123;



		public PaymentPage()
		{
			InitializeComponent();
			BindingContext = this;

			MessagingCenter.Subscribe<PaymentCalc, int>(this, "NewSubTotal", (sender, value) =>
			{
				OnNewSubTotal(value);
			});

			TEST_DeferredSubtotalCalc();
		}

		public int subtotalProxy => subtotal;

		private void OnNewSubTotal(int value)
		{
			subtotal = value;
			OnPropertyChanged(nameof(subtotalProxy));
		}

		private void TEST_DeferredSubtotalCalc()
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				await Task.Delay(1000);
				PaymentCalc.DoCalc();
			});
		}
	}
}