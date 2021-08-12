using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xam_test_01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KorakFormuleView : ContentPage
    {
        public KorakFormuleView(string title)
        {
            var zajednickiElementi = new ZajednickiElementiAplikacije();

            BindingContext = new KorakFormuleViewModel();

            Title = title;

            var mjerneJedinice = new Button
            {
                Text = "Odaberi mjerne jedinici"
            };
            mjerneJedinice.Clicked += async (sender, args) =>
            {
               mjerneJedinice.CommandParameter =  await DisplayActionSheet("Odaber mjernu jedinicu", "Cancel", null, "m, s", "km, h");
            };
            mjerneJedinice.SetBinding(Button.CommandParameterProperty, nameof(KorakFormuleViewModel.MjernaJedinica), BindingMode.OneWayToSource);

            var brzinaButton = zajednickiElementi.FormulaNavButton(FormuleImageSource.VstFormulaImage, "Vst");
            brzinaButton.SetBinding(Button.CommandProperty, nameof(KorakFormuleViewModel.KalkulatorButtonCommand));

            var vrijemeButton = zajednickiElementi.FormulaNavButton(FormuleImageSource.TsvFormulaImage, "Tsv");
            vrijemeButton.SetBinding(Button.CommandProperty, nameof(KorakFormuleViewModel.KalkulatorButtonCommand));

            var putButton = zajednickiElementi.FormulaNavButton(FormuleImageSource.SvtFormulaImage, "Svt");
            putButton.SetBinding(Button.CommandProperty, nameof(KorakFormuleViewModel.KalkulatorButtonCommand));

            Content = new StackLayout
            {
                Children =
                {
                    mjerneJedinice,
                    brzinaButton,
                    vrijemeButton,
                    putButton
                },
                Margin = new Thickness(0, 10, 0, 0)
            };
        }
    }
}