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
                    brzinaButton,
                    vrijemeButton,
                    putButton
                },
                Margin = new Thickness(0, 10, 0, 0)
            };
        }
    }
}