using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Grane.Mehanika.Kinematika;

namespace Xam_test_01.Pomocne
{
    public class OdabirGranaPitanja
    {
        public string Pitanje { get; internal set; }
        public ArrayList OdgovorArray { get; set; }
        public double MinVrijednostRješenja { get; set; }
        public double MaxVrijednostRješenja { get; set; }
        public string MjernaJedinicaOdgvora { get; set; }

        internal void GeneriranjePitanja(string tema)
        {
            switch (tema)
            {
                case "Kinematika":
                    var kinematika = new JednolikoPravocrtnoGibanje();
                    kinematika.GeneriranjePitanja();
                    Pitanje = kinematika.Pitanje;
                    OdgovorArray = kinematika.OdgovorArray;
                    MinVrijednostRješenja = kinematika.MinVrijednostRješenja;
                    MaxVrijednostRješenja = kinematika.MaxVrijednostRješenja;
                    MjernaJedinicaOdgvora = kinematika.MjernaJedinicaOdgovora;
                    break;
                default:
                    break;
            }
        }
    }
}
