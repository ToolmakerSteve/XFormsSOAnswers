using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CollectionViewWithCellButtonPage : ContentPage
	{
		private Model selectedContact;

		public CollectionViewWithCellButtonPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		private void Button_Clicked(object sender, EventArgs e)
		{

		}

		public ObservableCollection<Model> Contacts { get; set; } = new ObservableCollection<Model> {
			new Model(),
			new Model(),
			new Model(),
		};

		public Model SelectedContact {
			get => selectedContact;
			set => selectedContact = value;
		}
	}
}