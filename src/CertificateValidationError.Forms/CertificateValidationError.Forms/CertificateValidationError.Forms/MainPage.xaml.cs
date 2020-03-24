using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CertificateValidationError.Forms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient m_httpClient;
        private readonly HttpClientHandler m_handler;

        public MainPage()
        {
            m_handler = new HttpClientHandler();
            m_httpClient = new HttpClient(m_handler);
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    ServicePointManager.ServerCertificateValidationCallback = (o, certificate, chain, errors) => true;
                }
                else
                {
                    m_handler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
                }

                var response = m_httpClient.GetAsync("https://self-signed.badssl.com/");
                HttpResponseLabel.Text = await response.Result.Content.ReadAsStringAsync();
            }
            catch (Exception exception)
            {
                HttpResponseLabel.Text = exception.Message;
            }
        }
    }
}
