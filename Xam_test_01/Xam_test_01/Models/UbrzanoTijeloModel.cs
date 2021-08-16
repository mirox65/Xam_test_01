using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;

namespace Xam_test_01.Models
{
    public class UbrzanoTijeloModel : IUbrzanoTijeloModel
    {
        private UbrzanoTijeloModel tijelo;

        public string VSTijelo { get; private set; }

        public string Tijelo { get; private set; }

        public string Tijela { get; set; }

        public string SeKreće { get; private set; }

        public string Prođe { get; private set; }

        public string Prešlo  { get; private set; } 

        public string VeličinaMjerneJedinice { get; private set; }

        public double AkceleracijaVrijednost { get; private set; }

        public double BrzinaVrijednost { get; private set; }

        public double VrijemeVrijednost { get; private set; }

        public double PutVrijednost { get; private set; }

        public double VNulaBrzinaVrijednost { get; private set; }


        public void RandomVrijednosti(int levelToUse)
        {
            var random = new Random();
            AkceleracijaVrijednost = random.Next(1, 6);
            BrzinaVrijednost = random.Next(1, 13);
            VNulaBrzinaVrijednost = random.Next(1, 13);
            VrijemeVrijednost = random.Next(1, 50);
            PutVrijednost = random.Next(1, 10);
        }

        public IUbrzanoTijeloModel StvoriFizikalniModel(int levelToUse)
        {
            RandomVrijednosti(levelToUse);
            return tijelo = new UbrzanoTijeloModel
            {
                VSTijelo = "Tijelo",
                Tijelo = "tijelo",
                Tijela = "tijela",
                SeKreće = "se kreće",
                Prođe = "prođe",
                Prešlo = "prešlo",
                VeličinaMjerneJedinice = "m, s",
                AkceleracijaVrijednost = AkceleracijaVrijednost,
                BrzinaVrijednost = BrzinaVrijednost,
                VrijemeVrijednost = VrijemeVrijednost,
                PutVrijednost = PutVrijednost,
                VNulaBrzinaVrijednost = VNulaBrzinaVrijednost
            };
        }
    }
}
