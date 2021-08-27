using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class JednolikoKružnoPitanjeModel
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


        internal PitanjeModel OdabirMetode(string param, IKružnoTijeloModel tijelo)
        {
            DicVrijednosti = dicFizVeličina.FzikalneMjerneJediniceRiječnik(tijelo.VeličinaMjerneJedinice);
            switch (param)
            {
                case ("VTtn"):
                    VTtnSetUp(param, tijelo);
                    break;
                case ("Fnt"):
                    FntSetUp(param, tijelo);
                    break;
                case ("OmegaPiVT"):
                    OmegaPiVT(param, tijelo);
                    break;
            }
            OdgovorArray = listaOdgovora.ListaOdgovoraDvijeVarijable(VratiModel());
            return VratiModel();
        }

        private void OmegaPiVT(string param, IKružnoTijeloModel tijelo)
        {
            FizVel1 = FizikalneVeličine.Pi;
            FizVel2 = FizikalneVeličine.VrijemePeriod;
            FizVelRjesenje = FizikalneVeličine.KutnaBrzina;

            Vrijednost1 = 3.14;
            Vrijednost2 = tijelo.VrijemePeriodVrijednost;
            VrijednostRješenje = Formule.OmegaPiVTFormula(Vrijednost1, Vrijednost2);

            MJ1 = dicFizVeličina.NazivMJ(FizVel1);
            MJ2 = dicFizVeličina.NazivMJ(FizVel2);
            MJRješenje = dicFizVeličina.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }

        private void FntSetUp(string param, IKružnoTijeloModel tijelo)
        {
            FizVel1 = FizikalneVeličine.BrojOkretaja;
            FizVel2 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Frekvencija;

            Vrijednost1 = tijelo.BrojOkretajaVrijednost;
            Vrijednost2 = tijelo.VrijemeVrijednost;
            VrijednostRješenje = Formule.FntFormula(Vrijednost1, Vrijednost2);

            MJ1 = dicFizVeličina.NazivMJ(FizVel1);
            MJ2 = dicFizVeličina.NazivMJ(FizVel2);
            MJRješenje = dicFizVeličina.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }

        private void VTtnSetUp(string param, IKružnoTijeloModel tijelo)
        {
            FizVel1 = FizikalneVeličine.Vrijeme;
            FizVel2 = FizikalneVeličine.BrojOkretaja;
            FizVelRjesenje = FizikalneVeličine.VrijemePeriod;

            Vrijednost1 = tijelo.VrijemeVrijednost;
            Vrijednost2 = tijelo.BrojOkretajaVrijednost;
            VrijednostRješenje = Formule.VTtnFormula(Vrijednost1, Vrijednost2);

            MJ1 = dicFizVeličina.NazivMJ(FizVel1);
            MJ2 = dicFizVeličina.NazivMJ(FizVel2);
            MJRješenje = dicFizVeličina.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }

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
    }
}
