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
	public partial class MyPage1 : ContentPage
	{
		// Singleton Pattern.
		private static MyPage1 _it;
		public static MyPage1 It {
			get {
				if (_it == null)
					_it = new MyPage1();
				return _it;
			}
		}

		public MyPage1()
		{
			_it = this;
			InitializeComponent();
		}
	}
}