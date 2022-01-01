using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XFSOAnswers
{
	// Based on https://github.com/xamarin/xamarin-forms-samples/blob/main/WorkingWithMaps/WorkingWithMaps/WorkingWithMaps/PinPageCode.cs
	public class PinPageCode : ContentPage
	{
		public PinPageCode()
		{
			Title = "Pins demo";

			Position position = new Position(36.9628066, -122.0194722);
			MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);

			Map map = new Map(mapSpan);

			Pin pin = new Pin
			{
				Label = "Santa Cruz",
				Address = "The city with a boardwalk",
				Type = PinType.Place,
				Position = position
			};
			map.Pins.Add(pin);
			// ... more pins.

			Content = new StackLayout
			{
				Margin = new Thickness(10),
				Children =
				{
					map
				}
			};
		}
	}
}