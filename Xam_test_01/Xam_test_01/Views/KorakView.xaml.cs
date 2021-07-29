using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xam_test_01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KorakView : ContentPage
    {
        public KorakView()
        {
            var zajednickiElementi = new ZajednickiElementiAplikacije();

            BindingContext = new KorakViewModel();

            Title = "Korak po korak";

            var kinematikaButton = zajednickiElementi.PrimarniNavigacijskiButton("Kinematika");
            kinematikaButton.SetBinding(Button.CommandProperty, nameof(KorakViewModel.KinematikaCommand));

            Content = new StackLayout
            {
                Children =
                {
                    kinematikaButton
                },
                Margin = new Thickness(0, 10, 0, 0)
            };
        }
    }
}