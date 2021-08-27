using System;
using System.Collections.Generic;
using System.Text;

namespace Xam_test_01.Interfaces
{
    public interface IUbrzanoTijeloModel
    {
        string VSTijelo { get; }
        string Tijelo { get; }
        string SeKreće { get; }
        string Prođe { get; }
        string Prešlo { get; }
        string VeličinaMjerneJedinice { get; }
        double AkceleracijaVrijednost { get; }
        double BrzinaVrijednost { get; }
        double VrijemeVrijednost { get; }
        double PutVrijednost { get; }
        double VNulaBrzinaVrijednost { get; }
        string Tijela { get; }

        IUbrzanoTijeloModel StvoriFizikalniModel(int levelToUse);

        void RandomVrijednosti(int levelToUse);
    }
}
