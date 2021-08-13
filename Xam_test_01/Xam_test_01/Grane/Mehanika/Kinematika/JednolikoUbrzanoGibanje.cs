using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam_test_01.Factory;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Grane.Mehanika.Kinematika
{
    public class JednolikoUbrzanoGibanje : IJednolikoUbrzanoGibanje
    {
        private readonly Random random = new Random();
        private readonly Vrijednosti vrijednosti = new Vrijednosti();
        private readonly KinematikaTijeloModelFactory kinematikaModel = new KinematikaTijeloModelFactory();
        private readonly JednolikoPravocrtnoPitanjeModel jednolikoPravocrtnoPitanjeModel = new JednolikoPravocrtnoPitanjeModel();

        public string Brzina => FizikalneVeličine.Brzina;

        public string Put => FizikalneVeličine.Put;

        public string Vrijeme => FizikalneVeličine.Vrijeme;

        public string Akceleracija => FizikalneVeličine.Akceleracija;

        public string VNulaBrzna => FizikalneVeličine.VNulaBrzina;

        public string VrijemeNa2 => FizikalneVeličine.VrijemeNa2;

        public int Razina { get; private set; }

        public PitanjeModel NovoPitanje { get; private set; }

        public string Pitanje { get; private set; }

        public double MinVrijednostRješenja { get; private set; }

        public double MaxVrijednostRješenja { get; private set; }

        public IKinematikaTijeloModel Tijelo { get ; set; }

        public Dictionary<string, string> RječnikVrijednosti { get; private set; }

        public Dictionary<int, string> RiječnikPitanja { get; set ; }

        public PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            StvoriModel();
            StvoriRječnikVrijednosti();
            Razina = levelToUse;
            int tema = random.Next(1, 4);
            switch (tema)
            {
                case 1:
                    PitanjeTva();
                    break;
                case 2:
                    PitanjeVat();
                    break;
                case 3:
                    PitanjeAvt();
                    break;
            }
            return AppendToNovoPitanje();
        }

        private void PitanjeTva()
        {
            RječnikTva();
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Tva", Tijelo.BrzinaVrijednost, Tijelo.AkceleracijaVrijednost, Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeVat()
        {
            RječnikVat();
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Vat", Tijelo.AkceleracijaVrijednost, Tijelo.VrijemeVrijednost, Tijelo.VeličinaMjerneJedinice);
        }

        private void PitanjeAvt()
        {
            RječnikAvt();
            NovoPitanje = jednolikoPravocrtnoPitanjeModel.OdabirMetode("Avt", Tijelo.BrzinaVrijednost, Tijelo.VrijemeVrijednost, Tijelo.VeličinaMjerneJedinice);
        }

        private void RječnikTva()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Za koliko vremena je tijelo nešto pri brzini { Tijelo.BrzinaVrijednost } { RječnikVrijednosti.First(x => x.Key == Brzina).Value } " +
                $"ako je akcleracija iznosila { Tijelo.AkceleracijaVrijednost } { RječnikVrijednosti.First(x => x.Key == Akceleracija).Value }?" },
            };
            OdabirPitanja();
        }

        private void RječnikVat()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Kojom se brzinom tijelo kreče, ako je akceleracija bila { Tijelo.AkceleracijaVrijednost } { RječnikVrijednosti.First(x => x.Key == Akceleracija).Value} " +
                $"i tralajala je { Tijelo.VrijemeVrijednost } {RječnikVrijednosti.First(x => x.Key == Vrijeme).Value}?" },
            };
            OdabirPitanja();
        }


        private void RječnikAvt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"U vremenskom intervalu { Tijelo.VrijemeVrijednost } {RječnikVrijednosti.First(x => x.Key == Vrijeme).Value } " +
                $"tijelu se poveća brzina za { Tijelo.BrzinaVrijednost } {RječnikVrijednosti.First(x => x.Key == Brzina).Value}. Koliko je akceleracija tijela?" },
            };
            OdabirPitanja();
        }


        private PitanjeModel AppendToNovoPitanje()
        {
            var pitanje = NovoPitanje;
            GraniceVrijednostiRješenja(5);
            pitanje.Pitanje = Pitanje;
            pitanje.MinVrijednostRješenja = MinVrijednostRješenja;
            pitanje.MaxVrijednostRješenja = MaxVrijednostRješenja;
            pitanje.Level = Razina;
            return pitanje;
        }

        private void GraniceVrijednostiRješenja(double vrijednostRješenja)
        {
            MinVrijednostRješenja = Math.Round(vrijednostRješenja - 0.01, 2);
            MaxVrijednostRješenja = Math.Round(vrijednostRješenja + 0.01, 2);
        }

        private void StvoriRječnikVrijednosti()
        {
            RječnikVrijednosti = vrijednosti.FzikalneMjerneJediniceRiječnik(Tijelo.VeličinaMjerneJedinice);
        }

        private void StvoriModel()
        {
            Tijelo = kinematikaModel.StvoriKinematikTijeloaModel();
        }

        private void OdabirPitanja()
        {
            int brojPitanja = random.Next(1, RiječnikPitanja.Count + 1);
            Pitanje = RiječnikPitanja.FirstOrDefault(x => x.Key == brojPitanja).Value;
        }

    }
}
