using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Interfaces
{
    public interface IKinematikaModel
    {
        string Akceleracija { get; }

        string Brzina { get; }

        IKinematikaTijeloModel Tijelo { get; set; }

        PitanjeModel GeneriranjePitanja(int levelToUse);

        Dictionary<int, string> RiječnikPitanja { get; set; }

    }
}
