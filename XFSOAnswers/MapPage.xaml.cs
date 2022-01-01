using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using System.Collections.ObjectModel;

namespace XFSOAnswers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage()
		{
			InitializeComponent();
			InitMap();
		}

		// Testing: in code so easier to examine properties.
		void InitMap()
		{
			Position position = new Position(36.9628066, -122.0194722);
			MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
			Map map = new Map(mapSpan);

			map.Pins.Add(new Pin { Label = "a" });
			map.Pins.Add(new Pin { Label = "b" });
			//NO map.Pins = pins;

			////TheLayout.Children.Add(map);
			//TheMap = map;

			// Can we overwrite existing elements?
			TheLabel = new Label { Text = "The Label" };
			TheLayout.ForceLayout();
		}
	}
}