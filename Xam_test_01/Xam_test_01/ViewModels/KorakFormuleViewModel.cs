using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Input;
using Xam_test_01.Pomocne;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class KorakFormuleViewModel
    {
        public KorakFormuleViewModel()
        {
            BrzinaButtonCommand = new Command<string>(async param =>
            {
                var brzina = FizikalneVeličine.Brzina;
                var metarSekunda = MjerneJedinice.MetarSekunda;
                var put = FizikalneVeličine.Put;
                var metar = MjerneJedinice.Metar;
                var vrijeme = FizikalneVeličine.Vrijeme;
                var sekunda = MjerneJedinice.Sekunda;
                var formula = FormuleImageSource.KinematikaFormulaBrzina;

                var putVrijednost = ConvertToDouble(await DisplayPrompt(DisplayNaslov(put), DisplayMessage(metar)));
                var vrijemeVrijednost = ConvertToDouble(await DisplayPrompt(DisplayNaslov(vrijeme), DisplayMessage(sekunda)));

                var rezultat = Formule.VstFormula(putVrijednost, vrijemeVrijednost);

                var odgovorArray = ListaOdgovora(Vrijednost(put, putVrijednost, metar),
                                                    Vrijednost(vrijeme, vrijemeVrijednost, sekunda),
                                                    StoRacunamo(brzina),
                                                    Odgovor(brzina, rezultat, metarSekunda));

                await Application.Current.MainPage.Navigation.PushAsync(new PrikazRjesenjaView(param, odgovorArray, formula));
            });

            VrijemeButtonCommand = new Command<string>(async param =>
            {
                var brzina = FizikalneVeličine.Brzina;
                var metarSekunda = MjerneJedinice.MetarSekunda;
                var put = FizikalneVeličine.Put;
                var metar = MjerneJedinice.Metar;
                var vrijeme = FizikalneVeličine.Vrijeme;
                var sekunda = MjerneJedinice.Sekunda;
                var formula = FormuleImageSource.KinematikaFormulaVrijeme;

                var putVrijednost = ConvertToDouble(await DisplayPrompt(DisplayNaslov(put), DisplayMessage(metar)));
                var brzinaVrijednost = ConvertToDouble(await DisplayPrompt(DisplayNaslov(brzina), DisplayMessage(metarSekunda)));

                var rezultat = Formule.TsvFormula(putVrijednost, brzinaVrijednost);

                var odgovorArray = ListaOdgovora(Vrijednost(put, putVrijednost, metar),
                                                    Vrijednost(brzina, brzinaVrijednost, metarSekunda),
                                                    StoRacunamo(vrijeme),
                                                    Odgovor(vrijeme, rezultat, sekunda));

                await Application.Current.MainPage.Navigation.PushAsync(new PrikazRjesenjaView(param, odgovorArray, formula));
            });

            PutButtonCommand = new Command<string>(async param =>
            {
                var brzina = FizikalneVeličine.Brzina;
                var metarSekunda = MjerneJedinice.MetarSekunda;
                var put = FizikalneVeličine.Put;
                var metar = MjerneJedinice.Metar;
                var vrijeme = FizikalneVeličine.Vrijeme;
                var sekunda = MjerneJedinice.Sekunda;
                var formula = FormuleImageSource.KinematikaFormulaPut;

                var brzinaVrijednost = ConvertToDouble(await DisplayPrompt(DisplayNaslov(brzina), DisplayMessage(metarSekunda)));
                var vrijemeVrijednost = ConvertToDouble(await DisplayPrompt(DisplayNaslov(vrijeme), DisplayMessage(sekunda)));

                var rezultat = Formule.SvtFormula(brzinaVrijednost, vrijemeVrijednost);

                var odgovorArray = ListaOdgovora(Vrijednost(brzina, brzinaVrijednost, metarSekunda),
                                                    Vrijednost(vrijeme, vrijemeVrijednost, sekunda),
                                                    StoRacunamo(put),
                                                    Odgovor(put, rezultat, metar));

                await Application.Current.MainPage.Navigation.PushAsync(new PrikazRjesenjaView(param, odgovorArray, formula));
            });
        }

        private async Task<string> DisplayPrompt(string title, string message)
        {
            var unos = await Application.Current.MainPage.DisplayPromptAsync(title, message);
            return unos;
        }

        public ICommand BrzinaButtonCommand { get; }
        public ICommand VrijemeButtonCommand { get; }
        public ICommand PutButtonCommand { get; }

        #region  Prebaci u novu klasu generiranje riješenja ili tako neki naziv

        /// <summary>
        /// Ovo sve treba prebaciti u Folder pommoćne i napraviti klasu koju će koristiti sve metode Kinematike (i budući grana npr. Dinamika) i Korak-a
        /// Za generiranje pitanja i sličnih stvari
        ///
        /// </summary>
        /// <param name="fizikalnaVelicina"></param>
        /// <param name="rezultat"></param>
        /// <param name="mjernaJedinica"></param>
        /// <returns></returns>

        private string Odgovor(string fizikalnaVelicina, double rezultat, string mjernaJedinica)
        {
            return $"{ fizikalnaVelicina } = { rezultat } { mjernaJedinica }";
        }

        private string StoRacunamo(string fizikalnaVelicina)
        {
            return $"{ fizikalnaVelicina } = ?";
        }

        private string Vrijednost(string fizikalnaVelicina, double vrijednost, string mjernaJedinica)
        {
            return $"{ fizikalnaVelicina } = { vrijednost } { mjernaJedinica }";
        }

        private string DisplayMessage(string mjernaJedinica)
        {
            return $"u mjernoj jedinici ({ mjernaJedinica })";
        }

        private string DisplayNaslov(string fizikalnaVelicina)
        {
            return $"Unesi vrijednost { fizikalnaVelicina }";
        }

        private double ConvertToDouble(string unosKorisnika)
        {
            return Math.Round(Convert.ToDouble(unosKorisnika), 2);
        }

        private ArrayList ListaOdgovora(string prvaVrijednost, string drugaVrijednost, string stoRacunamo, string odgovor)
        {
            var ar = new ArrayList();
            ar.Add(prvaVrijednost);
            ar.Add(drugaVrijednost);
            ar.Add(stoRacunamo);
            ar.Add(odgovor);

            return ar;
        }
        #endregion
    }
}
