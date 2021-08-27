using System.Collections;
using System.Collections.Generic;
using Xam_test_01.Interfaces;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class JednolikoPravocrtnoPitanjeModel
    {
        private readonly RječnikFizikalnihVeličinaMjernihJedinica dicFizVeličina = new RječnikFizikalnihVeličinaMjernihJedinica();
        private readonly ListaOdgovora listaOdgovora = new ListaOdgovora();

        public string FizVel1 { get; set; }
        public string FizVel2 { get; set; }
        public string FizVelRjesenje { get; set; }
        public double Vrijednost1 { get; set; }
        public double Vrijednost2 { get; set; }
        public double VrijednostRješenje { get; set; }
        public string MJ1 { get; set; }
        public string MJ2 { get; set; }
        public string MJRješenje { get; set; }
        public string FormulaImage { get; set; }
        public ArrayList OdgovorArray { get; set; }
        public string Formula { get; private set; }
        public Dictionary<string, string> DicVrijednosti { get; private set; }

        private PitanjeModel VratiModel() => new PitanjeModel
        {
            FizVel1 = FizVel1,
            FizVel2 = FizVel2,
            FizVelRjesenja = FizVelRjesenje,
            Vrijednost1 = Vrijednost1,
            Vrijednost2 = Vrijednost2,
            VrijednostRješenja = VrijednostRješenje,
            MJ1 = MJ1,
            MJ2 = MJ2,
            MJRješenje = MJRješenje,
            FormulaImage = FormulaImage,
            OdgovorArray = OdgovorArray,
        };

        public PitanjeModel OdabirMetode(string param, IPravocrtnoTijeloModel tijelo)
        {
            Formula = param;
            DicVrijednosti = dicFizVeličina.FzikalneMjerneJediniceRiječnik(tijelo.VeličinaMjerneJedinice);
            switch (param)
            {
                case ("Svt"):
                    SvtSetUp(param, tijelo);
                    break;
                case ("Vst"):
                    VstSetUp(param, tijelo);
                    break;
                case ("Tsv"):
                    TsvSetUp(param, tijelo);
                    break;
            }
            OdgovorArray = listaOdgovora.ListaOdgovoraDvijeVarijable(VratiModel());
            return VratiModel();
        }

        private void TsvSetUp(string param, IPravocrtnoTijeloModel tijelo)
        {
            FizVel1 = FizikalneVeličine.Put;
            FizVel2 = FizikalneVeličine.Brzina;
            FizVelRjesenje = FizikalneVeličine.Vrijeme;

            Vrijednost1 = tijelo.PutVrijednost;
            Vrijednost2 = tijelo.BrzinaVrijednost;
            VrijednostRješenje = Formule.TsvFormula(Vrijednost1, Vrijednost2);

            MJ1 = dicFizVeličina.NazivMJ(FizVel1);
            MJ2 = dicFizVeličina.NazivMJ(FizVel2);
            MJRješenje = dicFizVeličina.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }

        private void VstSetUp(string param, IPravocrtnoTijeloModel tijelo)
        {

            FizVel1 = FizikalneVeličine.Put;
            FizVel2 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Brzina;

            Vrijednost1 = tijelo.PutVrijednost;
            Vrijednost2 = tijelo.VrijemeVrijednost;
            VrijednostRješenje = Formule.VstFormula(Vrijednost1, Vrijednost2);

            MJ1 = dicFizVeličina.NazivMJ(FizVel1);
            MJ2 = dicFizVeličina.NazivMJ(FizVel2);
            MJRješenje = dicFizVeličina.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }

        public void SvtSetUp(string param, IPravocrtnoTijeloModel tijelo)
        {
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Put;

            Vrijednost1 = tijelo.BrzinaVrijednost;
            Vrijednost2 = tijelo.VrijemeVrijednost;
            VrijednostRješenje = Formule.SvtFormula(Vrijednost1, Vrijednost2);

            MJ1 = dicFizVeličina.NazivMJ(FizVel1);
            MJ2 = dicFizVeličina.NazivMJ(FizVel2);
            MJRješenje = dicFizVeličina.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }
    }
}
