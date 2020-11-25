using SWDemo.ViewModels.WebPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWDemo.Views.WebRenderer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPageView : ContentPage
    {
        public WebPageView(string Url)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new WebPageViewModel(Url, this);
        }
    }
}