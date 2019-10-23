using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScrollView.OnMeasure.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {
            FilterInitializedCommand = new Command(FilterInitialize);    
        }

        private void FilterInitialize()
        {
            Items = new ObservableCollection<string>()
            {
                "First item",
                "Second item",
                "Third item",
                "Fourth item",
                "Fifth item"
            };
            OnPropertyChanged(nameof(Items));
        }

        public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();

        public ICommand FilterInitializedCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}