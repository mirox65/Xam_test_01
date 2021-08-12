using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;

namespace Xam_test_01.Factory
{
    public class KinematikaTijeloModelFactory
    {
        readonly List<IKinematikaTijeloModel> kinematikaTijeloModels = new List<IKinematikaTijeloModel>();
        public KinematikaTijeloModelFactory()
        {
            kinematikaTijeloModels.Add(new KinematikaAvionModel());
            kinematikaTijeloModels.Add(new KinematikaBiciklModel());
            kinematikaTijeloModels.Add(new KinematikaTijeloModel());
        }
        public IKinematikaTijeloModel StvoriKinematikTijeloaModel()
        {
            var i = Random();
            return kinematikaTijeloModels[i].StvoriFizikalniModel();
        }

        private int Random()
        {
            var rand = new Random();
            return rand.Next(0, kinematikaTijeloModels.Count);
        }
    }
}
