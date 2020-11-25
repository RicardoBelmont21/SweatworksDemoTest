using SWDemo.Styles.ThemesDefinitions;
using SWDemo.Views.SearchPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            App.SetTheme();
            MainPage = new NavigationPage(new SearchPageView()); 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        //TODO: Generic darkmode depending on Sweatworks reqs
        public static void SetTheme()
        {
            App.Current.Resources.MergedDictionaries.Clear();
            App.Current.Resources.MergedDictionaries.Add(new LightThemeDefinition());
            SetFontSizes(1);
        }
        public static void SetFontSizes(double level)
        {
            Styles.Fonts.FontSizeAdded = level * 2;
            var resources = Current.Resources;
            foreach (var item in Styles.Fonts.GetFontsDictionary())
            {
                if (resources.ContainsKey(item.Key)) resources.Remove(item.Key);
                resources.Add(item.Key, item.Value);
            }
        }
    }
}
