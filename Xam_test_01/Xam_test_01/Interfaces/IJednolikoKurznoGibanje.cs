using System;
using System.Collections.Generic;
using System.Text;

namespace Xam_test_01.Interfaces
{
    public interface IJednolikoKurznoGibanje : IKinematika
    {
        string BrojOkretaja { get; }
        string Polumjer { get; }
        string Pi { get; }
        string Dijametar { get; }
        string KutnaBrzina { get; }
        string Kut { get; }
        string VrijemePeriod { get; }
        string Frekvencija { get; }
        string Vrijeme { get; }
        IKružnoTijeloModel Tijelo { get; set; }
        void StvoriTijeloModel();
    }
}
