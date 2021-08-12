namespace Xam_test_01.Interfaces
{
    public interface IKinematikaTijeloModel
    {
        string Tijelo { get; }
        string SeKreće { get; }
        string Prođe { get; }
        string VeličinaMjerneJedinice { get; }
        double AkceleracijaVrijednost { get; }
        double BrzinaVrijednost { get; }
        double VrijemeVrijednost { get; }
        double PutVrijednost { get; }

        IKinematikaTijeloModel StvoriFizikalniModel();

        void RandomVrijednosti();
    }
}
