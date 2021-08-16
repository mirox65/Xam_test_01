using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;

namespace Xam_test_01.Factory
{
    public class PravocrtnoTijeloModelFactory
    {
        readonly List<IPravocrtnoTijeloModel> pravocrtnoTijeloModels = new List<IPravocrtnoTijeloModel>();

        public PravocrtnoTijeloModelFactory()
        {
            pravocrtnoTijeloModels.Add(new PravocrtnoTijeloModel());
            pravocrtnoTijeloModels.Add(new PravocrtnoBiciklModel());
            pravocrtnoTijeloModels.Add(new PravocrtnoAvionModel());
        }

        public IPravocrtnoTijeloModel StvoriKinematikTijeloaModel(int levelToUse)
        {
            var i = Random();
            return pravocrtnoTijeloModels[i].StvoriFizikalniModel(levelToUse);
        }

        private int Random()
        {
            var rand = new Random();
            return rand.Next(0, pravocrtnoTijeloModels.Count);
        }
    }
}
