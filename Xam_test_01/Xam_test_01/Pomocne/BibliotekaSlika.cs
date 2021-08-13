using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xam_test_01.Pomocne
{
    public static class BibliotekaSlika
    {
        public static Dictionary<string, string> BibliotekaSlikaFormula { get; set; }

        private static void StvoriBiblioteku()
        {
            BibliotekaSlikaFormula = new Dictionary<string, string>
            {
                {"Tsv", "TsvFormula.PNG" },
                {"Svt", "SvtFormula.PNG" },
                {"Vst", "VstFormula.PNG" },
                {"Vat", "VatFormula.PNG" },
                {"Avt", "AvtFormula.PNG" },
                {"Tva", "TvaFormula.PNG" },
            };
        }

        public static string ImageSource(string param)
        {
            StvoriBiblioteku();
            return BibliotekaSlikaFormula.First(s => s.Key == param).Value;
        }

        public static string TsvFormulaImage { get; set; } = "TsvFormula.PNG";
        public static string SvtFormulaImage { get; set; } = "SvtFormula.PNG";
        public static string VstFormulaImage { get; set; } = "VstFormula.PNG";
        public static string VatFormulaImage { get; set; } = "VatFormula.PNG";
        public static string AvtFormulaImage { get; set; } = "AvtFormula.PNG";
        public static string TvaFormulaImage { get; set; } = "TvaFormula.PNG";
    }
}
