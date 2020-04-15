using DIPS.Xamarin.UI;
using Xamarin.Forms;

namespace RefreshViewSharedBindingContext
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Library.Initialize();

            MainPage = new NavigationPage(new MainPage());
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
    }
}
