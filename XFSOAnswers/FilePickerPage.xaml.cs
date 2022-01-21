using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilePickerPage : ContentPage
	{
		public FilePickerPage()
		{
			InitializeComponent();
		}

		private void PickFileButton_Clicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				await PickAndShow(PickOptions.Images);
			});
		}

		async Task<FileResult> PickAndShow(PickOptions options)
		{
			try
			{
				var result = await FilePicker.PickAsync(options);
				if (result != null)
				{
					FileName.Text = $"File Name: {result.FileName}";
					if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
						result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
					{
						var stream = await result.OpenReadAsync();
						FileImage.Source = ImageSource.FromStream(() => stream);
					}
				}

				return result;
			}
			catch (Exception ex)
			{
				// The user canceled or something went wrong
				_ = ex;
			}

			return null;
		}
	}
}