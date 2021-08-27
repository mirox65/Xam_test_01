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
        private readonly RječnikFizikalnihVeličinaMjernihJedinica dicVrijednosti = new RječnikFizikalnihVeličinaMjernihJedinica();
        private readonly UbrzanoTijeloModelFactory ubrzanoTijeloModelFactory = new UbrzanoTijeloModelFactory();
        private readonly JednolikoUbrzanoPitanjeModel jednolikoUbrzanoPitanjeModel = new JednolikoUbrzanoPitanjeModel();

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

        public IUbrzanoTijeloModel Tijelo { get ; set; }

        public Dictionary<string, string> DicFizVeličina { get; private set; }

        public Dictionary<int, string> RiječnikPitanja { get; set ; }


        public PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            StvoriTijeloModel(levelToUse);
            StvoriRječnikVrijednosti();
            Razina = levelToUse;
            int tema = random.Next(1, 4);
            switch (tema)
            {
                case 1:
                    PitanjeAvv0s();
                    break;
                case 2:
                    PitanjeAvv0t();
                    break;
                case 3:
                    PitanjeSv0vt();
                    break;
                case 4:
                    PitanjeSvv0a();
                    break;
            }
            return AppendToNovoPitanje();
        }

        private void PitanjeSvv0a()
        {
            RječnikSvv0a();
            NovoPitanje = jednolikoUbrzanoPitanjeModel.OdabirMetode("Svv0a", Tijelo);
        }

        private void PitanjeAvv0s()
        {
            RječnikAvv0s();
            NovoPitanje = jednolikoUbrzanoPitanjeModel.OdabirMetode("Avv0s", Tijelo);
        }

        private void PitanjeAvv0t()
        {
            RječnikAvv0t();
            NovoPitanje = jednolikoUbrzanoPitanjeModel.OdabirMetode("Avv0t", Tijelo);
        }

        private void PitanjeSv0vt()
        {
            RječnikSv0vt();
            NovoPitanje = jednolikoUbrzanoPitanjeModel.OdabirMetode("Sv0vt", Tijelo);
        }

        private void RječnikAvv0s()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"Kolika je akceleracija {Tijelo.Tijela} koji jednoliko mijenja brzinu od {Tijelo.VNulaBrzinaVrijednost} {dicVrijednosti.NazivMJ(VNulaBrzna)} na " +
                $"{Tijelo.BrzinaVrijednost} {dicVrijednosti.NazivMJ(Brzina)} na putu od {Tijelo.PutVrijednost} {dicVrijednosti.NazivMJ(Put)}?" },
            };
            OdabirPitanja();
        }

        private void RječnikSvv0a()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                {1, $"{Tijelo.Tijelo} se počinje gibati jednoliko ubrzano. Na kojoj će udaljenosti njegova brzina iznositi " +
                $"{Tijelo.BrzinaVrijednost} {dicVrijednosti.NazivMJ(Brzina)}, ako je ubrzanje {Tijelo.AkceleracijaVrijednost} {dicVrijednosti.NazivMJ(Akceleracija)}?" }
            };
        }

        private void RječnikAvv0t()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"{Tijelo.VSTijelo} se giba tako da mu se brzina jednoliko promjeni od {Tijelo.VNulaBrzinaVrijednost} {dicVrijednosti.NazivMJ(VNulaBrzna)} " +
                $"na {Tijelo.BrzinaVrijednost} {dicVrijednosti.NazivMJ(Brzina)} za {Tijelo.VrijemeVrijednost} {dicVrijednosti.NazivMJ(Vrijeme)} " +
                $"Kolika je akceleracija?" },
            };
            OdabirPitanja();
        }

        private void RječnikSv0vt()
        {
            RiječnikPitanja = new Dictionary<int, string>
            {
                { 1, $"{Tijelo.VSTijelo} se počne gibati jednoliko ubrzano i za {Tijelo.VrijemeVrijednost} {dicVrijednosti.NazivMJ(Vrijeme)} " +
                $"postigne brzinu {Tijelo.BrzinaVrijednost} {dicVrijednosti.NazivMJ(Brzina)}. Koliko iznosi put?" },
            };
            OdabirPitanja();
        }

        public PitanjeModel AppendToNovoPitanje()
        {
            var pitanje = NovoPitanje;
            GraniceVrijednostiRješenja(NovoPitanje.VrijednostRješenja);
            pitanje.Pitanje = Pitanje;
            pitanje.MinVrijednostRješenja = MinVrijednostRješenja;
            pitanje.MaxVrijednostRješenja = MaxVrijednostRješenja;
            pitanje.Level = Razina;
            return pitanje;
        }

        public void GraniceVrijednostiRješenja(double vrijednostRješenja)
        {
            MinVrijednostRješenja = Math.Round(vrijednostRješenja - 0.01, 2);
            MaxVrijednostRješenja = Math.Round(vrijednostRješenja + 0.01, 2);
        }

        public void StvoriRječnikVrijednosti()
        {
            DicFizVeličina = dicVrijednosti.FzikalneMjerneJediniceRiječnik(Tijelo.VeličinaMjerneJedinice);
        }

        public void StvoriTijeloModel(int levelToUse)
        {
            Tijelo = ubrzanoTijeloModelFactory.StvoriKinematikTijeloaModel(levelToUse);
        }

        public void OdabirPitanja()
        {
            int brojPitanja = random.Next(1, RiječnikPitanja.Count + 1);
            Pitanje = RiječnikPitanja.FirstOrDefault(x => x.Key == brojPitanja).Value;
        }
    }
}
