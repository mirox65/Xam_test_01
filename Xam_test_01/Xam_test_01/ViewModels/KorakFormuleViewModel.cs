using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class KorakFormuleViewModel : INotifyPropertyChanged
    {
        private readonly RječnikFizikalnihVeličinaMjernihJedinica fizVeličine = new RječnikFizikalnihVeličinaMjernihJedinica();

        public KorakFormuleViewModel()
        {
            KalkulatorButtonCommand = new Command<string>(async param =>
            {
                var lista = fizVeličine.SetFizikalnihVeličina(param);
                var mj = MjernaJedinica;

                if (mj != null)
                {

                    var mjerna = fizVeličine.FzikalneMjerneJediniceRiječnik(mj);

                    var vrijednost1 = Convert.ToDouble(await  DisplayPrompt(DisplayNaslov($"{lista[0]}"), DisplayMessage($"{ mjerna.First(x => x.Key == lista[0].ToString()).Value}")));
                    var vrijednost2 = Convert.ToDouble(await DisplayPrompt(DisplayNaslov($"{lista[1]}"), DisplayMessage($"{ mjerna.First(x => x.Key == lista[1].ToString()).Value}")));

                    var jednoliko = new JednolikoPravocrtnoPitanjeModel();
                    var tijelo = StvoriTijelo(param, vrijednost1, vrijednost2, mj);
                    var lokal = jednoliko.OdabirMetode(param, tijelo);

                    await Application.Current.MainPage.Navigation.PushAsync(new PrikazRjesenjaView("Rješenje zadatka", lokal.OdgovorArray, lokal.FormulaImage));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Upozorenje", "Odaberi veličinu mjernih jedinica!", "Cancel");
                }
            });
        }

        private IPravocrtnoTijeloModel StvoriTijelo(string param, double vrijednost1, double vrijednost2, string mj)
        {
            double put = 0;
            double brzina = 0;
            double vrijeme = 0;

            if (param == "Svt")
            {
                brzina = vrijednost1;
                vrijeme = vrijednost2;
            }
            else if (param == "Vst")
            {
                put = vrijednost1;
                vrijeme = vrijednost2;
            }
            else
            {
                put = vrijednost1;
                brzina = vrijednost2;
            }

            return new PravocrtnoTijeloModel
            {
                BrzinaVrijednost = brzina,
                PutVrijednost = put,
                VrijemeVrijednost = vrijeme,
                VeličinaMjerneJedinice = mj
            };
        }

        private string mjernaJedinica;

        public event PropertyChangedEventHandler PropertyChanged;

        public string MjernaJedinica
        {
            get => mjernaJedinica;
            set
            { 
                mjernaJedinica = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
