using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomDataTemplateSelector : DataTemplateSelector
	{
		public BindableProperty FirstTemplateProperty = BindableProperty.Create(
				nameof(FirstTemplate), typeof(DataTemplate), typeof(DataTemplates)
			);
		// TODO: Change to use Set/GetProperty of above BindableProperty.
		public DataTemplate FirstTemplate { get; set; }

		public BindableProperty SecondTemplateProperty = BindableProperty.Create(
				nameof(SecondTemplate), typeof(DataTemplate), typeof(DataTemplates)
			);
		// TODO: Change to use Set/GetProperty of above BindableProperty.
		public DataTemplate SecondTemplate { get; set; }


		public CustomDataTemplateSelector()
		{
		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			throw new NotImplementedException();
		}
	}
}