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
                {"Avv0s", "Avv0sFormula.PNG" },
                {"Avv0t", "Avv0tFormula.PNG" },
                {"Sv0vt", "Sv0vtFormula.PNG" },
                {"Svv0a", "Svv0aFormula.PNG" },
                {"Fnt", "FntFormula.PNG" },
                {"VTtn", "VTtnFormula.PNG" },
                {"OmegaPiVT", "OmegaPiVTFormula.PNG" },
            };
        }

        public static string ImageSource(string param)
        {
            StvoriBiblioteku();
            return BibliotekaSlikaFormula.First(s => s.Key == param).Value;
        }
    }
}
