using System;
using Xam_test_01.Interfaces;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class PravocrtnoTijeloModel : IPravocrtnoTijeloModel
    {
        private PravocrtnoTijeloModel tijelo;

        public string Tijelo { get; private set; }

        public string VSTijelo { get; set; }

        public string SeKreće { get; private set; }

        public string Prođe { get; private set; }

        public string Prešlo { get; private set; }

        public string VeličinaMjerneJedinice { get; set; }

        public double BrzinaVrijednost { get; set; }

        public double VrijemeVrijednost { get; set; }

        public double PutVrijednost { get; set; }


        public IPravocrtnoTijeloModel StvoriFizikalniModel(int levelToUse)
        {
            RandomVrijednosti(levelToUse);
            return tijelo = new PravocrtnoTijeloModel
            {
                Tijelo = "tijelo",
                VSTijelo = "Tijelo",
                SeKreće = "se kreće",
                Prođe = "prođe",
                Prešlo = "prešlo",
                VeličinaMjerneJedinice = "m, s",
                BrzinaVrijednost = BrzinaVrijednost,
                VrijemeVrijednost = VrijemeVrijednost,
                PutVrijednost = PutVrijednost,
            };
        }

        public void RandomVrijednosti(int levelToUse)
        {
            var random = new Random();
            BrzinaVrijednost = random.Next(1, 20);
            VrijemeVrijednost = random.Next(1, 1200);
            PutVrijednost = random.Next(1, 5000);
        }
    }
}
