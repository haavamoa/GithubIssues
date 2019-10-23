using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScrollView.OnMeasure.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterCustomView : ContentView
    {
        public FilterCustomView()
        {
            InitializeComponent();
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (!m_isInitialized)
            {
                Command?.Execute(null);
                m_isInitialized = true;
            }
            return base.OnMeasure(widthConstraint, heightConstraint);
        }


        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(FilterCustomView));

        private bool m_isInitialized;

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
    }
}