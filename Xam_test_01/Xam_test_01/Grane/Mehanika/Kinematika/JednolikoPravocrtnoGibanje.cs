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
        public string FormulaZaIspis { get; set; }
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
        public MjerneJedinice Mj { get; } = new MjerneJedinice();

        private readonly Random random = new Random();

        public void GeneriranjePitanja()
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
            IzracunVremena(Brzina, Akceleracija);
            Riješenje = Math.Round(Vrijeme, 2);
            MjernaJedinicaOdgovora = Mj.Sekunda;
            GraniceVrijednostiRješenja();
            StoRacunamo = "t=?";
            FormulaZaIspis = "t=v/a";
            PrvaVarijabla = $"v = { Brzina } { Mj.Sekunda }";
            DrugaVarijabla = $"a = { Akceleracija } { Mj.MetarSekundaNa2 }";
            Odgovor = $"t = { Riješenje } { Mj.Sekunda }";
            ArrayOdgovor(StoRacunamo, FormulaZaIspis, PrvaVarijabla, DrugaVarijabla, Odgovor);
        }

        private void GraniceVrijednostiRješenja()
        {
            MinVrijednostRješenja = Math.Round(Riješenje - (0.1 * Riješenje), 2);
            MaxVrijednostRješenja = Math.Round(Riješenje + (0.1 * Riješenje), 2);
        }

        private void PitanjaVrijeme()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Za koliko vremena je tijelo nešto pri brzini { Brzina } { Mj.MetarSekunda } ako je akcleracija iznosila { Akceleracija } { Mj.MetarSekundaNa2 }?" },
                { 2, $"Za koliko vremena je auto nešto pri brzini { Brzina } { Mj.MetarSekunda } ako je akcleracija iznosila { Akceleracija } { Mj.MetarSekundaNa2 }?" },
                { 3, $"Za koliko vremena je avion nešto pri brzini { Brzina }  {Mj.MetarSekunda}  ako je akcleracija iznosila { Akceleracija } { Mj.MetarSekundaNa2 }?" },
                { 4, $"Za koliko vremena je autobus nešto pri brzini { Brzina }  {Mj.MetarSekunda}  ako je akcleracija iznosila { Akceleracija }  { Mj.MetarSekundaNa2 } ?" },
                { 5, $"Za koliko vremena je bicikl nešto pri brzini { Brzina }  { Mj.MetarSekunda }  ako je akcleracija iznosila { Akceleracija }  { Mj.MetarSekundaNa2 } ?" }
            };

            OdabirPitanja();
        }

        private void OdabirPitanja()
        {
            int brojPitanja = random.Next(1, RiječnikPitanja.Count + 1);
            Pitanje = RiječnikPitanja.FirstOrDefault(x => x.Key == brojPitanja).Value;
        }

        private void IzracunVremena(double brzina, double akceleracija)
        {
            Vrijeme = brzina / akceleracija;
        }

        private void PitanjeBrzina()
        {
            PitanjeBrzine();
            IzracunBrzine(Akceleracija, Vrijeme);
            Riješenje = Math.Round(Brzina, 2);
            MjernaJedinicaOdgovora = Mj.MetarSekunda;
            GraniceVrijednostiRješenja();
            StoRacunamo = "v=?";
            FormulaZaIspis = "v=a*t";
            PrvaVarijabla = $"a = { Akceleracija } { Mj.MetarSekundaNa2 }";
            DrugaVarijabla = $"t = { Vrijeme } {Mj.Sekunda}";
            Odgovor = $"v = { Math.Round(Brzina, 2) } {Mj.MetarSekunda}";
            ArrayOdgovor(StoRacunamo, FormulaZaIspis, PrvaVarijabla, DrugaVarijabla, Odgovor);
        }

        private void PitanjeBrzine()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Kojom se brzinom tijelo kreče, ako je akceleracija bila { Akceleracija } { Mj.MetarSekundaNa2} i tralajala je { Vrijeme } {Mj.Sekunda}?" },
                { 2, $"Kojom se brzinom auto kreče, ako je akceleracija bila { Akceleracija } { Mj.MetarSekundaNa2} i tralajala je { Vrijeme } {Mj.Sekunda}?" },
                { 3, $"Kojom se brzinom avion kreče, ako je akceleracija bila { Akceleracija }  {Mj.MetarSekundaNa2}  i tralajala je { Vrijeme } {Mj.Sekunda}?" },
                { 4, $"Kojom se brzinom autobus kreče, ako je akceleracija bila { Akceleracija }  {Mj.MetarSekundaNa2}  i tralajala je { Vrijeme }  {Mj.Sekunda} ?" },
                { 5, $"Kojom se brzinom bicikl kreče, ako je akceleracija bila { Akceleracija }  {Mj.MetarSekundaNa2}  i tralajala je { Vrijeme }  {Mj.Sekunda} ?" }
            };

            OdabirPitanja();
        }

        private void IzracunBrzine(double akceleracija, double vrijeme)
        {
            Brzina = akceleracija * vrijeme;
        }

        private void PitanjeAkceleracija()
        {
            PitanjaAkceleracije();
            IzracunAkceleracije(Brzina, Vrijeme);
            Riješenje = Math.Round(Akceleracija, 2);
            MjernaJedinicaOdgovora = Mj.MetarSekundaNa2;
            GraniceVrijednostiRješenja();
            StoRacunamo = "a=?";
            FormulaZaIspis = "a=v/t";
            PrvaVarijabla = $"v = { Brzina } {Mj.MetarSekunda}";
            DrugaVarijabla = $"t = { Vrijeme } {Mj.Sekunda}";
            Odgovor = $"a = { Math.Round(Akceleracija, 2)} {Mj.MetarSekundaNa2}";
            ArrayOdgovor(StoRacunamo, FormulaZaIspis, PrvaVarijabla, DrugaVarijabla, Odgovor);
        }

        private void PitanjaAkceleracije()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"U vremenskom intervalu { Vrijeme } {Mj.Sekunda} tijelu se poveća brzina za { Brzina } {Mj.MetarSekunda}. Koliko je akceleracija tijela?" },
                { 2, $"U vremenskom intervalu { Vrijeme } {Mj.Sekunda} vozilu se poveća brzina za { Brzina } {Mj.MetarSekunda}. Koliko je akceleracija vozila?" },
                { 3, $"U vremenskom intervalu { Vrijeme } {Mj.Sekunda} avionu se poveća brzina za { Brzina } {Mj.MetarSekunda}. Koliko je akceleracija aviona?" },
                { 4, $"U vremenskom intervalu { Vrijeme } {Mj.Sekunda} autobusu se poveća brzina za { Brzina } {Mj.MetarSekunda}. Koliko je akceleracija autobusa?" },
                { 5, $"U vremenskom intervalu { Vrijeme } {Mj.Sekunda} bicklu se poveća brzina za { Brzina } {Mj.MetarSekunda}. Koliko je akceleracija bicikla?" }
            };

            OdabirPitanja();
        }

        private void IzracunAkceleracije(double brzina, double vrijeme)
        {
            Akceleracija = brzina / vrijeme;
        }

        private void RandomBrojevi()
        {
            Brzina = random.Next(1, 10);
            Vrijeme = random.Next(1, 10);
            Akceleracija = random.Next(1, 10);
        }

        private void ArrayOdgovor(string stoRacunamo, string formulaZaIspis, string prvaNep, string drugaNep, string odgovor)
        {
            var ar = new ArrayList
            {
                stoRacunamo,
                formulaZaIspis,
                prvaNep,
                drugaNep,
                odgovor
            };

            OdgovorArray = ar;
        }

    }

}