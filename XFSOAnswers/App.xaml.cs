using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
    public partial class App : Application
    {
        public App()
		{
			InitializeComponent();
			//Sharpnado.Tabs.Initializer.Initialize(false, false);

			//var fontsize = Application.Current.Resources["MyFontSize"];
			//Application.Current.Resources["MyFontSize"] = 50.0;

			//MainPage = MyPage1.It;
			//LoadMyPage(50.0);
			//ReloadMyPageDeferred(25.0, 3);
			//ReloadMyPageDeferred(10.0, 6);

			//ForceLightTheme();
			SetStartPage();
		}

		public void SetStartPage()
		{
			//MainPage = new MainPage();
			//MainPage = new NestedScrollGrid();
			//MainPage = new TwoLayoutPage();

			//MainPage = new AbsoluteLayoutPage();
			//MainPage = new SoftKeyboardEntryPage();
			//MainPage = new TestPage();
			//MainPage = new DatePickerTestPage();

			//MainPage = new PinCodePage();
			//MainPage = new TabBarPage();
			//MISSING_CONVERTER MainPage = new TextValidationPage();
			//MainPage = new TapFramePage();
			//MainPage = new FrameWithHeaderLabelPage();
			//MainPage = new EvenlySpaceItems();
			//MainPage = new EvenlySpaceItemsScrolling();

			//MainPage = new MyAbsoluteLayoutPage();
			//MainPage = new StartPage();
			//MainPage = new CollectionViewWithCellButtonPage();
			//MainPage = new FlexLayoutInItemTemplatePage();

			//MainPage = new PaymentPage();
			//MainPage = new NavigationPage(new TitleViewPage());
			//MainPage = new CollectionViewWithCellButtonPage();
			//MainPage = new GroupedCollectionViewPage();

			//MainPage = new SpritesPage();
			//MainPage = new PickerPage();
			MainPage = new MapPage();
			//MainPage = new PinPageCode();
		}

		public static void ForceLightTheme()
		{
			var theme = Application.Current.UserAppTheme;
			Application.Current.UserAppTheme = OSAppTheme.Light;
			var theme2 = Application.Current.UserAppTheme;
		}

		private void Test()
		{
			//UnionStruct.Test1();

			//Device.BeginInvokeOnMainThread(async () =>
			//{
			//	await System.Threading.Tasks.Task.Delay(200);
			//	var names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
			//});
		}

		//private string _SearchText;
		//public string SearchText {
		//	get { return _SearchText; }
		//	set {
		//		_SearchText = value;
		//		Device.BeginInvokeOnMainThread(async () => {
		//			await OnSearchTextChanged();
		//		});
		//		OnPropertyChanged(nameof(SearchText));
		//	}
		//}
		//public bool ShowAutocomplete { get; set; }
		//public ObservableCollection<string> ListOfPrediction { get; set; }
		//public async Task OnSearchTextChanged()
		//{
		//	ShowAutocomplete = SearchText.Length > 2;
		//	if (ShowAutocomplete) {
		//		var result = await GetAutoComplete(SearchText);
		//		ListOfPrediction = new ObservableCollection<string>(result);
		//	}
		//}
		//private async Task<List<string>> GetAutoComplete(string searchText)
		//{
		//	throw new NotImplementedException();
		//}

		//public void ReloadMyPageDeferred(double newFontSize, int seconds)
		//{
		//	Device.BeginInvokeOnMainThread(async () => {
		//		await GetAutoComplete(value);
		//		await Task.Delay(seconds * 1000);
		//		LoadMyPage(newFontSize);
		//	});
		//}

		public void LoadMyPage(double newFontSize)
		{
			// To be safe, use the expected type. For fontsize, Use "(double)..." if source isn't already a double.
			Application.Current.Resources["MyFontSize"] = newFontSize;
			MainPage = new MyPage1();
		}

		protected override void OnStart()
        {
			//Test();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
			MessagingCenter.Send(this, "WakeUp");
		}
	}
}
