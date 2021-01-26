using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PrvaStranica())
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
