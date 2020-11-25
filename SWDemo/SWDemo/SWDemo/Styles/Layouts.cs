using Xamarin.Forms;

namespace SWDemo.Styles
{
    public static class Layouts
    {
        public static double Margin => DisplayXSizePX * .047;
        public static double Spacing => DisplayXSizePX * .047;
        public static Thickness Padding => new Thickness(12, 8);
        public static double DisplayXSizePX { get; set; }
        public static double DisplayYSizePX { get; set; }
        public static float DisplayScale { get; set; }
        public static double IconSize => 30;
        public static float FrameCornerRadius => 10;
        public static double FrameMaxSize => 230;
        public static double FrameSizePercentage => 42;
    }
}
