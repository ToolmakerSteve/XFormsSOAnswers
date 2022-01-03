using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFSOAnswers.Droid;

namespace XFSOAnswers.Droid
{
	public class CustomFrameRenderer : ViewRenderer<Frame, Android.Views.View>//, IDisposable
	{
		public CustomFrameRenderer(Context context) : base(context)
		{ }


		public void UpdatePos()
		{
			SetY(20); // System.ObjectDisposedException: 'Cannot access a disposed object. Object name: 'CustomFrameRenderer'.'

		}
		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				//TestPage.Container view = e.NewElement as TestPage.Container;
				//if (view != null)
				//{
				//	view.HandlerPosUpdated += UpdatePos;
				//}
			}
			if (e.OldElement != null)
			{
				//TestPage.Container view = e.OldElement as TestPage.Container;
				//if (view != null)
				//{
				//	view.HandlerPosUpdated -= UpdatePos;
				//}
			}
		}


		private bool disposedValue;

		protected override void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					RemoveHandlerPosUpdated();
				}

				disposedValue = true;
			}

			base.Dispose(disposing);
		}

		private void RemoveHandlerPosUpdated()
		{
			if (Element != null)
			{
				//TestPage.Container view = Element as TestPage.Container;
				//if (view != null)
				//{
				//	view.HandlerPosUpdated -= UpdatePos;
				//}
			}

		}
	}
}