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

		public static void NewSubTotal(int value)
		{
			subtotal = value;
			// HACK - not recommended
			It?.OnSubtotalChanged();
		}

		public static PaymentPage It;


		public PaymentPage()
		{
			InitializeComponent();
			BindingContext = this;

			// HACK - not recommended
			It = this;

			DeferredSubtotalCalc();
		}

		public int subtotalProxy => subtotal;

		private void OnSubtotalChanged()
		{
			OnPropertyChanged(nameof(subtotalProxy));
		}

		private void DeferredSubtotalCalc()
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				await Task.Delay(3000);
				NewSubTotal(54321);
			});
		}
	}
}