using SWDemo.ViewModels.DetailPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWDemo.Views.DetailPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPageView : Rg.Plugins.Popup.Pages.PopupPage
    {
        public DetailPageView(SWDemo.Models.Response.Books.Item selectedBook)
        {
            InitializeComponent();
            BindingContext = new DetailPageViewModel(selectedBook, this);

            //Popup annimation
            this.Animation = new Rg.Plugins.Popup.Animations.MoveAnimation()
            {
                PositionIn = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Bottom,
                PositionOut = Rg.Plugins.Popup.Enums.MoveAnimationOptions.Bottom,
                DurationOut = 400,
                DurationIn = 600,
                EasingIn = Easing.SpringOut
            };
        }
    }
}