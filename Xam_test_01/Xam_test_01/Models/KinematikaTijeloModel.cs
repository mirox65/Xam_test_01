using System;
using Xam_test_01.Interfaces;

namespace Xam_test_01.Models
{
    public class KinematikaTijeloModel : IKinematikaTijeloModel
    {
        private KinematikaTijeloModel tijelo;

        public string Tijelo { get; private set; }

        public string SeKreće { get; private set; }

        public string Prođe { get; private set; }

        public string VeličinaMjerneJedinice { get; private set; }

        public double AkceleracijaVrijednost { get; private set; }

        public double BrzinaVrijednost { get; private  set; }

        public double VrijemeVrijednost { get; private set; }

        public double PutVrijednost { get; private set; }
        public string Prešlo { get; set; }

        public IKinematikaTijeloModel StvoriFizikalniModel()
        {
            RandomVrijednosti();
            return tijelo = new KinematikaTijeloModel
            {
                Tijelo = "tijelo",
                SeKreće = "se kreće",
                Prođe = "prođe",
                Prešlo = "prešlo",
                VeličinaMjerneJedinice = "m, s",
                AkceleracijaVrijednost = AkceleracijaVrijednost,
                BrzinaVrijednost = BrzinaVrijednost,
                VrijemeVrijednost = VrijemeVrijednost,
                PutVrijednost = PutVrijednost
            };
        }

        public void RandomVrijednosti()
        {
            var random = new Random();
            AkceleracijaVrijednost = random.Next(1, 10);
            BrzinaVrijednost = random.Next(1, 20);
            VrijemeVrijednost = random.Next(1, 1200);
            PutVrijednost = random.Next(1, 5000);
        }
    }
}
