using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;

namespace Xam_test_01.Interfaces
{
    public interface IJednolikoPravocrtnoGibanje : IKinematika
    {
        string Put { get; }
        string Vrijeme { get; }
        void StvoriTijeloModel(int levelToUse);

        IPravocrtnoTijeloModel Tijelo { get; set; }
    }
}
