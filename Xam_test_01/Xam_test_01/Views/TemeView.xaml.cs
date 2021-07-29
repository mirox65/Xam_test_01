using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xam_test_01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemeView : ContentPage
    {
        private readonly string kinematika = "Kinematika";
        private readonly string dinamika = "Dinamika";

        public TemeView()
        {
            var zajednickiElementi = new ZajednickiElementiAplikacije();
            BindingContext = new TemeViewModel();

            Title = "Grane fizike";

            var temaKinematikaButton = zajednickiElementi.PrimarniNavigacijskiButton(kinematika);
            temaKinematikaButton.SetBinding(Button.CommandProperty, nameof(TemeViewModel.TemeKinematikaCommand));

            var temaDinamikaButton = zajednickiElementi.PrimarniNavigacijskiButton(dinamika);
            temaDinamikaButton.SetBinding(Button.CommandProperty, nameof(TemeViewModel.TemeDinamikaCommand));

            Content = new StackLayout
            {
                Children =
                {
                    temaKinematikaButton,
                    temaDinamikaButton
                },
                Margin = new Thickness(0, 10, 0, 0)
            };
        }
    }
}