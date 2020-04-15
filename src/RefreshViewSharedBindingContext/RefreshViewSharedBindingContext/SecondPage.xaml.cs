using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DIPS.Xamarin.UI.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RefreshViewSharedBindingContext
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }
    }

    public class SecondPageViewModel : INotifyPropertyChanged
    {
        private bool m_isRefreshing;

        public bool IsRefreshing
        {
            get => m_isRefreshing;
            set => PropertyChanged.RaiseWhenSet(ref m_isRefreshing, value);
        }

        public ICommand RefreshCommand => new Command(
            async () =>
            {
                await Task.Delay(1500);
                IsRefreshing = false;
            }
            );

        public event PropertyChangedEventHandler PropertyChanged;
    }
}