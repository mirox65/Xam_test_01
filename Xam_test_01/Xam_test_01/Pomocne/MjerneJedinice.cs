using System;
using System.Collections.Generic;
using System.Text;

namespace Xam_test_01.Pomocne
{
    public class MjerneJedinice
    {
        public string Metar { get; } = "m";
        public string Sekunda { get; } = "s";
        public string Na2 { get; } = "\u00B2";
        public string Na3 { get; } = "\u00B3";
        public string MetarSekundaNa2 { get;  } = "m/s\u00B2";
        public string MetarSekunda { get; } = "m/s";
    }
}
