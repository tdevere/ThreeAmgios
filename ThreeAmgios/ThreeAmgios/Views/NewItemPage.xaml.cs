using System;
using System.Collections.Generic;
using System.ComponentModel;
using ThreeAmgios.Models;
using ThreeAmgios.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreeAmgios.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}