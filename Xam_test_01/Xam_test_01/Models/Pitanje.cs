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

        public Color NavigacijaDrugaBoja { get; set; } = Color.FromArgb(153, 153, 255);
        public Color PrimarnaBoja { get; set; } = Color.FromArgb(255, 255, 153);
        public Color GridBackColor { get; set; } = Color.FromArgb(243, 242, 242);
    }
}
