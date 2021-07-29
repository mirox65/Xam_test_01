using Xam_test_01.Pomocne;
using Xam_test_01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipView : ContentPage
    {
        public TipView()
        {
            var zajednickiElementi = new ZajednickiElementiAplikacije();

            BindingContext = new TipViewModel();

            Title = "Tip vježbe";

            var pitanjaButton = zajednickiElementi.PrimarniNavigacijskiButton("Generator pitanja");
            pitanjaButton.SetBinding(Button.CommandProperty, nameof(TipViewModel.PitanjeCommand));

            var korakButton = zajednickiElementi.PrimarniNavigacijskiButton("Korak po korak");
            korakButton.SetBinding(Button.CommandProperty, nameof(TipViewModel.KorakCommand));

            Content = new StackLayout
            {
                Children =
                {
                    pitanjaButton,
                    korakButton
                }
                ,
                Margin = new Thickness(0,10,0,0)
            };
        }
    }
}