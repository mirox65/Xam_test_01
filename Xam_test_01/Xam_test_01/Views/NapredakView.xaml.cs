using Xam_test_01.Pomocne;
using Xam_test_01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NapredakView : ContentPage
    {
        private readonly ZajednickiElementiAplikacije zajednickiElementi = new ZajednickiElementiAplikacije();

        public NapredakView(string grana)
        {
            BindingContext = new NapredakViewModel(grana);

            Title = $"{grana} napredak";

            var razina = new Label
            {
                TextColor = Color.DarkOrange,
                FontSize = 50,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 50)
            };
            razina.SetBinding(Label.TextProperty, nameof(NapredakViewModel.Razina));

            var ukupnoPitanja = new Label
            {
                TextColor = Color.DarkSlateGray,
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 50)
            };
            ukupnoPitanja.SetBinding(Label.TextProperty, nameof(NapredakViewModel.Ukupno));

            var postotak = new Label
            {
                TextColor = Color.DarkSlateGray,
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 50)
            };
            postotak.SetBinding(Label.TextProperty, nameof(NapredakViewModel.Postotak));

            var razina2 = new Label
            {
                Text = "Razina 2 min 10 odgovora i postotak > 60%",
                TextColor = Color.DarkSlateGray,

            };

            var razina3 = new Label
            {
                Text = "Razina 3 min  20 odgovora na razini 2 i postotak > 60%",
                TextColor = Color.DarkSlateGray,
            };

            var nazad = zajednickiElementi.OtherButton("Nazad");
            nazad.HeightRequest = 70;
            nazad.SetBinding(Button.CommandProperty, nameof(NapredakViewModel.NazadCommand));

            var stack = new StackLayout
            {
                Children =
                {
                    razina,
                    ukupnoPitanja,
                    postotak,
                    razina2,
                    razina3,
                },
                VerticalOptions = LayoutOptions.Center
            };

            var grid = new Grid
            {
                Margin = new Thickness(10, 10),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(70 , GridUnitType.Absolute) }
                }
            };

            grid.Children.Add(stack, 0, 0);

            grid.Children.Add(nazad, 0, 1);

            Content = grid;
        }
    }
}