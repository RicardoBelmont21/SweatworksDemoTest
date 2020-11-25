using SWDemo.Styles.Keys;
using Xamarin.Forms;

namespace SWDemo.Controls
{
    public class Divider : BoxView
    {
        public Divider()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Color = (Color)App.Current.Resources[ColorKeys.Divider];
            Margin = new Thickness(0, 4);
            HeightRequest = 1;
        }
    }

    public class DividerHorizontal : BoxView
    {
        public DividerHorizontal()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            Color = (Color)App.Current.Resources[ColorKeys.Divider];
            Margin = new Thickness(4, 0);
            WidthRequest = 1;
        }
    }
}
