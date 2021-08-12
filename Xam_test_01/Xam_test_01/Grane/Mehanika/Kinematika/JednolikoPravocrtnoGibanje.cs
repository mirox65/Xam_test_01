using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xam_test_01.Factory;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Grane.Mehanika.Kinematika
{
    public class JednolikoPravocrtnoGibanje : IJednolikoPravocrtnoGibanje
    {
        private readonly JednolikoPravocrtnoModel jpg = new JednolikoPravocrtnoModel();
        private readonly KinematikaTijeloModelFactory kinematikaModel = new KinematikaTijeloModelFactory();
        private readonly Vrijednosti vrijednosti = new Vrijednosti();

        public string Brzina => FizikalneVeličine.Brzina;

        public string Put => FizikalneVeličine.Put;

        public string Vrijeme => FizikalneVeličine.Vrijeme;

        public string Akceleracija => FizikalneVeličine.Akceleracija;

        private readonly Random random = new Random();

        public string Pitanje { get; set; }
        public double MinVrijednostRješenja { get; set; }
        public double MaxVrijednostRješenja { get; set; }
        public int Razina { get; set; }
        public Dictionary<int, string> RiječnikPitanja { get; set; }
        public PitanjeModel NovoPitanje { get; set; }
        public Dictionary<string, string> RječnikVrijednosti { get; set; }
        public IKinematikaTijeloModel Tijelo { get; set; }

        public PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            StvoriModel();
            StvoriRječnikVrijednosti();
            Razina = levelToUse;
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

        private void StvoriRječnikVrijednosti()
        {
            RječnikVrijednosti = vrijednosti.FzikalneMjerneJediniceRiječnik(Tijelo.VeličinaMjerneJedinice);
        }

        private void StvoriModel()
        {
            Tijelo = kinematikaModel.StvoriKinematikTijeloaModel();
        }

        private PitanjeModel AppendToNovoPitanje()
        {
            var pitanje = NovoPitanje;
            GraniceVrijednostiRješenja(pitanje.VrijednostRješenja);
            pitanje.Pitanje = Pitanje;
            pitanje.MinVrijednostRješenja = MinVrijednostRješenja;
            pitanje.MaxVrijednostRješenja = MaxVrijednostRješenja;
            pitanje.Level = Razina;
            return pitanje;
        }

        private void PitanjeVst()
        {
            RječnikVst();
            NovoPitanje = jpg.OdabirMetode("Vst", Tijelo.PutVrijednost.ToString(), Tijelo.VrijemeVrijednost.ToString(), Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeSvt()
        {
            RječnikSvt();
            NovoPitanje = jpg.OdabirMetode("Svt", Tijelo.BrzinaVrijednost.ToString(), Tijelo.VrijemeVrijednost.ToString(), Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeTsv()
        {
            RječnikTsv();
            NovoPitanje = jpg.OdabirMetode("Tsv", Tijelo.PutVrijednost.ToString(), Tijelo.BrzinaVrijednost.ToString(), Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeTva()
        {
            RječnikTva();
            NovoPitanje = jpg.OdabirMetode("Tva", Tijelo.BrzinaVrijednost.ToString(), Tijelo.AkceleracijaVrijednost.ToString(), Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeVat()
        {
            RječnikVat();
            NovoPitanje = jpg.OdabirMetode("Vat", Tijelo.AkceleracijaVrijednost.ToString(), Tijelo.VrijemeVrijednost.ToString(), Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeAvt()
        {
            RječnikAvt();
            NovoPitanje = jpg.OdabirMetode("Avt", Tijelo.BrzinaVrijednost.ToString(), Tijelo.VrijemeVrijednost.ToString(), Tijelo.VeličinaMjerneJedinice);
        }


        private void RječnikVst()
        {
            RiječnikPitanja = new Dictionary<int, string> 
            {
                { 1, $"Kojom brzinom {Tijelo.SeKreće} {Tijelo.Tijelo} ako put od {Tijelo.PutVrijednost} {RječnikVrijednosti.FirstOrDefault(x => x.Key == Put).Value} {Tijelo.Prođe} za {Tijelo.VrijemeVrijednost} {RječnikVrijednosti.First(x => x.Key == Vrijeme).Value}?" },
            };
            OdabirPitanja();
        }

        private void RječnikSvt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                {1,$"{ Tijelo.Tijelo } {Tijelo.SeKreće} brzinom {Tijelo.BrzinaVrijednost} {RječnikVrijednosti.First(x => x.Key == Brzina).Value} u vremenskom intervalu {Tijelo.VrijemeVrijednost } {RječnikVrijednosti.First(x => x.Key == Vrijeme).Value}. Prijeđeni put je?" },
            };
            OdabirPitanja();
        }

        private void RječnikTsv()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Za koliko vremena je {Tijelo.Tijelo} prešlo pri brzini { Tijelo.BrzinaVrijednost } { RječnikVrijednosti.First(x => x.Key == Brzina).Value } ako je put duljinje { Tijelo.PutVrijednost } {RječnikVrijednosti.First(x => x.Key == Put).Value}?" },
            };
            OdabirPitanja();
        }

        private void RječnikTva()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Za koliko vremena je tijelo nešto pri brzini { Tijelo.BrzinaVrijednost } { RječnikVrijednosti.First(x => x.Key == Brzina).Value } ako je akcleracija iznosila { Tijelo.AkceleracijaVrijednost } { RječnikVrijednosti.First(x => x.Key == Akceleracija).Value }?" },
            };
            OdabirPitanja();
        }

        private void RječnikVat()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Kojom se brzinom tijelo kreče, ako je akceleracija bila { Tijelo.AkceleracijaVrijednost } { RječnikVrijednosti.First(x => x.Key == Akceleracija).Value} i tralajala je { Tijelo.VrijemeVrijednost } {RječnikVrijednosti.First(x => x.Key == Vrijeme).Value}?" },
            };
            OdabirPitanja();
        }


        private void RječnikAvt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"U vremenskom intervalu { Tijelo.VrijemeVrijednost } {RječnikVrijednosti.First(x => x.Key == Vrijeme).Value } tijelu se poveća brzina za { Tijelo.BrzinaVrijednost } {RječnikVrijednosti.First(x => x.Key == Brzina).Value}. Koliko je akceleracija tijela?" },
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
    }
}