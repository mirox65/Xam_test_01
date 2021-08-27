using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;

namespace Xam_test_01.Interfaces
{

    public interface IJednolikoUbrzanoGibanje : IKinematika
    {
        string VNulaBrzna { get; }

        string VrijemeNa2 { get; }

        string Akceleracija { get; }

        void StvoriTijeloModel(int levelToUse);

        IUbrzanoTijeloModel Tijelo { get; set; }
    }
}
