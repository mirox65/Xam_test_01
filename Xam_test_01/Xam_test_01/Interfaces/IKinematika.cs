using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Interfaces
{
    public interface IKinematika
    {
        string Brzina { get; }

        string Pitanje { get; }

        int Razina { get; }

        PitanjeModel NovoPitanje { get; }

        double MinVrijednostRješenja { get; }

        double MaxVrijednostRješenja { get; }

        Dictionary<int, string> RiječnikPitanja { get; set; }

        Dictionary<string, string> DicFizVeličina { get; }

        void StvoriRječnikVrijednosti();

        void OdabirPitanja();

        void GraniceVrijednostiRješenja(double vrijednostRješenja);

        PitanjeModel AppendToNovoPitanje();

        PitanjeModel GeneriranjePitanja(int levelToUse);
    }
}