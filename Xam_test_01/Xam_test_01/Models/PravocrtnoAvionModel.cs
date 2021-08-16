using System;
using Xam_test_01.Interfaces;

namespace Xam_test_01.Models
{
    public class PravocrtnoAvionModel : IPravocrtnoTijeloModel
    {
        private PravocrtnoAvionModel tijelo;

        public string Tijelo { get; private set; }

        public string VSTijelo { get; set; }

        public string SeKreće { get; private set; }

        public string Prođe { get; private set; }

        public string VeličinaMjerneJedinice { get; private set; }

        public double BrzinaVrijednost { get; private set; }

        public double VrijemeVrijednost { get; private set; }

        public double PutVrijednost { get; private set; }
        public string Prešlo { get; private set; }


        public void RandomVrijednosti(int levelToUse)
        {
            var random = new Random();
            BrzinaVrijednost = random.Next(150, 1100);
            VrijemeVrijednost = random.Next(1, 20);
            PutVrijednost = random.Next(100, 5000);
        }

        public IPravocrtnoTijeloModel StvoriFizikalniModel(int levelToUse)
        {
            RandomVrijednosti(levelToUse);
            return tijelo = new PravocrtnoAvionModel
            {
                Tijelo = "avion",
                VSTijelo = "Avion",
                SeKreće = "leti",
                Prođe = "preleti",
                Prešlo = "preletio",
                VeličinaMjerneJedinice = "km, h",
                PutVrijednost = PutVrijednost,
                BrzinaVrijednost = BrzinaVrijednost,
                VrijemeVrijednost = VrijemeVrijednost,
            };
        }
    }
}
