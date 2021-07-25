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

            var grid = new Grid
            {
                Margin = new Thickness(10, 20),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1.0, GridUnitType.Star) }
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) }
                }
            };

            grid.Children.Add(pitanjaButton, 0, 0);
            grid.Children.Add(korakButton, 0, 1);

            Content = grid;
        }
    }
}