using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FrameCornerRadius
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private double m_frameCornerRadius;
        private double m_frameHeightRequest;
        private double m_frameWidthRequest;

        public MainPage()
        {
            InitializeComponent();
        }

        public double FrameCornerRadius
        {
            get => m_frameCornerRadius;
            set
            {
                m_frameCornerRadius = value;
                OnPropertyChanged();
            }
        }

        public double FrameHeightRequest
        {
            get => m_frameHeightRequest;
            set
            {
                m_frameHeightRequest = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToWorkAroundCommand { get; } =
            new Command(() => Application.Current.MainPage.Navigation.PushAsync(new WorkAroundPage()));

        public double FrameWidthRequest
        {
            get => m_frameWidthRequest;
            set
            {
                m_frameWidthRequest = value; 
                OnPropertyChanged();
            }
        }
    }
}
