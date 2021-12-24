using Android.Content;
using Android.Views.InputMethods;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(XFSOAnswers.Droid.CustomEntryRenderer))]
namespace XFSOAnswers.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
            }
        }

		/// <summary>
		/// When IsFocused is becoming true, Hide soft keyboard after a slight delay.
		/// </summary>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs propertyChangingEventArgs)
        {
			Android.Util.Log.Warn("-----", $"prop {propertyChangingEventArgs.PropertyName} -----");

			// Check if the view is gaining Focus.
			if (propertyChangingEventArgs.PropertyName == VisualElement.IsFocusedProperty.PropertyName) {
				if (this.HasFocus) {
					Android.Util.Log.Warn("-----", $"hasFocus={this.HasFocus} -----");

					Device.BeginInvokeOnMainThread(async () => {
						await Task.Delay(1);
						Android.Util.Log.Warn("-----", $"HideSoftInputFromWindow -----");
						InputMethodManager imm = (InputMethodManager)this.Context.GetSystemService(Context.InputMethodService);
						imm.HideSoftInputFromWindow(this.Control.WindowToken, 0);
					});
					// OPTIONAL: DON'T pass on to base. There might be circumstances where this helps.
					return;
				}
			}

			// Pass all other changes to the base class.
			base.OnElementPropertyChanged(sender, propertyChangingEventArgs);
		}

		protected override void OnFocusChangeRequested(object sender, VisualElement.FocusRequestArgs e)
		{
			Android.Util.Log.Warn("-----", $"OnFocusChangeRequested f={e.Focus}, r={e.Result} -----");
			// Change the default behavior. This seems to suppress (or delay?) IsFocused event in some circumstances.
			if (e.Focus)
				e.Result = !e.Result;
			Android.Util.Log.Warn("-----", $"r={e.Result} -----");
		}
	}
}