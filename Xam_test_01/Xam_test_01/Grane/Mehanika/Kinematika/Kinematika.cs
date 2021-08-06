using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;

namespace Xam_test_01.Grane.Mehanika.Kinematika
{
    class Kinematika
    {
        private readonly JednolikoPravocrtnoGibanje jednolikoPravocrtnoGibanje = new JednolikoPravocrtnoGibanje();
        private readonly JednolikoUbrzanoGibanje jednolikoUbrzanoGibanje = new JednolikoUbrzanoGibanje();
        private readonly JednolikoKruznoGibanje jednolikoKruznoGibanje = new JednolikoKruznoGibanje();
        private readonly Random random = new Random();

        internal PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            switch (levelToUse)
            {
                case 1:
                    return jednolikoPravocrtnoGibanje.GeneriranjePitanja(levelToUse);
                case 2:
                    return Level2(levelToUse);
                case 3:
                   return Level3(levelToUse);
            }
            return new PitanjeModel();
        }

        private PitanjeModel Level2(int levelToUse)
        {
            switch (random.Next(1, 3))
            {
                case 1:
                    return jednolikoPravocrtnoGibanje.GeneriranjePitanja(levelToUse);
                case 2:
                    return jednolikoUbrzanoGibanje.GeneriranjePitanja(levelToUse);
            }
            return new PitanjeModel();
        }

        private PitanjeModel Level3(int levelToUse)
        {
            switch (random.Next(1,4))
            {
                case 1:
                    return jednolikoPravocrtnoGibanje.GeneriranjePitanja(levelToUse);
                case 2:
                    return jednolikoUbrzanoGibanje.GeneriranjePitanja(levelToUse);
                case 3:
                    return jednolikoKruznoGibanje.GeneriranjePitanja(levelToUse);
            }
            return new PitanjeModel();
        }
    }
}
