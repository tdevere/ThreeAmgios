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
using Microsoft.AppCenter.Distribute;

namespace ThreeAmgios.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppCenterPage : ContentPage
    {
        string staticGuid = "7c56fce6-aca9-40ac-963f-3f39e3a0b0d4";
        
        public AppCenterPage()
        {
            InitializeComponent();
            BindingContext = new AppCenterPageViewModel();
        }


        public void OnInternalTrackEventButtonOnClicked(object sender, EventArgs e)
        {

            Analytics.TrackEvent(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //string msg = string.Format("tdevere {0} time: {1}", staticGuid, DateTime.Now.Ticks.ToString());
            //Analytics.TrackEvent(msg);
            //Analytics.TrackEvent(System.Reflection.MethodBase.GetCurrentMethod().Name);
            //AppEvents.Instance.AddEvent(EventName.Event_010, System.Reflection.MethodBase.GetCurrentMethod().Name); //Start Method



            //Do Work
            //AppEvents.Instance.AddEvent(EventName.Event_010, System.Reflection.MethodBase.GetCurrentMethod().Name); //End Method
        }
        
        private void OnCheckForNewRelease(object sender, EventArgs e)
        {
            Analytics.TrackEvent(System.Reflection.MethodBase.GetCurrentMethod().Name);
            Analytics.TrackEvent("CheckForUpdate");
            Distribute.CheckForUpdate();

        }

        private void OnCrashButtonOnClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent(System.Reflection.MethodBase.GetCurrentMethod().Name);
            //Start Function
            //AppEvents.Instance.AddEvent(EventName.Event_011);

            //Step 1            
            int x = 1;
            //AppEvents.Instance.AddEvent(EventName.Event_011, $"STEP1 x = {x}");

            //Step 2            
            int y = 0;
            //AppEvents.Instance.AddEvent(EventName.Event_011, $"STEP2 y = {y}");

            //Step 3            
            int result = x / y; //Boom            
            //AppEvents.Instance.AddEvent(EventName.Event_011, $"STEP3 result = {result}");
        }

        private void OnNewCrashGroupOnClicked1(object sender, EventArgs e)
        {
            Analytics.TrackEvent(System.Reflection.MethodBase.GetCurrentMethod().Name);
            //Start Function
            //AppEvents.Instance.AddEvent(EventName.Event_011);

            //Step 1            
            int x = 1;
            //AppEvents.Instance.AddEvent(EventName.Event_011, $"STEP1 x = {x}");

            //Step 2            
            int y = 0;
            //AppEvents.Instance.AddEvent(EventName.Event_011, $"STEP2 y = {y}");

            //Step 3            
            int result = x / y; //Boom            
            //AppEvents.Instance.AddEvent(EventName.Event_011, $"STEP3 result = {result}");
        }
    }
}