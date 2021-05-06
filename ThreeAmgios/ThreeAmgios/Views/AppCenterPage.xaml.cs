using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeAmgios.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace ThreeAmgios.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppCenterPage : ContentPage
    {
        public AppCenterPage()
        {
            InitializeComponent();
            BindingContext = new AppCenterPageViewModel();
        }


        public void OnInternalTrackEventButtonOnClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent($"Hello World here's the time: {DateTime.Now.ToLongTimeString()}");
        }

        private void OnCrashButtonOnClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("OnCrashButtonOnClicked");
            int x = 1;
            int y = 0;
            int result = x / y;
            Analytics.TrackEvent("OnCrashButtonOnClicked_Finnished");
        }
    }
}