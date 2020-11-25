using SWDemo.Styles.Keys;
using Xamarin.Forms;

namespace SWDemo.Styles
{
    public static class Fonts
    {
        public static double ExtraSmallSize => Device.GetNamedSize(NamedSize.Micro, typeof(Label)) + 1 + FontSizeAdded;
        public static double SmallSize => Device.GetNamedSize(NamedSize.Small, typeof(Label)) - 1 + FontSizeAdded;
        public static double MediumSize => Device.GetNamedSize(NamedSize.Medium, typeof(Label)) - 2 + FontSizeAdded;
        public static double LargeSize => Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 1 + FontSizeAdded;
        public static double ExtraLargeSize => Device.GetNamedSize(NamedSize.Large, typeof(Label)) + 3 + FontSizeAdded;
        public static double ExtraExtraLargeSize => Device.GetNamedSize(NamedSize.Large, typeof(Label)) + 12 + FontSizeAdded;

        public static double FontSizeAdded = 0;

        public static System.Collections.Generic.Dictionary<string, double> GetFontsDictionary()
        {
            var d = new System.Collections.Generic.Dictionary<string, double>();
            d.Add(FontKeys.ExtraSmallSize, ExtraSmallSize);
            d.Add(FontKeys.SmallSize, SmallSize);
            d.Add(FontKeys.MediumSize, MediumSize);
            d.Add(FontKeys.LargeSize, LargeSize);
            d.Add(FontKeys.ExtraLargeSize, ExtraLargeSize);
            d.Add(FontKeys.ExtraExtraLargeSize, ExtraExtraLargeSize);
            return d;
        }
    }
}
