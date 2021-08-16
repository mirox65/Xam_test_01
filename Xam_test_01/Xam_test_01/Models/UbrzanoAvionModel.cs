using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;

namespace Xam_test_01.Models
{
    class UbrzanoAvionModel : IUbrzanoTijeloModel
    {
        private UbrzanoAvionModel tijelo;

        public string VSTijelo { get; private set; }

        public string Tijelo { get; private set; }

        public string Tijela { get; private set; }

        public string SeKreće { get; private set; }

        public string Prođe { get; private set; }

        public string Prešlo { get; private set; }

        public string VeličinaMjerneJedinice { get; private set; }

        public double AkceleracijaVrijednost { get; private set; }

        public double BrzinaVrijednost { get; private set; }

        public double VrijemeVrijednost { get; private set; }

        public double PutVrijednost { get; private set; }

        public double VNulaBrzinaVrijednost { get; private set; }

        

        public void RandomVrijednosti(int levelToUse)
        {
            var random = new Random();
            if (levelToUse < 3)
            {
                AkceleracijaVrijednost = random.Next(1, 16);
                BrzinaVrijednost = random.Next(55, 196);
                VNulaBrzinaVrijednost = random.Next(55, 196);
                VrijemeVrijednost = random.Next(1, 10);
                PutVrijednost = random.Next(1, 536);
            }
            else
            {
                AkceleracijaVrijednost = random.Next(1, 16);
                BrzinaVrijednost = random.Next(200, 701);
                VNulaBrzinaVrijednost = random.Next(200, 701);
                VrijemeVrijednost = random.Next(1, 10);
                PutVrijednost = random.Next(1, 536);
            }
        }

        public IUbrzanoTijeloModel StvoriFizikalniModel(int levelToUse)
        {
            var mj = MjernaJedinicaToUse(levelToUse);
            RandomVrijednosti(levelToUse);
            return tijelo = new UbrzanoAvionModel
            {
                VSTijelo = "Avion",
                Tijelo = "avion",
                Tijela = "aviona",
                SeKreće = "leti",
                Prođe = "preleti",
                Prešlo = "preletio",
                VeličinaMjerneJedinice = mj,
                AkceleracijaVrijednost = AkceleracijaVrijednost,
                BrzinaVrijednost = BrzinaVrijednost,
                VrijemeVrijednost = VrijemeVrijednost,
                PutVrijednost = PutVrijednost,
                VNulaBrzinaVrijednost = VNulaBrzinaVrijednost
            };
        }

        private string MjernaJedinicaToUse(int levelToUse)
        {
            if (levelToUse < 3)
            {
                return "m, s";
            }
            else
            {
                return "km, s";
            }
        }
    }
}
