using SWDemo.Styles.Keys;
using Xamarin.Forms;

namespace SWDemo.Controls
{
    public class TitleSubtitleItem:StackLayout
    {
        public string TitleText { get { return (string)GetValue(TitleTextProperty); } set { SetValue(TitleTextProperty, value); } }
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
            nameof(TitleText),
            typeof(string),
            typeof(TitleSubtitleItem),
            string.Empty,
            propertyChanged: (s, o, n) =>
            {
                var sender = s as TitleSubtitleItem;
                if (sender == null)
                    return;
                sender.TitleLabel.Text = (string)n;
            });

        public string SubtitleText { get { return (string)GetValue(SubtitleTextProperty); } set { SetValue(SubtitleTextProperty, value); } }
        public static readonly BindableProperty SubtitleTextProperty = BindableProperty.Create(
            nameof(SubtitleText),
            typeof(string),
            typeof(TitleSubtitleItem),
            string.Empty,
            propertyChanged: (s, o, n) =>
            {
                var sender = s as TitleSubtitleItem;
                if (sender == null)
                    return;
                sender.SubtitleLabel.Text = (string)n;
            });

        Label TitleLabel;
        Label SubtitleLabel;

        public TitleSubtitleItem()
        {
            HorizontalOptions = LayoutOptions.Start;
            VerticalOptions = LayoutOptions.Center;
            Margin = 0;
            Padding = 0;
            Spacing = 0;

            TitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                FontAttributes = FontAttributes.Bold,
                TextColor = (Color)App.Current.Resources[ColorKeys.TextPrimary]
            };

            SubtitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                FontAttributes = FontAttributes.Italic,
                TextColor = (Color)App.Current.Resources[ColorKeys.TextHint]
            };

            Children.Add(TitleLabel);
            Children.Add(SubtitleLabel);
        }
    }
}
