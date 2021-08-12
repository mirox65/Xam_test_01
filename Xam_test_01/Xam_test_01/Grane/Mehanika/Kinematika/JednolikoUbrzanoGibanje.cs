using System;
using System.Collections.Generic;
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

        public PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            StvoriModel();
            StvoriRječnikVrijednosti();
            Razina = levelToUse;
            int tema = random.Next(1, 2);
            switch (tema)
            {
                case 1:
                    PitanjeTv0va();
                    break;
                case 2:
                    PitanjeAv0vt();
                    break;
                case 3:
                    PitanjeVv0ta();
                    break;
                case 4:
                    PitanjeV0vta();
                    break;
            }
            return AppendToNovoPitanje();
        }

        private void PitanjeV0vta()
        {
            throw new NotImplementedException();
        }

        private void PitanjeVv0ta()
        {
            throw new NotImplementedException();
        }

        private void PitanjeAv0vt()
        {
            throw new NotImplementedException();
        }

        private void PitanjeTv0va()
        {
            NovoPitanje = new PitanjeModel
            {
                Pitanje = "Ovo je ubrzano pitanje"
            };
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
    }
}
