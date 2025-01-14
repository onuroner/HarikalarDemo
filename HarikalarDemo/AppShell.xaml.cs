using HarikalarDemo.Views;

namespace HarikalarDemo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("WebcamPage", typeof(WebcamPage));
            Routing.RegisterRoute("PhotoResultPage", typeof(PhotoResultPage));
            InitializeComponent();
        }

        
    }
}
