using System;
using System.Collections.Generic;
using System.Text;

namespace Xam_test_01.Pomocne
{
    public static class MjerneJedinice
    {
        public static string Metar { get; } = "m";
        public static string Sekunda { get; } = "s";
        public static string Na2 { get; } = "\u00B2";
        public static string Na3 { get; } = "\u00B3";
        public static string MetarSekundaNa2 { get;  } = "m/s\u00B2";
        public static string MetarSekunda { get; } = "m/s";

        public static string Kilometar { get; set; } = "km";
        public static string Sat { get; set; } = "h";
        public static string KilometarSat { get; set; } = "km/h";
        public static string KilometarSatNa2 { get; set; } = "km/h\u00B2";
    }
}
