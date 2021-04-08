using System.ComponentModel;
using ThreeAmgios.ViewModels;
using Xamarin.Forms;

namespace ThreeAmgios.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}