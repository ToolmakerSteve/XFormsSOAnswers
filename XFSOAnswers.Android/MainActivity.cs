using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views;
using Xamarin.Forms.Platform.Android;

namespace XFSOAnswers.Droid
{
    [Activity(Label = "XFSOAnswers", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			App app = new App();
			//app.UserAppTheme = Xamarin.Forms.OSAppTheme.Light;
			LoadApplication(app);

			//SetColors();
		}

		private void SetColors()
		{
			if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
				var color = Xamarin.Forms.Color.FromRgb(0, 255, 255);
				Window.SetStatusBarColor(color.ToAndroid());
				Window.SetNavigationBarColor(color.ToAndroid());

			}
		}

		internal Window GetCurrentWindow()
		{
			var window = this.Window ?? throw new NullReferenceException();
			// TBD: Explain.
			window.ClearFlags(WindowManagerFlags.TranslucentStatus);
			window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
			return window;
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}