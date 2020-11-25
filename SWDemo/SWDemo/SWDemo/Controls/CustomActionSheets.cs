using Rg.Plugins.Popup.Extensions;
using SWDemo.Styles;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SWDemo.Controls
{
    public class CustomActionSheets : Rg.Plugins.Popup.Pages.PopupPage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">popup title</param>
        /// <param name="options">Action, button text, button color, text color, option border color</param>
        public CustomActionSheets(string title, Tuple<Command, string, Color, Color, Color>[] options)
        {
            Animation = new Rg.Plugins.Popup.Animations.MoveAnimation()
            {
                PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Bottom,
                PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Bottom,
                DurationIn = 600,
                DurationOut = 600,
                EasingIn = Easing.SinIn,
                EasingOut = Easing.SinOut
            };

            Label titleLabel = new Label()
            {
                Text = title,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                FontAttributes = FontAttributes.Bold,
                FontSize = 32,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start
            };

            StackLayout sl = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, Layouts.Spacing/2),
                Orientation = options.Length > 2 ? StackOrientation.Vertical : StackOrientation.Horizontal
            };
            for (int x = 0; x < options.Length; x++)
            {
                sl.Children.Add(GetOption(options[x]));
            }
            Content = new Frame()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End,
                Padding = Layouts.Margin,
                HasShadow = false,
                CornerRadius = 0,
                BackgroundColor = Color.White,
                IsClippedToBounds = true,
                Content = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        titleLabel,sl
                    }
                }
            };

        }

        private View GetOption(Tuple<Command, string, Color, Color, Color> structure)
        {
            var button = new Button()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                CornerRadius = (int)Layouts.FrameCornerRadius,
                VerticalOptions = LayoutOptions.Center,
                Command = structure.Item1,
                Text = structure.Item2,
                BorderWidth = 2,
                TextColor = structure.Item4,
                BackgroundColor = structure.Item3,
                BorderColor = structure.Item5,
                HeightRequest = 45,
                MinimumHeightRequest = 45,
                FontSize = 14
            };
            return button;
        }

        public async Task DisplayActionSheet()
        {
            await Navigation.PushPopupAsync(this);
        }

        public async Task PopPopupAsync()
        {
            await Navigation.PopPopupAsync();
        }

        public async Task PopAllPopupAsync()
        {
            await Navigation.PopAllPopupAsync();
        }
    }
}
