using Xamarin.Forms;

namespace SWDemo.ViewModels.WebPage
{
    public class WebPageViewModel:ViewModelBase
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value;
                OnPropertyChanged();
            }
        }

        public Command ClosePageCommand { get; set; }

        public WebPageViewModel(string url, Page context):base(context)
        {
            ClosePageCommand = new Command(async () => await Navigation.PopAsync());
            this.Url = url;
        }
    }
}
