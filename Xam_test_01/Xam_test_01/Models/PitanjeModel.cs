using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Xam_test_01.Models
{
    public class PitanjeModel
    {
        public string Pitanje { get; set; }
        public string Ogovor { get; set; }
        public string ObavjestNakonOdgovora { get; set; }
        public string FormulaImage { get; set; }
        public Color BojaPozdaineOdgovora { get; set; }
        public ArrayList OdgovorArray { get; set; }
        public double MinVrijednostRješenja { get; set; }
        public double MaxVrijednostRješenja { get; set; }
        public string FizVel1 { get; internal set; }
        public string FizVel2 { get; internal set; }
        public string FizVelRjesenja { get; internal set; }
        public double Vrijednost1 { get; internal set; }
        public double Vrijednost2 { get; internal set; }
        public double VrijednostRješenja { get; internal set; }
        public string MJ1 { get; internal set; }
        public string MJ2 { get; internal set; }
        public string MJRješenje { get; internal set; }
        public int Level { get; internal set; }
    }
}
