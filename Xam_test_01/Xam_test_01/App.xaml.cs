using Xam_test_01.Models;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01
{
    public partial class App : Application
    {
        public App()
        {
            var pitanje = new Pitanje();

            InitializeComponent();

            MainPage = new NavigationPage(new TipView())
            {
                BarBackgroundColor = pitanje.NavigacijaDrugaBoja,
                BarTextColor = Color.Black,
                BackgroundColor = pitanje.GridBackColor
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
