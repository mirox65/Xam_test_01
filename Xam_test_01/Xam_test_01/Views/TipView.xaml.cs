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
            BindingContext = new TipViewModel();

            Title = "Tip vjezbe";

            var pitanjaButton = new Button
            {
                Text = "Generator pitanja",
                TextColor = Color.White,
                BackgroundColor = Color.FromRgb(233, 164, 22)
            };

            pitanjaButton.SetBinding(Button.CommandProperty, nameof(TipViewModel.PitanjeCommand));

            var korakButton = new Button
            {
                Text = "Korak po korak",
                TextColor = Color.White,
                BackgroundColor = Color.FromRgb(233, 164, 22)
            };

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