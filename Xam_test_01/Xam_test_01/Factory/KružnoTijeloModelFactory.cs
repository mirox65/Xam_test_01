using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;

namespace Xam_test_01.Factory
{
    public class KružnoTijeloModelFactory
    {
        readonly List<IKružnoTijeloModel> kružnoTijeloModels = new List<IKružnoTijeloModel>();

        public KružnoTijeloModelFactory()
        {
            kružnoTijeloModels.Add(new KružnoKotačModel());
            kružnoTijeloModels.Add(new KružnoPločaModel());
        }

        public IKružnoTijeloModel StvoriKinematikTijeloaModel()
        {
            var i = Random();
            return kružnoTijeloModels[i].StvoriFizikalniModel();
        }

        private int Random()
        {
            var rand = new Random();
            return rand.Next(0, kružnoTijeloModels.Count);
        }
    }
}
