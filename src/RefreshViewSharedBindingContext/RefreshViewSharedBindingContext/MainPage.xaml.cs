using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace RefreshViewSharedBindingContext
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private SecondPageViewModel m_secondPageViewModel = new SecondPageViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var page = new SecondPage() { BindingContext = m_secondPageViewModel };
            App.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
