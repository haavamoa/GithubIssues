using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarouselViewObservableCollection
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class ViewModel
    {

        public ViewModel()
        {
            AddCommand = new Command(() =>
            {
                Items.Add($"Items {Items.Count}");
                ((Command)RemoveLastCommand).ChangeCanExecute();
            });
            RemoveLastCommand = new Command(() =>
            {
                Items.Remove(Items.Last());
                ((Command)RemoveLastCommand).ChangeCanExecute();

                // Workaround
                //if(!(Items.Any()))
                //{
                //    Items = new ObservableCollection<string>();
                //}

            }, () => Items.Any());
        }

        public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();

        public ICommand AddCommand { get; }
        public ICommand RemoveLastCommand { get; }
    }
}
