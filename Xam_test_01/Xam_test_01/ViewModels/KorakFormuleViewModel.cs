using System.Collections;
using System.Threading.Tasks;
using System.Windows.Input;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class KorakFormuleViewModel
    {
        private readonly Vrijdnosti vrijednosti = new Vrijdnosti();

        public KorakFormuleViewModel()
        {
            KalkulatorButtonCommand = new Command<string>(async param =>
            {
                var lista = vrijednosti.PrazneVrijednosti(param);

                var vrijednost1 = await DisplayPrompt(DisplayNaslov($"{lista[0]}"), DisplayMessage($"{lista[1]}"));
                var vrijednost2 = await DisplayPrompt(DisplayNaslov($"{lista[2]}"), DisplayMessage($"{lista[3]}"));

                var jednoliko = new JednolikoPravocrtnoModel();
                var lokal = jednoliko.OdabirMetode(param, vrijednost1, vrijednost2);

                await Application.Current.MainPage.Navigation.PushAsync(new PrikazRjesenjaView("Rješenje zadatka", lokal.OdgovorArray, lokal.FormulaImage));
            });
        }

        private async Task<string> DisplayPrompt(string title, string message)
        {
            var unos = await Application.Current.MainPage.DisplayPromptAsync(title, message, keyboard: Keyboard.Numeric);
            return unos;
        }

        private string DisplayMessage(string mjernaJedinica)
        {
            return $"u mjernoj jedinici ({ mjernaJedinica })";
        }

        private string DisplayNaslov(string fizikalnaVelicina)
        {
            return $"Unesi vrijednost { fizikalnaVelicina }";
        }

        public ICommand KalkulatorButtonCommand { get; }
    }

}
