using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFSOAnswers
{
	class PaymentCalc
	{
		public static void DoCalc()
		{
			var it = new PaymentCalc();
			it.NewSubTotal(5432);
		}

		public void NewSubTotal(int value)
		{
			MessagingCenter.Send(this, "NewSubTotal", value);
		}
	}
}
