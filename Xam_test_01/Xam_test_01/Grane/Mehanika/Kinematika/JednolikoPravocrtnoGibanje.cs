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
        private readonly PravocrtnoTijeloModelFactory pravocrtnoTijeloModelFactory = new PravocrtnoTijeloModelFactory();
        private readonly RječnikFizikalnihVeličinaMjernihJedinica dicFizVeličina = new RječnikFizikalnihVeličinaMjernihJedinica();

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
        public Dictionary<string, string> DicFizVeličina { get; private set; }

        public PitanjeModel NovoPitanje { get; set; }
        public IPravocrtnoTijeloModel Tijelo { get; set; }

        public PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            StvoriTijeloModel(levelToUse);
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

        public void StvoriRječnikVrijednosti()
        {
            DicFizVeličina = dicFizVeličina.FzikalneMjerneJediniceRiječnik(Tijelo.VeličinaMjerneJedinice);
        }

        public void StvoriTijeloModel(int levelToUse)
        {
            Tijelo = pravocrtnoTijeloModelFactory.StvoriKinematikTijeloaModel(levelToUse);
        }

        public PitanjeModel AppendToNovoPitanje()
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
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Vst", Tijelo);
        }

        private void PitanjeSvt()
        {
            RječnikSvt();
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Svt", Tijelo);
        }

        private void PitanjeTsv()
        {
            RječnikTsv();
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Tsv", Tijelo);
        }

        private void RječnikVst()
        {
            RiječnikPitanja = new Dictionary<int, string> 
            {
                { 1, $"Kojom brzinom {Tijelo.SeKreće} {Tijelo.Tijelo} ako put od {Tijelo.PutVrijednost} {dicFizVeličina.NazivMJ(Put)} {Tijelo.Prođe} " +
                $"za {Tijelo.VrijemeVrijednost} {dicFizVeličina.NazivMJ(Vrijeme)}?" },
            };
            OdabirPitanja();
        }

        private void RječnikSvt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                {1,$"{ Tijelo.VSTijelo } { Tijelo.SeKreće } brzinom { Tijelo.BrzinaVrijednost } { dicFizVeličina.NazivMJ(Brzina) } " +
                $"u vremenskom intervalu { Tijelo.VrijemeVrijednost } { dicFizVeličina.NazivMJ(Vrijeme) }. Prijeđeni put je?" },
            };
            OdabirPitanja();
        }

        private void RječnikTsv()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Za koliko vremena je {Tijelo.Tijelo} {Tijelo.Prešlo} put duljine { Tijelo.PutVrijednost } { dicFizVeličina.NazivMJ(Put) } pri brzini { Tijelo.BrzinaVrijednost } { dicFizVeličina.NazivMJ(Brzina) }?" },
            };
            OdabirPitanja();
        }

        public void GraniceVrijednostiRješenja(double vrijednostRješenja)
        {
            MinVrijednostRješenja = Math.Round(vrijednostRješenja - 0.01, 2);
            MaxVrijednostRješenja = Math.Round(vrijednostRješenja + 0.01, 2);
        }

        public void OdabirPitanja()
        {
            int brojPitanja = random.Next(1, RiječnikPitanja.Count + 1);
            Pitanje = RiječnikPitanja.FirstOrDefault(x => x.Key == brojPitanja).Value;
        }
    }
}