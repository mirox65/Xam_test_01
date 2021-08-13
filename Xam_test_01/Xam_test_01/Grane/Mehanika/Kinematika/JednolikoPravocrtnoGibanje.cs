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
        private readonly JednolikoPravocrtnoPitanjeModel jednolikoPravocrtnoPitanjeModel = new JednolikoPravocrtnoPitanjeModel();
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
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Vst", Tijelo.PutVrijednost, Tijelo.VrijemeVrijednost, Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeSvt()
        {
            RječnikSvt();
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Svt", Tijelo.BrzinaVrijednost, Tijelo.VrijemeVrijednost, Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeTsv()
        {
            RječnikTsv();
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Tsv", Tijelo.PutVrijednost, Tijelo.BrzinaVrijednost, Tijelo.VeličinaMjerneJedinice);
        }

        private void RječnikVst()
        {
            RiječnikPitanja = new Dictionary<int, string> 
            {
                { 1, $"Kojom brzinom {Tijelo.SeKreće} {Tijelo.Tijelo} ako put od {Tijelo.PutVrijednost} {RječnikVrijednosti.FirstOrDefault(x => x.Key == Put).Value} {Tijelo.Prođe} " +
                $"za {Tijelo.VrijemeVrijednost} {RječnikVrijednosti.First(x => x.Key == Vrijeme).Value}?" },
            };
            OdabirPitanja();
        }

        private void RječnikSvt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                {1,$"{ Tijelo.Tijelo } {Tijelo.SeKreće} brzinom {Tijelo.BrzinaVrijednost} {RječnikVrijednosti.First(x => x.Key == Brzina).Value} " +
                $"u vremenskom intervalu {Tijelo.VrijemeVrijednost } {RječnikVrijednosti.First(x => x.Key == Vrijeme).Value}. Prijeđeni put je?" },
            };
            OdabirPitanja();
        }

        private void RječnikTsv()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Za koliko vremena je {Tijelo.Tijelo} {Tijelo.Prešlo} pri brzini { Tijelo.BrzinaVrijednost } { RječnikVrijednosti.First(x => x.Key == Brzina).Value } " +
                $"ako je put duljinje { Tijelo.PutVrijednost } {RječnikVrijednosti.First(x => x.Key == Put).Value}?" },
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