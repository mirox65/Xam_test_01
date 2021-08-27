using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;

namespace Xam_test_01.Models
{
    public class KružnoKotačModel : IKružnoTijeloModel
    {
        public string Tijelo { get; private set; }

        public string VSTijelo { get; private set; }

        public string Tijela { get; private set; }

        public string Okrenulo { get; private set; }

        public string VeličinaMjerneJedinice { get; set; }

        public double BrojOkretajaVrijednost { get; private set; }

        public double FrekvencijaVrijednost { get; private set; }

        public double VrijemePeriodVrijednost { get; private set; }

        public double VrijemeVrijednost { get; private set; }

        public void RandomVrijednosti()
        {
            var random = new Random();
            BrojOkretajaVrijednost = random.Next(1, 40);
            FrekvencijaVrijednost = random.Next(1, 20);
            VrijemePeriodVrijednost = random.Next(1, 10);
            VrijemeVrijednost = random.Next(1, 10);
        }

        public IKružnoTijeloModel StvoriFizikalniModel()
        {
            RandomVrijednosti();
            return new KružnoKotačModel
            {
                Tijelo = "kotač",
                VSTijelo = "Kotač",
                Tijela = "kotača",
                Okrenulo = "okrenuo",
                VeličinaMjerneJedinice = "m, s",
                BrojOkretajaVrijednost = BrojOkretajaVrijednost,
                FrekvencijaVrijednost = FrekvencijaVrijednost,
                VrijemePeriodVrijednost = VrijemePeriodVrijednost,
                VrijemeVrijednost = VrijemeVrijednost
            };
        }
    }
}
