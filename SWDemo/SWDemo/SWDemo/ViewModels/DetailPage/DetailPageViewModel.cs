using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using SWDemo.Controls;
using SWDemo.Styles.Keys;
using SWDemo.Views.WebRenderer;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SWDemo.ViewModels.DetailPage
{
    public class DetailPageViewModel:ViewModelBase
    {
        private SWDemo.Models.Response.Books.Item _book;
        public SWDemo.Models.Response.Books.Item Book
        {
            get { return _book; }
            set { _book = value;
                OnPropertyChanged();
            }
        }

        public Command ClosePageCommand { get; set; }
        public Command OpenLinkCommand { get; set; }

        public DetailPageViewModel(SWDemo.Models.Response.Books.Item selectedBook, PopupPage context):base(context)
        {
            ClosePageCommand = new Command(async () => await Navigation.PopAllPopupAsync());
            OpenLinkCommand = new Command(async() => await OnOpenLink());
            this.Book = selectedBook;
        }

        public async Task OnOpenLink()
        {
            string link = Book.VolumeInfo.PreviewLink;
            var btcolor = (Color)App.Current.Resources[ColorKeys.Primary];
            if (string.IsNullOrEmpty(link))
            {
                CustomActionSheets invalidActionSheet = null;
                invalidActionSheet = new CustomActionSheets(Labels.Labels.LinkNotAvailable, new System.Tuple<Command, string, Color, Color, Color>[] {
                                    new System.Tuple<Command, string, Color, Color, Color>(new Command(async()=>
                                    {
                                       await invalidActionSheet.PopPopupAsync();
                                    }),
                                    Labels.Labels.OK, btcolor, Color.White, btcolor)});
                await invalidActionSheet.DisplayActionSheet();
                return;
            }
            CustomActionSheets actionSheet = null;
            actionSheet = new CustomActionSheets(Labels.Labels.HowOpen, new System.Tuple<Command, string, Color, Color, Color>[] {
                                    new System.Tuple<Command, string, Color, Color, Color>(new Command(async()=>
                                    {
                                        await Launcher.OpenAsync(new System.Uri(link));
                                        await actionSheet.PopPopupAsync();
                                    }),
                                    Labels.Labels.PhoneBrowser, btcolor, Color.White, btcolor),
                                    new System.Tuple<Command, string, Color, Color, Color>(new Command(async()=>
                                    {
                                        var webPage=new WebPageView(link);
                                        await Navigation.PushAsync(webPage);
                                        await actionSheet.PopAllPopupAsync();
                                    }),
                                    Labels.Labels.App, btcolor, Color.White, btcolor)
            });
            await actionSheet.DisplayActionSheet();
            return;

        }
    }
}
