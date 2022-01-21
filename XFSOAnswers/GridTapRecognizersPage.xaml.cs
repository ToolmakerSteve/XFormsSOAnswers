using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSOAnswers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridTapRecognizersPage : ContentPage
    {
        public GridTapRecognizersPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            Menu_Grid.ColumnSpacing = 30;

            Menu_Grid.Margin = new Thickness(15, 0, 0, 0);

            for (int i = 0; i < 5; i++) Menu_Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            Menu_Grid.RowDefinitions.Add(new RowDefinition());

            var page_switcher_tap_recognizer = new TapGestureRecognizer();
            page_switcher_tap_recognizer.Tapped += (sender, e) =>
            {
                var t = sender;
            };

            int j = 0;
            //foreach (KeyValuePair<string, string> kvp in oblibene_categories)
            //{
            //    Grid grid = new Grid
            //    {
            //        RowDefinitions = { new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }, new RowDefinition { Height = new GridLength(3) } },
            //        ColumnDefinitions = { new ColumnDefinition() }
            //    };

            //    Label label = new Label { TextColor = Color.FromHex("#888888"), Text = kvp.Key, FontAttributes = FontAttributes.Bold, FontSize = 15, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };

            //    BoxView boxView = new BoxView { Color = Color.White };
            //    //if (kvp.Value == selected_category)
            //    //{
            //    //    label.TextColor = Color.FromHex("#439564");
            //    //    boxView.Color = Color.FromHex("#439564");
            //    //}

            //    var label_page_switcher_tap_recognizer = new TapGestureRecognizer();
            //    label_page_switcher_tap_recognizer.Tapped += (sender, e) =>
            //    {
            //        var t = sender;
            //    };

            //    label.GestureRecognizers.Add(label_page_switcher_tap_recognizer);

            //    var boxview_page_switcher_tap_recognizer = new TapGestureRecognizer();
            //    boxview_page_switcher_tap_recognizer.Tapped += (sender, e) =>
            //    {
            //        var t = sender;
            //    };
            //    boxView.GestureRecognizers.Add(boxview_page_switcher_tap_recognizer);

            //    grid.Children.Add(label);

            //    //TBD grid.Children.Add(new NeatFrame { Content = boxView, CornerRadius = 2 }, 0, 1);

            //    var grid_page_switcher_tap_recognizer = new TapGestureRecognizer();
            //    grid_page_switcher_tap_recognizer.Tapped += (sender, e) =>
            //    {
            //        var t = sender;
            //    };
            //    grid.GestureRecognizers.Add(grid_page_switcher_tap_recognizer);

            //    Menu_Grid.Children.Add(grid, j, 0);
            //    j++;
            //}
        }
    }
}