using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Xam_test_01
{
    public partial class MainPage : ContentPage
    {
        readonly Formula formula = new Formula();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            prvaNepoznanica.IsVisible = false;
            drugaNepoznanica.IsVisible = false;
            trecaNepoznanica.IsVisible = false;
            odgovor.IsVisible = false;
            formula.GeneriranjePitanja();
            pitanje.Text = formula.Pitanje;
            gumbOdgovor.IsVisible = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            prvaNepoznanica.Text = formula.PrvaNepoznanica;
            drugaNepoznanica.Text = formula.DrugaNepoznanica;
            odgovor.Text = formula.Odgovor;
            prvaNepoznanica.IsVisible = true;
            drugaNepoznanica.IsVisible = true;
            trecaNepoznanica.IsVisible = true;
            odgovor.IsVisible = true;
            gumbOdgovor.IsVisible = false;
        }
    }
}
