using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class JednolikoPravocrtnoModel
    {
        private readonly Vrijednosti vrijdnosti = new Vrijednosti();

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
        public Dictionary<string,string> RječnikVrijednosti { get; set; }

        public JednolikoPravocrtnoModel() { }

        private PitanjeModel VratiModel()
        {
            return new PitanjeModel
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

        public PitanjeModel OdabirMetode(string param, string vrijednost1, string vrijednost2, string mj)
        {
            RječnikVrijednosti = vrijdnosti.FzikalneMjerneJediniceRiječnik(mj);
            switch (param)
            {
                case ("Svt"):
                    SvtSetUp(vrijednost1, vrijednost2);
                    break;
                case ("Vst"):
                    VstSetUp(vrijednost1, vrijednost2);
                    break;
                case ("Tsv"):
                    TsvSetUp(vrijednost1, vrijednost2);
                    break;
            }
            return VratiModel();
        }

        private void TsvSetUp(string vrijednost1, string vrijednost2)
        {
            FizVel1 = FizikalneVeličine.Put;
            FizVel2 = FizikalneVeličine.Brzina;
            FizVelRjesenje = FizikalneVeličine.Vrijeme;
            Vrijednost1 = ConvertToDouble(vrijednost1);
            Vrijednost2 = ConvertToDouble(vrijednost2);
            VrijednostRješenje = Formule.TsvFormula(Vrijednost1, Vrijednost2);
            MJ1 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel1).Value;
            MJ2 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel2).Value;
            MJRješenje = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVelRjesenje).Value;
            FormulaImage = FormuleImageSource.TsvFormulaImage;
            OdgovorArray = ListaOdgovora();
        }

        private void VstSetUp(string vrijednost1, string vrijednost2)
        {

            FizVel1 = FizikalneVeličine.Put;
            FizVel2 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Brzina;
            Vrijednost1 = ConvertToDouble(vrijednost1);
            Vrijednost2 = ConvertToDouble(vrijednost2);
            VrijednostRješenje = Formule.VstFormula(Vrijednost1, Vrijednost2);
            MJ1 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel1).Value;
            MJ2 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel2).Value;
            MJRješenje = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVelRjesenje).Value;
            FormulaImage = FormuleImageSource.VstFormulaImage;
            OdgovorArray = ListaOdgovora();
        }

        public void SvtSetUp(string vrijednost1, string vrijednost2)
        {
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Put;
            Vrijednost1 = ConvertToDouble(vrijednost1);
            Vrijednost2 = ConvertToDouble(vrijednost2);
            VrijednostRješenje = Formule.SvtFormula(Vrijednost1, Vrijednost2);
            MJ1 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel1).Value;
            MJ2 = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVel2).Value;
            MJRješenje = RječnikVrijednosti.FirstOrDefault(x => x.Key == FizVelRjesenje).Value;
            FormulaImage = FormuleImageSource.SvtFormulaImage;
            OdgovorArray = ListaOdgovora();
        }

        public double ConvertToDouble(string unosKorisnika)
        {
            return Math.Round(Convert.ToDouble(unosKorisnika), 2);
        }

        private ArrayList ListaOdgovora()
        {
            return new ArrayList
            {
                PrvaVrijednost(),
                DrugaVrijednost(),
                StoRacunamo(),
                Odgovor()
            };
        }

        private string Odgovor()
        {
            return $"{ FizVelRjesenje } = { VrijednostRješenje } { MJRješenje }";
        }

        private string StoRacunamo()
        {
            return $"{ FizVelRjesenje } = ?";
        }

        private string PrvaVrijednost()
        {
            return $"{ FizVel1 } = { Vrijednost1 } { MJ1 }";
        }

        private string DrugaVrijednost()
        {
            return $"{ FizVel2 } = { Vrijednost2 } { MJ2 }";
        }
    }
}
