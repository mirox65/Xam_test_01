using System;
using System.Collections.Generic;
using System.Text;

namespace Xam_test_01.Interfaces
{
    public interface IKružnoTijeloModel
    {
        string Tijelo { get; }
        string VSTijelo { get; }
        string Tijela { get; }
        string VeličinaMjerneJedinice { get; }
        double BrojOkretajaVrijednost { get; }
        double FrekvencijaVrijednost { get; }
        double VrijemePeriodVrijednost { get; }
        double VrijemeVrijednost { get; }
        IKružnoTijeloModel StvoriFizikalniModel();
        void RandomVrijednosti();
    }
}
