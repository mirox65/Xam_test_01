namespace Xam_test_01.Interfaces
{
    public interface IPravocrtnoTijeloModel
    {
        string Tijelo { get; }
        string VSTijelo { get; }
        string SeKreće { get; }
        string Prođe { get; }
        string Prešlo { get; }
        string VeličinaMjerneJedinice { get; }
        double BrzinaVrijednost { get; }
        double VrijemeVrijednost { get; }
        double PutVrijednost { get; }

        IPravocrtnoTijeloModel StvoriFizikalniModel(int levelToUse);

        void RandomVrijednosti(int levelToUse);
    }
}
