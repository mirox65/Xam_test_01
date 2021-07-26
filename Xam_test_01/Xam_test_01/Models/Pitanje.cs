using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Xam_test_01.Models
{
    public class Pitanje
    {
        public string PrikaziGeneriranoPitanje { get; set; }
        public string PrikaziOdgovorNaPitanje { get; set; }
        public double RješenjeJednadžbe { get; set; }
        public string ObavjestNakonOdgovora { get; set; }
        public string MjernaJedinicaOdgovora { get; set; }
        public Color BojaPozdaineOdgovora { get; set; }
    }
}
