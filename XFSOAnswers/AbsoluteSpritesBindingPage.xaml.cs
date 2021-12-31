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
	public partial class AbsoluteSpritesBindingPage : ContentPage
	{
		public AbsoluteSpritesBindingPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public ObservableCollection<Model3> Sprites { get; set; } = new ObservableCollection<Model3> {
			new Model3(),
			new Model3("b", 40, 0),
			new Model3("c", 0, 20),
		};

	}




	public class Model3
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string Name { get; set; }

		public Model3(string name = "a", int x = 0, int y = 0)
		{
			Name = name;
		}
	}

}