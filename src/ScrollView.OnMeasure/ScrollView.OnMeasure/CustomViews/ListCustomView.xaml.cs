using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScrollView.OnMeasure.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListCustomView : ContentView
    {
        public ListCustomView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            nameof(Items),
            typeof(IEnumerable<string>),
            typeof(ListCustomView));

        public IEnumerable<string> Items
        {
            get => (IEnumerable<string>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }
    }
}