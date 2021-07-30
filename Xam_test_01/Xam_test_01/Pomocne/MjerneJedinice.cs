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
    }
}
