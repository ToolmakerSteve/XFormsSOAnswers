using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CollectionGridLayoutPage : ContentPage
	{
		public CollectionGridLayoutPage()
		{
			InitializeComponent();
			BindingContext = new EditProfilePageViewModel(new Profile());
		}


		List<string> ResourcePaths = new List<string> {
			"apple_x64.png", "boat_on_water_x64.png", "pine_tree_x64.png", "unicorn_head_pink_x64.png"};

	}



	public class EditProfilePageViewModel : BindableObject
	{
		public Profile Profile { get; set; }
		public Command HandleImage { get; private set; }

		public EditProfilePageViewModel(Profile profile)
		{
			this.Profile = profile;
			HandleImage = new Command(OnHandleImage);
		}

		void OnHandleImage(object CommandParameter)
		{
			// Get the index of the image
			var item = (ImageSource)CommandParameter;
			int index = Profile.IndexOf(item);
		}
	}



	public class Profile : BindableObject
	{
		public ObservableCollection<ImageSource> Items { get; set; } = new ObservableCollection<ImageSource>();

		public Profile()
		{
			Items.Add(NewItem(ResourcePaths[0]));
			Items.Add(NewItem(ResourcePaths[1]));
			Items.Add(NewItem(ResourcePaths[2]));
			Items.Add(NewItem(ResourcePaths[3]));
			Items.Add(NewItem("ee"));
			Items.Add(NewItem("f"));
		}

		public int IndexOf(ImageSource item)
		{
			return Items.IndexOf(item);
		}

		static List<string> ResourcePaths = new List<string> {
			"apple_x64.png", "boat_on_water_x64.png", "pine_tree_x64.png", "unicorn_head_pink_x64.png"};

		ImageSource NewItem(string path)
		{
			return CreateOurSource(path);
		}

		public const string AssemblyName = "XFSOAnswers";

		private ImageSource CreateOurSource(string resourcePath)
		{
			// For embedded resources stored in project folder "Media".
			var resourceID = $"{AssemblyName}.Media.{resourcePath}";
			// Our media is in the cross-platform assembly. Same is this page.
			Assembly assembly = this.GetType().GetTypeInfo().Assembly;
			ImageSource source = ImageSource.FromResource(resourceID, assembly);
			return source;
		}
	}



	public class ProfileItem : BindableObject
	{
		public int Id { get; set; }
		public ImageSource ImageSource { get; set; }

		public ProfileItem(string name, int id)
		{
			Id = id;
			ImageSource = CreateOurSource(name);
		}



		public const string AssemblyName = "XFSOAnswers";

		private ImageSource CreateOurSource(string resourcePath)
		{
			// For embedded resources stored in project folder "Media".
			var resourceID = $"{AssemblyName}.Media.{resourcePath}";
			// Our media is in the cross-platform assembly. Same is this page.
			Assembly assembly = this.GetType().GetTypeInfo().Assembly;
			ImageSource source = ImageSource.FromResource(resourceID, assembly);
			return source;
		}

	}
}