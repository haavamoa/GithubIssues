using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShapesInListWithFrame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            Device.SetFlags(
             new[]
             {
                    "Shapes_Experimental",
             });
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
