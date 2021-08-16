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
    public class JednolikoKruznoGibanje : IJednolikoKurznoGibanje
    {
        private readonly Random random = new Random();
        private readonly RječnikFizikalnihVeličinaMjernihJedinica dicFizVeličina = new RječnikFizikalnihVeličinaMjernihJedinica();
        private readonly JednolikoKružnoPitanjeModel jednolikoKružnoPitanjeModel = new JednolikoKružnoPitanjeModel();
        private readonly KružnoTijeloModelFactory kružnoTijeloModelFactory = new KružnoTijeloModelFactory();

        public string Akceleracija => FizikalneVeličine.Akceleracija;

        public string Brzina => FizikalneVeličine.Brzina;

        public string BrojOkretaja => FizikalneVeličine.BrojOkretaja;

        public string Polumjer => FizikalneVeličine.Polumjer;

        public string Pi => FizikalneVeličine.Pi;

        public string Dijametar => FizikalneVeličine.Dijametar;

        public string KutnaBrzina => FizikalneVeličine.KutnaBrzina;

        public string Kut => FizikalneVeličine.Kut;

        public string VrijemePeriod => FizikalneVeličine.VrijemePeriod;

        public string Frekvencija => FizikalneVeličine.Frekvencija;

        public string Vrijeme => FizikalneVeličine.Vrijeme;


        public IKružnoTijeloModel Tijelo { get; set; }
        public Dictionary<int, string> RiječnikPitanja { get; set; }
        public int Razina { get; private set; }
        public Dictionary<string, string> DicFizVeličina { get; private set; }
        public PitanjeModel NovoPitanje { get; private set; }
        public string Pitanje { get; private set; }
        public double MinVrijednostRješenja { get; private set; }
        public double MaxVrijednostRješenja { get; private set; }

        

        public PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            StvoriModel();
            StvoriRječnikVrijednosti();
            Razina = levelToUse;
            int tema = random.Next(1, 4);
            switch (tema)
            {
                case 1:
                    PitanjeVTtn();
                    break;
                case 2:
                    PitanjeFnt();
                    break;
                case 3:
                    PitanjeOmegaPiVT();
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
            pitanje.Level = Razina;
            return pitanje;
        }


        private void PitanjeOmegaPiVT()
        {
            RječnikOmegaPiVt();
            NovoPitanje = jednolikoKružnoPitanjeModel.OdabirMetode("OmegaPiVT", Tijelo);
        }

        private void PitanjeFnt()
        {
            RječnikFnt();
            NovoPitanje = jednolikoKružnoPitanjeModel.OdabirMetode("Fnt", Tijelo);
        }

        private void PitanjeVTtn()
        {
            RječnikVTtn();
            NovoPitanje = jednolikoKružnoPitanjeModel.OdabirMetode("VTtn", Tijelo);
        }

        private void RječnikOmegaPiVt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Izračunaj kutnu brzinu {Tijelo.Tijela} ako je vremenski period {Tijelo.VrijemePeriodVrijednost} {dicFizVeličina.NazivMJ(VrijemePeriod)}?" },
            };
            OdabirPitanja();
        }

        private void RječnikFnt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"{Tijelo.VSTijelo} se okreče stalnom brzinom i u { Tijelo.VrijemeVrijednost } { dicFizVeličina.NazivMJ(Vrijeme)} napravi { Tijelo.BrojOkretajaVrijednost } okretaja. " +
                $"Kolika je frekvencija { Tijelo.Tijela }?" },
            };
            OdabirPitanja();
        }

        private void RječnikVTtn()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Vrijeme vrtnje iznosi { Tijelo.VrijemeVrijednost } { dicFizVeličina.NazivMJ(Vrijeme) }. Koliko je potrebno da { Tijelo.Tijelo } " +
                $"napravi puni krug, ako se okrenula { Tijelo.BrojOkretajaVrijednost } puta?" },
            };
            OdabirPitanja();
        }

        private void StvoriRječnikVrijednosti()
        {
            DicFizVeličina = dicFizVeličina.FzikalneMjerneJediniceRiječnik(Tijelo.VeličinaMjerneJedinice);
        }

        private void StvoriModel()
        {
            Tijelo = kružnoTijeloModelFactory.StvoriKinematikTijeloaModel();
        }

        private void OdabirPitanja()
        {
            int brojPitanja = random.Next(1, RiječnikPitanja.Count + 1);
            Pitanje = RiječnikPitanja.FirstOrDefault(x => x.Key == brojPitanja).Value;
        }

        private void GraniceVrijednostiRješenja(double vrijednostRješenja)
        {
            MinVrijednostRješenja = Math.Round(vrijednostRješenja - 0.01, 2);
            MaxVrijednostRješenja = Math.Round(vrijednostRješenja + 0.01, 2);
        }
    }
}
