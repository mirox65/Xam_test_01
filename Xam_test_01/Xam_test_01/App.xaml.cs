using Xam_test_01.Pomocne;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01
{
    public partial class App : Application
    {
        public App()
        {
            var zajednickiElementi = new ZajednickiElementiAplikacije();

            InitializeComponent();

            MainPage = new NavigationPage(new TipView())
            {
                BarBackgroundColor = zajednickiElementi.NavigacijaDrugaBoja,
                BarTextColor = Color.Black,
                BackgroundColor = zajednickiElementi.GridBackColor,
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
