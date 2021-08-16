using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;

namespace Xam_test_01.Interfaces
{

    public interface IJednolikoUbrzanoGibanje : IKinematikaModel
    {
        string VNulaBrzna { get; }

        string VrijemeNa2 { get; }

        string Akceleracija { get; }

        IUbrzanoTijeloModel Tijelo { get; set; }
    }
}
