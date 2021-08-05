using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Grane.Mehanika.Kinematika
{
    public class JednolikoPravocrtnoGibanje
    {
        private readonly JednolikoPravocrtnoModel jpg = new JednolikoPravocrtnoModel();

        public string Pitanje { get; set; }
        public double Akceleracija { get; set; }
        public double Brzina { get; set; }
        public double Vrijeme { get; set; }
        public double Put { get; set; }
        public double MinVrijednostRješenja { get; set; }
        public double MaxVrijednostRješenja { get; set; }
        public Dictionary<int, string> RiječnikPitanja { get; set; }
        public PitanjeModel NovoPitanje { get; set; }

        private readonly Random random = new Random();

        public PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            RandomBrojevi();

            int tema = random.Next(1, 4);
            switch (tema)
            {
                case 1:
                    PitanjeSvt();
                    break;
                case 2:
                    PitanjeVst();
                    break;
                case 3:
                    PitanjeTsv();
                    break;
            }
            return AppendToNovoPitanje();
        }

        private PitanjeModel AppendToNovoPitanje()
        {
            var pitanje = NovoPitanje;
            GraniceVrijednostiRješenja(pitanje.VrijednostRješenja);
            pitanje.Pitanje = Pitanje;
            pitanje.MinVrijednostRješenja = MinVrijednostRješenja;
            pitanje.MaxVrijednostRješenja = MaxVrijednostRješenja;
            return pitanje;
        }

        private void PitanjeVst()
        {
            RječnikVst();
            NovoPitanje = jpg.OdabirMetode("Vst", Put.ToString(), Vrijeme.ToString());
        }

        private void PitanjeSvt()
        {
            RječnikSvt();
            NovoPitanje = jpg.OdabirMetode("Svt", Brzina.ToString(), Vrijeme.ToString());
        }

        private void PitanjeTsv()
        {
            RječnikTsv();
            NovoPitanje = jpg.OdabirMetode("Tsv", Put.ToString(), Brzina.ToString());
        }

        private void PitanjeTva()
        {
            RječnikTva();
            NovoPitanje = jpg.OdabirMetode("Tva", Brzina.ToString(), Akceleracija.ToString());
        }

        private void PitanjeVat()
        {
            RječnikVat();
            NovoPitanje = jpg.OdabirMetode("Vat", Akceleracija.ToString(), Vrijeme.ToString());
        }

        private void PitanjeAvt()
        {
            RječnikAvt();
            NovoPitanje = jpg.OdabirMetode("Avt", Brzina.ToString(), Vrijeme.ToString());
        }


        private void RječnikVst()
        {
            RiječnikPitanja = new Dictionary<int, string> 
            {
                { 1, $"Kojom brzinom se kreće tijelo ako put od {Put} {MjerneJedinice.Metar} prijeđe za {Vrijeme} {MjerneJedinice.Sekunda}?" },
                { 2, $"Kojom brzinom se kreće auto ako put od {Put} {MjerneJedinice.Metar} prijeđe za {Vrijeme} {MjerneJedinice.Sekunda}?" },
                { 3, $"Kojom brzinom se kreće avion ako put od {Put} {MjerneJedinice.Metar} prijeđe za {Vrijeme} {MjerneJedinice.Sekunda}?" },
                { 4, $"Kojom brzinom se kreće bicikl ako put od {Put} {MjerneJedinice.Metar} prijeđe za {Vrijeme} {MjerneJedinice.Sekunda}?" },
                { 5, $"Kojom brzinom se kreće ljudsko biće ako put od {Put} {MjerneJedinice.Metar} prijeđe za {Vrijeme} {MjerneJedinice.Sekunda}?" },
            };
            OdabirPitanja();
        }

        private void RječnikSvt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                {1,$"Tijelo se kreće brzinom {Brzina} {MjerneJedinice.MetarSekunda} u vremenskom intervalu {Vrijeme } {MjerneJedinice.Sekunda}. Prijeđeni put je?" },
                {2,$"Avion se kreće brzinom {Brzina} {MjerneJedinice.MetarSekunda} u vremenskom intervalu {Vrijeme } {MjerneJedinice.Sekunda}. Prijeđeni put je?" },
                {3,$"Auto se kreće brzinom {Brzina} {MjerneJedinice.MetarSekunda} u vremenskom intervalu {Vrijeme } {MjerneJedinice.Sekunda}. Prijeđeni put je?" },
                {4,$"Ljudsko biće se kreće brzinom {Brzina} {MjerneJedinice.MetarSekunda} u vremenskom intervalu {Vrijeme } {MjerneJedinice.Sekunda}. Prijeđeni put je?" },
                {5,$"Pas se kreće brzinom {Brzina} {MjerneJedinice.MetarSekunda} u vremenskom intervalu {Vrijeme } {MjerneJedinice.Sekunda}. Prijeđeni put je?" },
            };
            OdabirPitanja();
        }

        private void RječnikTsv()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Za koliko vremena je tijelo prešlo pri brzini { Brzina } { MjerneJedinice.MetarSekunda } ako je put duljinje { Put } { MjerneJedinice.Metar }?" },
                { 2, $"Za koliko vremena je auto prešao pri brzini { Brzina } { MjerneJedinice.MetarSekunda } ako je put duljinje { Put } { MjerneJedinice.Metar }?" },
                { 3, $"Za koliko vremena je avion prešao pri brzini { Brzina }  {MjerneJedinice.MetarSekunda}  ako je put duljinje { Put } { MjerneJedinice.Metar }?" },
                { 4, $"Za koliko vremena je autobus prešao pri brzini { Brzina }  {MjerneJedinice.MetarSekunda}  ako je put duljinje { Put }  { MjerneJedinice.Metar } ?" },
                { 5, $"Za koliko vremena je bicikl prešao pri brzini { Brzina }  { MjerneJedinice.MetarSekunda }  ako je put duljinje { Put }  { MjerneJedinice.Metar } ?" }
            };
            OdabirPitanja();
        }

        private void RječnikTva()
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

        private void RječnikVat()
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


        private void RječnikAvt()
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

        private void GraniceVrijednostiRješenja(double vrijednostRješenja)
        {
            MinVrijednostRješenja = Math.Round(vrijednostRješenja - 0.01, 2);
            MaxVrijednostRješenja = Math.Round(vrijednostRješenja + 0.01, 2);
        }

        private void OdabirPitanja()
        {
            int brojPitanja = random.Next(1, RiječnikPitanja.Count + 1);
            Pitanje = RiječnikPitanja.FirstOrDefault(x => x.Key == brojPitanja).Value;
        }

        private void RandomBrojevi()
        {
            Brzina = random.Next(1, 10);
            Vrijeme = random.Next(1, 300);
            Akceleracija = random.Next(1, 10);
            Put = random.Next(1, 100);
        }
    }
}