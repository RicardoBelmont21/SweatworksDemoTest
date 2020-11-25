using SWDemo.Utilities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using SWDemo.Styles.Keys;
using SWDemo.Controls;
using SWDemo.Views.DetailPage;
using Rg.Plugins.Popup.Extensions;

namespace SWDemo.ViewModels.SearchPage
{
    public class SearchPageViewModel:ViewModelBase
    {
        private string _keywordBackup;
        private int page = 0;
        private string _keyword;
        public string Keyword
        {
            get { return _keyword; }
            set { 
                _keyword = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Models.Response.Books.Item> _books;
        public ObservableCollection<Models.Response.Books.Item> Books
        {
            get { return _books; }
            set { _books = value;
                OnPropertyChanged();
            }
        }

        public Command SearchCommand { get; set; }
        public Command LoadMoreCommand { get; set; }
        public Command ItemSelectedCommand { get; set; }

        public SearchPageViewModel(Page context):base(context)
        {
            SearchCommand = new Command(async () => await GetBooks(this.Keyword, 0));
            LoadMoreCommand = new Command(async () => await GetBooks(_keywordBackup, page));
            ItemSelectedCommand = new Command(async (param) => await OnItemSelected(param as Models.Response.Books.Item));
            Books = new ObservableCollection<Models.Response.Books.Item>();
        }

        //Call API Repository to get all books or the next page
        private async Task GetBooks(string keyword, int currentPage)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                CustomActionSheets actionSheet = null;
                var btcolor = (Color)App.Current.Resources[ColorKeys.Primary];
                actionSheet = new CustomActionSheets(Labels.Labels.NotValidWord, new System.Tuple<Command, string, Color, Color, Color>[] {
                                    new System.Tuple<Command, string, Color, Color, Color>(new Command(async()=>
                                    {
                                       await actionSheet.PopPopupAsync(); 
                                    }), 
                                    Labels.Labels.OK, btcolor, Color.White, btcolor)});
                await actionSheet.DisplayActionSheet();
                return;
            }
            IsBusy = true;
            var books = await new ApiRepository().GetBooksByKeyword(keyword, currentPage);
            if (currentPage == 0)
            {
                _keywordBackup = keyword;
                page = 0;
                Books.Clear();
            }

            if (!books.Success || books.Items == null)
            {
                CustomActionSheets actionSheet = null;
                var btcolor = (Color)App.Current.Resources[ColorKeys.Primary];
                actionSheet = new CustomActionSheets(Labels.Labels.NoMoreResults, new System.Tuple<Command, string, Color, Color, Color>[] {
                                    new System.Tuple<Command, string, Color, Color, Color>(new Command(async()=>
                                    {
                                       await actionSheet.PopPopupAsync();
                                    }),
                                    Labels.Labels.OK, btcolor, Color.White, btcolor)});
                await actionSheet.DisplayActionSheet();
                IsBusy = false;
                return;
            }

            books.Items.ToList().ForEach(b =>
            {
                if (string.IsNullOrWhiteSpace(b.VolumeInfo.ImageLinks?.SmallThumbnail) || string.IsNullOrWhiteSpace(b.VolumeInfo.ImageLinks?.Thumbnail))
                {
                    b.VolumeInfo.ImageLinks = new Models.Common.ImageLinks()
                    {
                        Thumbnail = (string)App.Current.Resources[IconKeys.Book],
                        SmallThumbnail = (string)App.Current.Resources[IconKeys.Book]
                    };
                }
                Books.Add(b);
            });
            IsBusy = false;
            page++;
        }
    
        private async Task OnItemSelected(Models.Response.Books.Item book)
        {
            var page = new DetailPageView(book);
            await Navigation.PushPopupAsync(page);
        }
    }
}
