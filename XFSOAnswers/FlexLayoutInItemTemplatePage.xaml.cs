using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlexLayoutInItemTemplatePage : ContentPage
	{
		public FlexLayoutInItemTemplatePage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public List<ListModel> Items { get; } = new List<ListModel> {
			new ListModel(),
			new ListModel(),
		};
	}


	public class ListModel
	{
		public List<string> Items2 { get; } = new List<string> {
			"aaa", "bbbbbbbbb", "cc", "dddd", "e",
		};
	}
}