using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
			Init();
			BindingContext = this;
		}

		protected override void OnAppearing()
        {
            base.OnAppearing();

			//MyEntry.Focus();
			//DoSomethingASync();
		}

		private void DoSomethingASync()
		{
			string parameter = "68";
			new Action(async () =>
			{
				try {
					ShowMessage(parameter);
					await Task.Delay(3000);
					ShowMessage(parameter);
				} catch { }
			}).Invoke();
		}

		public static void ShowMessage(string text)
		{
			Debug.WriteLine($"\n----- {text}, main={MainThread.IsMainThread}-----\n");
		}



		public ObservableCollection<MyTuple> Data { get; set; }

		private void Init()
		{
			Data = new ObservableCollection<MyTuple> {
				new MyTuple("a", "abcabc")
			};
		}
	}
}