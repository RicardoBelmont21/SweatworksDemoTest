using System.ComponentModel;
using System.Runtime.CompilerServices;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace SWDemo.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public Command BackButtonCommand { get; set; }
        public INavigation Navigation { get; set; }
        public Page context { get; set; }
        public Page Alert { get; set; }
        public Command BackCommand { get; set; }

        public ViewModelBase(Page context)
        {
            this.Navigation = context.Navigation;
            this.context = context;
            this.Alert = context;
            BackCommand = new Command(() => OnBack());
            BackButtonCommand = new Command(async () => await Navigation.PopAsync());
        }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value != _isBusy)
                {
                    _isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
        }

        async void OnBack()
        {
            if (Device.RuntimePlatform == Device.iOS)
                await Navigation.PopAsync();
        }
    }
}
