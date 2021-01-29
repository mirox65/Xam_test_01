using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TipView())
            {
                BarBackgroundColor = Color.DarkOrange
            };
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
