using SWDemo.Styles.Keys;
using SWDemo.ViewModels;
using System;
using Xamarin.Forms;

namespace SWDemo.Controls
{
    public class LoadingView : Frame
    {
        public bool IsRunning { get { return (bool)GetValue(IsRunningProperty); } set { SetValue(IsRunningProperty, value); } }
        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(
            nameof(IsRunning),
            typeof(bool),
            typeof(LoadingView),
            false,
            BindingMode.TwoWay,
            propertyChanged: (s, o, n) =>
            {
                var control = (s as LoadingView);
                if (control == null) return;
                control.IsVisible = (bool)n;
            });

        public LoadingView()
        {
            CornerRadius = 5;
            VerticalOptions = LayoutOptions.Center;
            HorizontalOptions = LayoutOptions.Center;
            BackgroundColor = (Color)App.Current.Resources[ColorKeys.Primary];
            HasShadow = Device.RuntimePlatform == Device.iOS ? false : true;
            BorderColor = (Color)App.Current.Resources[ColorKeys.TextGreen];

            Content = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Color = (Color)App.Current.Resources[ColorKeys.TextGreen],
                IsRunning = true
            };

            BindingContextChanged += LoadingIndicatorControl_BindingContextChanged;
            IsVisible = false;
        }


        private void LoadingIndicatorControl_BindingContextChanged(object sender, EventArgs e)
        {
            var baseContext = BindingContext as ViewModelBase;
            if (baseContext == null) return;
            baseContext.PropertyChanged += (sen, eve) =>
            {
                if (eve.PropertyName == nameof(ViewModelBase.IsBusy))
                {
                    IsRunning = baseContext.IsBusy;
                }
            };
        }
    }
}
