using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWDemo.Controls
{
    public class LazyListView : ListView
    {
        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(
            nameof(LoadMoreCommand),
            typeof(ICommand),
            typeof(LazyListView),
            default(ICommand),
            BindingMode.OneWay);
        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public LazyListView():base(ListViewCachingStrategy.RecycleElement)
        {
            ItemAppearing += LazyListView_ItemAppearing;
        }

        public LazyListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            ItemAppearing += LazyListView_ItemAppearing;
        }

        void LazyListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var items = ItemsSource as IList;
            if (items != null && e.Item == items[items.Count - 1])
            {
                if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                    LoadMoreCommand.Execute(null);
            }
        }
    }
}
