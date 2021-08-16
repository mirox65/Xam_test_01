using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;

namespace Xam_test_01.Factory
{
    public class UbrzanoTijeloModelFactory
    {
        readonly List<IUbrzanoTijeloModel> ubrzanoTijeloModels = new List<IUbrzanoTijeloModel>();

        public UbrzanoTijeloModelFactory()
        {
            ubrzanoTijeloModels.Add(new UbrzanoTijeloModel());
            ubrzanoTijeloModels.Add(new UbrzanoAvionModel());
        }

        public IUbrzanoTijeloModel StvoriKinematikTijeloaModel(int levelToUse)
        {
            var i = Random();
            return ubrzanoTijeloModels[i].StvoriFizikalniModel(levelToUse);
        }

        private int Random()
        {
            var rand = new Random();
            return rand.Next(0, ubrzanoTijeloModels.Count);
        }

    }
}
