using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class KinematikaBiciklModel : IKinematikaTijeloModel
    {
        private KinematikaBiciklModel tijelo;

        public string Tijelo { get; private set; }

        public string SeKreće { get; private set; }

        public string Prođe { get; private set; }

        public string VeličinaMjerneJedinice { get; private set; }

        public double AkceleracijaVrijednost { get; private set; }

        public double BrzinaVrijednost { get; private set; }

        public double VrijemeVrijednost { get; private set; }

        public double PutVrijednost { get; private set; }

        public IKinematikaTijeloModel StvoriFizikalniModel()
        {
            RandomVrijednosti();
            return tijelo = new KinematikaBiciklModel
            {
                Tijelo = "bicikl",
                SeKreće = "se giba",
                Prođe = "pređe",
                VeličinaMjerneJedinice = "km, h",
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
            BrzinaVrijednost = random.Next(1, 40);
            VrijemeVrijednost = random.Next(1, 18);
            PutVrijednost = random.Next(1, 60);
        }
    }
}
