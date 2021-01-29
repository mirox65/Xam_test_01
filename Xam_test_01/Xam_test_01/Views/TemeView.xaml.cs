using Xam_test_01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemeView : ContentPage
    {
        public TemeView()
        {
            BindingContext = new TemeViewModel();

            Title = "Teme";

            var temaKinematikaButton = new Button
            {
                Text = "Kinematika",
                BackgroundColor = Color.FromRgb(255, 204, 153)
            };

            temaKinematikaButton.SetBinding(Button.CommandProperty, nameof(TemeViewModel.TemeKinematikaCommand));

            var temaDinamikaButton = new Button
            {
                Text = "Dinamika",
                BackgroundColor = Color.FromRgb(255, 204, 153)
            };

            temaDinamikaButton.SetBinding(Button.CommandProperty, nameof(TemeViewModel.TemeDinamikaCommand));

            var grid = new Grid
            {
                Margin = new Thickness(10,20),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) }
                }
            };

            grid.Children.Add(temaKinematikaButton, 0, 0);
            grid.Children.Add(temaDinamikaButton, 0, 1);

            Content = grid;
        }
    }
}