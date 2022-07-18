using LoginClient.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LoginClient.Views
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