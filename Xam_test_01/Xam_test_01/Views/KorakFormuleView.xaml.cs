using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KorakFormuleView : ContentPage
    {
        public KorakFormuleView()
        {
            var zajednickiElementi = new ZajednickiElementiAplikacije();
            var slikeFormula = new KorakFormuleModel();

            Title = "Kinematika";

            var brzinaButton = zajednickiElementi.FormulaNavButton(slikeFormula.KinematikaFormulaBrzina);

            var vrijemeButton = zajednickiElementi.FormulaNavButton(slikeFormula.KinematikaFormulaVrijeme);

            var putButton = zajednickiElementi.FormulaNavButton(slikeFormula.KinematikaFormulaPut);

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