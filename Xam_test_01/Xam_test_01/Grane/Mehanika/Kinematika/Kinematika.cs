using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Factory;
using Xam_test_01.Models;

namespace Xam_test_01.Grane.Mehanika.Kinematika
{
    class Kinematika
    {
        private readonly KinematikaModelFactory kinematikaModelFactory = new KinematikaModelFactory();
        private readonly Random random = new Random();

        internal PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            switch (levelToUse)
            {
                case 1:
                    return kinematikaModelFactory.StvoriKinematikaModel(levelToUse, 0);
                case 2:
                    return Level2(levelToUse);
                case 3:
                   return Level3(levelToUse);
            }
            return new PitanjeModel();
        }

        private PitanjeModel Level2(int levelToUse)
        {
            int indexTeme = random.Next(0, 2);
            return kinematikaModelFactory.StvoriKinematikaModel(levelToUse, indexTeme);
        }

        private PitanjeModel Level3(int levelToUse)
        {
            var indexTeme = random.Next(0, 3);
            return kinematikaModelFactory.StvoriKinematikaModel(levelToUse, indexTeme);
        }
    }
}
