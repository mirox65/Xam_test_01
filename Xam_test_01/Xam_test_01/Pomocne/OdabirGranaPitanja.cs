using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Grane.Mehanika.Kinematika;
using Xam_test_01.Services;

namespace Xam_test_01.Pomocne
{
    public class OdabirGranaPitanja
    {
        public string Pitanje { get; internal set; }
        public ArrayList OdgovorArray { get; set; }
        public string FormulaImageSource { get; set; }
        public double MinVrijednostRješenja { get; set; }
        public double MaxVrijednostRješenja { get; set; }
        public string MjernaJedinicaOdgvora { get; set; }

        internal void GeneriranjePitanja(string tema)
        {
            var level = DataBaseService.SelectLevel(tema).Result;
            var countTotalEntries = DataBaseService.SelectCount(tema, level).Result;
            var countCorrectAnswers = DataBaseService.SelectCorrectCount(tema, level).Result;

            var levelToUse = LevelUp(level, countTotalEntries, countCorrectAnswers);

            switch (tema)
            {
                case "Kinematika":
                    var kinematika = new JednolikoPravocrtnoGibanje();
                    kinematika.GeneriranjePitanja(levelToUse);
                    Pitanje = kinematika.Pitanje;
                    OdgovorArray = kinematika.OdgovorArray;
                    FormulaImageSource = kinematika.FormulaImageSource;
                    MinVrijednostRješenja = kinematika.MinVrijednostRješenja;
                    MaxVrijednostRješenja = kinematika.MaxVrijednostRješenja;
                    MjernaJedinicaOdgvora = kinematika.MjernaJedinicaOdgovora;
                    break;
                default:
                    break;
            }
        }
        private int LevelUp(int level, int totalEntries, int correctAnswers)
        {
            if (totalEntries > 10 && (correctAnswers / totalEntries) > 0.6)
            {
                level = 2;
            }
            else if (totalEntries > 20 && (correctAnswers / totalEntries) > 0.6)
            {
                level = 3;
            }
            else
            {
                level = 1;
            }
            return level;
        }
    }
}
