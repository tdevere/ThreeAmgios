using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ThreeAmgios.ViewModels
{
    class AppCenterViewModel : BaseViewModel
    {
        public AppCenterViewModel()
        {
            Title = "Visual Studio App Center";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
