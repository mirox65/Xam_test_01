using Xam_test_01.Grane.Mehanika.Kinematika;
using Xam_test_01.Models;
using Xam_test_01.Services;

namespace Xam_test_01.Pomocne
{
    public class OdabirGranaPitanja
    {
        internal PitanjeModel GeneriranjePitanja(string tema)
        {
            var kinematika = new Kinematika();
            var pitanje = new PitanjeModel();

            var level = DataBaseService.SelectLevel(tema).Result;
            var countTotalEntries = DataBaseService.SelectCount(tema, level).Result;
            var countCorrectAnswers = DataBaseService.SelectCorrectCount(tema, level).Result;

            var levelToUse = LevelUp(level, countTotalEntries, countCorrectAnswers);

            switch (tema)
            {
                case "Kinematika":
                    return kinematika.GeneriranjePitanja(levelToUse);
                default:
                    break;
            }
            return pitanje;
        }

        private int LevelUp(int level, int totalEntries, int correctAnswers)
        {
            double postotak = (double)correctAnswers / totalEntries;
            if (level == 1)
            {
                if (totalEntries > 10 && postotak > 0.6)
                    level = 2;
            }
            else if (level == 2)
            {
                if (totalEntries > 20 && postotak > 0.6)
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
