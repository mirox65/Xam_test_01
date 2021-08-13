using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class JednolikoUbrzanoPitanjeModel
    {
        private readonly Vrijednosti vrijednosti = new Vrijednosti();
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
        public Dictionary<string, string> RječnikVrijednosti { get; set; }

        public PitanjeModel OdabirMetode(string param, double vrijednost1, double vrijednost2, string mj)
        {
            RječnikVrijednosti = vrijednosti.FzikalneMjerneJediniceRiječnik(mj);
            switch (param)
            {
                case ("Vat"):
                    VatSetUp(vrijednost1, vrijednost2);
                    break;
                case ("Tva"):
                    TvaSetUp(vrijednost1, vrijednost2);
                    break;
                case ("Tsv"):
                    AvtSetUp(vrijednost1, vrijednost2);
                    break;
            }
            OdgovorArray = listaOdgovora.StvoriListuOdgovora(VratiModel());
            return VratiModel();
        }

        private void VatSetUp(double vrijednost1, double vrijednost2)
        {
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.Akceleracija;
            FizVelRjesenje = FizikalneVeličine.Vrijeme;
            Vrijednost1 = vrijednost1;
            Vrijednost2 = vrijednost2;
            VrijednostRješenje = Formule.VatFormula(Vrijednost1, Vrijednost2);
            MJ1 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel1).Value;
            MJ2 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel2).Value;
            MJRješenje = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVelRjesenje).Value;
            FormulaImage = BibliotekaSlika.VatFormulaImage;
        }

        private void TvaSetUp(double vrijednost1, double vrijednost2)
        {
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.Akceleracija;
            FizVelRjesenje = FizikalneVeličine.Vrijeme;
            Vrijednost1 = vrijednost1;
            Vrijednost2 = vrijednost2;
            VrijednostRješenje = Formule.TvaFormula(Vrijednost1, Vrijednost2);
            MJ1 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel1).Value;
            MJ2 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel2).Value;
            MJRješenje = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVelRjesenje).Value;
            FormulaImage = BibliotekaSlika.TvaFormulaImage;
        }

        private void AvtSetUp(double vrijednost1, double vrijednost2)
        {
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Akceleracija;
            Vrijednost1 = vrijednost1;
            Vrijednost2 = vrijednost2;
            VrijednostRješenje = Formule.AvtFormula(Vrijednost1, Vrijednost2);
            MJ1 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel1).Value;
            MJ2 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel2).Value;
            MJRješenje = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVelRjesenje).Value;
            FormulaImage = BibliotekaSlika.AvtFormulaImage;
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

