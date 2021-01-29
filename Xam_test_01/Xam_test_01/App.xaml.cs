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
                BarBackgroundColor = Color.FromRgb(40, 204, 255),
                BarTextColor = Color.Black
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
