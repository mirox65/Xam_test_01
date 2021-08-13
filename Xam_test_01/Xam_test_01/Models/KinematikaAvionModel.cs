using System;
using Xam_test_01.Interfaces;

namespace Xam_test_01.Models
{
    public class KinematikaAvionModel : IKinematikaTijeloModel
    {
        private KinematikaAvionModel tijelo;

        public string Tijelo { get; private set; }

        public string SeKreće { get; private set; }

        public string Prođe { get; private set; }

        public string VeličinaMjerneJedinice { get; private set; }

        public double AkceleracijaVrijednost { get; private set; }

        public double BrzinaVrijednost { get; private set; }

        public double VrijemeVrijednost { get; private set; }

        public double PutVrijednost { get; private set; }
        public string Prešlo { get; set; }

        public void RandomVrijednosti()
        {
            var random = new Random();
            AkceleracijaVrijednost = random.Next(1, 30);
            BrzinaVrijednost = random.Next(150, 1100);
            VrijemeVrijednost = random.Next(1, 20);
            PutVrijednost = random.Next(100, 5000);
        }

        public IKinematikaTijeloModel StvoriFizikalniModel()
        {
            RandomVrijednosti();
            return tijelo = new KinematikaAvionModel
            {
                Tijelo = "avion",
                SeKreće = "leti",
                Prođe = "preleti",
                Prešlo = "preletio",
                VeličinaMjerneJedinice = "km, h",
                AkceleracijaVrijednost = AkceleracijaVrijednost,
                PutVrijednost = PutVrijednost,
                BrzinaVrijednost = BrzinaVrijednost,
                VrijemeVrijednost = VrijemeVrijednost
            };
        }
    }
}
