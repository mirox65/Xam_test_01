using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Grane.Mehanika.Kinematika;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;

namespace Xam_test_01.Factory
{
    public class KinematikaModelFactory
    {
        readonly List<IKinematikaModel> kinematikaModels = new List<IKinematikaModel>();
        public KinematikaModelFactory()
        {
            kinematikaModels.Add(new JednolikoPravocrtnoGibanje());
            kinematikaModels.Add(new JednolikoUbrzanoGibanje());
            kinematikaModels.Add(new JednolikoKruznoGibanje());
        }

        public PitanjeModel StvoriKinematikaModel(int levelToUse, int indexTeme)
        {
            return kinematikaModels[indexTeme].GeneriranjePitanja(levelToUse);
        }
    }
}
