
using HarikalarDemo.Views;
using System.Windows.Input;

namespace HarikalarDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WebcamPage());
        }
    }

}
