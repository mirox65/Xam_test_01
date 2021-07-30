using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Grane.Mehanika.Kinematika
{
    public class JednolikoPravocrtnoGibanje
    {
        public string Pitanje { get; set; }
        public double Akceleracija { get; set; }
        public double Brzina { get; set; }
        public double BrzinaNula { get; set; } = 0;
        public double Vrijeme { get; set; }
        public string StoRacunamo { get; set; }
        public string PrvaVarijabla { get; set; }
        public string DrugaVarijabla { get; set; }
        public string TrećaVarijabla { get; set; }
        public string Odgovor { get; set; }
        public double Riješenje { get; set; }
        public double MinVrijednostRješenja { get; set; }
        public double MaxVrijednostRješenja { get; set; }
        public string MjernaJedinicaOdgovora { get; set; }
        public ArrayList OdgovorArray { get; set; }
        public Dictionary<int, string> RiječnikPitanja { get; set; }
        public string FormulaImageSource { get; internal set; }

        private readonly Random random = new Random();

        public void GeneriranjePitanja(int levelToUse)
        {
            RandomBrojevi();

            int tema = random.Next(1, 4);
            switch (tema)
            {
                case 1:
                    PitanjeAkceleracija();
                    break;
                case 2:
                    PitanjeBrzina();
                    break;
                case 3:
                    PitanjeVrijeme();
                    break;
            }
        }

        private void PitanjeVrijeme()
        {
            PitanjaVrijeme();
            Riješenje = Math.Round(Formule.TvaFormula(Brzina, Akceleracija));
            MjernaJedinicaOdgovora = MjerneJedinice.Sekunda;
            GraniceVrijednostiRješenja();
            StoRacunamo = $"{ FizikalneVeličine.Vrijeme } = ?";
            FormulaImageSource = FormuleImageSource.KinematikaFormulaVrijeme;
            PrvaVarijabla = $"{FizikalneVeličine.Brzina} = { Brzina } { MjerneJedinice.Metar }";
            DrugaVarijabla = $"{FizikalneVeličine.Akceleracija} = { Akceleracija } { MjerneJedinice.MetarSekundaNa2 }";
            Odgovor = $"{FizikalneVeličine.Vrijeme} = { Riješenje } { MjerneJedinice.Sekunda }";
            ArrayOdgovor(PrvaVarijabla, DrugaVarijabla, StoRacunamo, Odgovor);
        }

        private void PitanjaVrijeme()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Za koliko vremena je tijelo nešto pri brzini { Brzina } { MjerneJedinice.MetarSekunda } ako je akcleracija iznosila { Akceleracija } { MjerneJedinice.MetarSekundaNa2 }?" },
                { 2, $"Za koliko vremena je auto nešto pri brzini { Brzina } { MjerneJedinice.MetarSekunda } ako je akcleracija iznosila { Akceleracija } { MjerneJedinice.MetarSekundaNa2 }?" },
                { 3, $"Za koliko vremena je avion nešto pri brzini { Brzina }  {MjerneJedinice.MetarSekunda}  ako je akcleracija iznosila { Akceleracija } { MjerneJedinice.MetarSekundaNa2 }?" },
                { 4, $"Za koliko vremena je autobus nešto pri brzini { Brzina }  {MjerneJedinice.MetarSekunda}  ako je akcleracija iznosila { Akceleracija }  { MjerneJedinice.MetarSekundaNa2 } ?" },
                { 5, $"Za koliko vremena je bicikl nešto pri brzini { Brzina }  { MjerneJedinice.MetarSekunda }  ako je akcleracija iznosila { Akceleracija }  { MjerneJedinice.MetarSekundaNa2 } ?" }
            };

            OdabirPitanja();
        }

        private void PitanjeBrzina()
        {
            PitanjeBrzine();
            Riješenje = Math.Round(Formule.VatFormula(Akceleracija, Vrijeme), 2);
            MjernaJedinicaOdgovora = MjerneJedinice.Sekunda;
            GraniceVrijednostiRješenja();
            StoRacunamo = $"{ FizikalneVeličine.Brzina } = ?";
            FormulaImageSource = FormuleImageSource.KinematikaFormulaBrzina;
            PrvaVarijabla = $"{ FizikalneVeličine.Akceleracija } = { Akceleracija } { MjerneJedinice.MetarSekundaNa2 }";
            DrugaVarijabla = $"{ FizikalneVeličine.Vrijeme } = { Vrijeme } {MjerneJedinice.Sekunda}";
            Odgovor = $"{ FizikalneVeličine.Brzina } = { Riješenje } { MjerneJedinice.MetarSekunda }";
            ArrayOdgovor(PrvaVarijabla, DrugaVarijabla, StoRacunamo, Odgovor);
        }

        private void PitanjeBrzine()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Kojom se brzinom tijelo kreče, ako je akceleracija bila { Akceleracija } { MjerneJedinice.MetarSekundaNa2} i tralajala je { Vrijeme } {MjerneJedinice.Sekunda}?" },
                { 2, $"Kojom se brzinom auto kreče, ako je akceleracija bila { Akceleracija } { MjerneJedinice.MetarSekundaNa2} i tralajala je { Vrijeme } {MjerneJedinice.Sekunda}?" },
                { 3, $"Kojom se brzinom avion kreče, ako je akceleracija bila { Akceleracija }  {MjerneJedinice.MetarSekundaNa2}  i tralajala je { Vrijeme } {MjerneJedinice.Sekunda}?" },
                { 4, $"Kojom se brzinom autobus kreče, ako je akceleracija bila { Akceleracija }  {MjerneJedinice.MetarSekundaNa2}  i tralajala je { Vrijeme }  {MjerneJedinice.Sekunda} ?" },
                { 5, $"Kojom se brzinom bicikl kreče, ako je akceleracija bila { Akceleracija }  {MjerneJedinice.MetarSekundaNa2}  i tralajala je { Vrijeme }  {MjerneJedinice.Sekunda} ?" }
            };

            OdabirPitanja();
        }

        private void PitanjeAkceleracija()
        {
            PitanjaAkceleracije();
            Riješenje = Math.Round(Formule.AvtFormula(Brzina, Vrijeme), 2);
            MjernaJedinicaOdgovora = MjerneJedinice.MetarSekundaNa2;
            GraniceVrijednostiRješenja();
            StoRacunamo = $"{ FizikalneVeličine.Brzina } = ?";
            FormulaImageSource = FormuleImageSource.KinematikaFormulaPut;
            PrvaVarijabla = $"{ FizikalneVeličine.Brzina } = { Brzina } {MjerneJedinice.MetarSekunda}";
            DrugaVarijabla = $"{ FizikalneVeličine.Vrijeme } = { Vrijeme } {MjerneJedinice.Sekunda}";
            Odgovor = $"{ FizikalneVeličine.Akceleracija } = { Riješenje } {MjerneJedinice.MetarSekundaNa2}";
            ArrayOdgovor(PrvaVarijabla, DrugaVarijabla, StoRacunamo, Odgovor);
        }

        private void PitanjaAkceleracije()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"U vremenskom intervalu { Vrijeme } {MjerneJedinice.Sekunda} tijelu se poveća brzina za { Brzina } {MjerneJedinice.MetarSekunda}. Koliko je akceleracija tijela?" },
                { 2, $"U vremenskom intervalu { Vrijeme } {MjerneJedinice.Sekunda} vozilu se poveća brzina za { Brzina } {MjerneJedinice.MetarSekunda}. Koliko je akceleracija vozila?" },
                { 3, $"U vremenskom intervalu { Vrijeme } {MjerneJedinice.Sekunda} avionu se poveća brzina za { Brzina } {MjerneJedinice.MetarSekunda}. Koliko je akceleracija aviona?" },
                { 4, $"U vremenskom intervalu { Vrijeme } {MjerneJedinice.Sekunda} autobusu se poveća brzina za { Brzina } {MjerneJedinice.MetarSekunda}. Koliko je akceleracija autobusa?" },
                { 5, $"U vremenskom intervalu { Vrijeme } {MjerneJedinice.Sekunda} bicklu se poveća brzina za { Brzina } {MjerneJedinice.MetarSekunda}. Koliko je akceleracija bicikla?" }
            };

            OdabirPitanja();
        }

        private void GraniceVrijednostiRješenja()
        {
            MinVrijednostRješenja = Math.Round(Riješenje - (0.1 * Riješenje), 2);
            MaxVrijednostRješenja = Math.Round(Riješenje + (0.1 * Riješenje), 2);
        }

        private void OdabirPitanja()
        {
            int brojPitanja = random.Next(1, RiječnikPitanja.Count + 1);
            Pitanje = RiječnikPitanja.FirstOrDefault(x => x.Key == brojPitanja).Value;
        }

        private void RandomBrojevi()
        {
            Brzina = random.Next(1, 10);
            Vrijeme = random.Next(1, 10);
            Akceleracija = random.Next(1, 10);
        }

        private void ArrayOdgovor(string prvaNep, string drugaNep, string stoRacunamo, string odgovor)
        {
            var ar = new ArrayList
            {                
                prvaNep,
                drugaNep,
                stoRacunamo,
                odgovor
            };

            OdgovorArray = ar;
        }
    }
}