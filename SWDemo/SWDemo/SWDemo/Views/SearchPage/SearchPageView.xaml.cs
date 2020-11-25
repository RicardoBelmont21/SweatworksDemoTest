using SWDemo.ViewModels.SearchPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace SWDemo.Views.SearchPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPageView : ContentPage
    {
        public SearchPageView()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new SearchPageViewModel(this);
            On<iOS>().SetUseSafeArea(true);
        }
    }
}