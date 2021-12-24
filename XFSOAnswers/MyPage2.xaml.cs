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
	public partial class MyPage2 : ContentPage
	{
		// Singleton Pattern. After first creation, do "MyPage.It".
		public static MyPage2 It { get; private set; }

		public MyPage2()
		{
			It = this;
			InitializeComponent();
		}
	}
}