using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class PravocrtnoBiciklModel : IPravocrtnoTijeloModel
    {
        private PravocrtnoBiciklModel tijelo;

        public string Tijelo { get; private set; }

        public string VSTijelo { get; set; }

        public string SeKreće { get; private set; }

        public string Prođe { get; private set; }

        public string VeličinaMjerneJedinice { get; private set; }

        public double AkceleracijaVrijednost { get; private set; }

        public double BrzinaVrijednost { get; private set; }

        public double VrijemeVrijednost { get; private set; }

        public double PutVrijednost { get; private set; }
        public string Prešlo { get; private set; }

        public double VNulaBrzinaVrijednost { get; private set; }

        public IPravocrtnoTijeloModel StvoriFizikalniModel(int levelToUse)
        {
            var mj = MjernaJedinica(levelToUse);
            RandomVrijednosti(levelToUse);
            return tijelo = new PravocrtnoBiciklModel
            {
                Tijelo = "bicikl",
                VSTijelo = "Bicikl",
                SeKreće = "se giba",
                Prođe = "pređe",
                Prešlo = "prešao",
                VeličinaMjerneJedinice = mj,
                AkceleracijaVrijednost = AkceleracijaVrijednost,
                BrzinaVrijednost = BrzinaVrijednost,
                VrijemeVrijednost = VrijemeVrijednost,
                PutVrijednost = PutVrijednost,
                VNulaBrzinaVrijednost = VNulaBrzinaVrijednost
            };
        }

        private string MjernaJedinica(int levelToUse)
        {
            if (levelToUse < 3)
            {
                return "m, s";
            }
            else
            {
                return "km, h";
            }
        }

        public void RandomVrijednosti(int levelToUse)
        {
            var random = new Random();
            if (levelToUse < 3)
            {
                AkceleracijaVrijednost = random.Next(1, 5);
                BrzinaVrijednost = random.Next(1, 12);
                VNulaBrzinaVrijednost = random.Next(0, 11);
                VrijemeVrijednost = random.Next(1, 5);
                PutVrijednost = random.Next(1, 60);
            }
            else
            {
                AkceleracijaVrijednost = random.Next(1, 10);
                BrzinaVrijednost = random.Next(1, 40);
                VNulaBrzinaVrijednost = random.Next(0, 10);
                VrijemeVrijednost = random.Next(1, 18);
                PutVrijednost = random.Next(1, 60);
            }
        }
    }
}
