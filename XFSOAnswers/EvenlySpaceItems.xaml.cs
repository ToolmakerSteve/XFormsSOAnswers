using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvenlySpaceItems : ContentPage
	{
		public EvenlySpaceItems()
		{
			InitializeComponent();
			BindingContext = this;
		}

		// For demo, this is only used to get a count of items.
		// Replace with your actual source.
		public ObservableCollection<Model> ImagesArray { get; set; } = new ObservableCollection<Model> {
			new Model(),
			new Model(),
			new Model(),
			new Model(),
			new Model(),
		};
	}


	public class Model
	{
		public string Name { get; set; } = "a";
	}
}