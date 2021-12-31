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
	public partial class GroupedCollectionViewPage : ContentPage
	{
		public GroupedCollectionViewPage()
		{
			InitializeComponent();
			BindingContext = this;

			CreateGroups();
		}

		public List<ModelGroup> Groups { get; private set; } = new List<ModelGroup>();


		private void CreateGroups()
		{
			Groups.Clear();
			Groups.Add(ModelGroup.Create("First Group", 3, "elephant"));
			Groups.Add(ModelGroup.Create("Second Group", 2, "zebra"));
		}

		// For demo, this is only used to get a count of items.
		// Replace with your actual source.
		public ObservableCollection<Model> Items { get; set; } = new ObservableCollection<Model> {
			new Model(),
			new Model(),
			new Model(),
			new Model(),
			new Model(),
		};
	}



	public class ModelGroup : List<Model2>
	{
		public static ModelGroup Create(string groupName, int modelCount, string modelString, string line2 = "!!!!!")
		{
			var models = new List<Model2>();
			for (int iModel = 0; iModel < modelCount; iModel++)
			{
				models.Add(new Model2(modelString, line2));
			}

			return new ModelGroup(groupName, models);
		}


		public string Name { get; private set; }

		public ModelGroup(string name, List<Model2> models) : base(models)
		{
			Name = name;
		}
	}


	public class Model2
	{
		public string Name { get; set; }
		public string Line2 { get; set; }

		public Model2() : this("a", "-")
		{
		}

		public Model2(string name, string line2)
		{
			Name = name;
			Line2 = line2;
		}
	}

}