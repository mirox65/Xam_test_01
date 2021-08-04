using System;
using System.Collections;
using System.Collections.Generic;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class JednolikoPravocrtnoModel
    {
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

        public PitanjeModel OdabirMetode(string param, string vrijednost1, string vrijednost2)
        {
            var jpm = new PitanjeModel();
            switch (param)
            {
                case ("Svt"):
                    return SvtSetUp(vrijednost1, vrijednost2);
                case ("Vst"):
                    return VstSetUp(vrijednost1, vrijednost2);
                case ("Tsv"):
                    return TsvSetUp(vrijednost1, vrijednost2);
                default:
                    return jpm;
            }
        }

        private PitanjeModel TsvSetUp(string vrijednost1, string vrijednost2)
        {
            FizVel1 = FizikalneVeličine.Put;
            FizVel2 = FizikalneVeličine.Brzina;
            FizVelRjesenje = FizikalneVeličine.Vrijeme;
            Vrijednost1 = ConvertToDouble(vrijednost1);
            Vrijednost2 = ConvertToDouble(vrijednost2);
            VrijednostRješenje = Formule.TsvFormula(Vrijednost1, Vrijednost2);
            MJ1 = MjerneJedinice.Metar;
            MJ2 = MjerneJedinice.MetarSekunda;
            MJRješenje = MjerneJedinice.Sekunda;
            FormulaImage = FormuleImageSource.TsvFormulaImage;
            OdgovorArray = ListaOdgovora();

            return VratiModel();
        }

        private PitanjeModel VstSetUp(string vrijednost1, string vrijednost2)
        {

            FizVel1 = FizikalneVeličine.Put;
            FizVel2 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Brzina;
            Vrijednost1 = ConvertToDouble(vrijednost1);
            Vrijednost2 = ConvertToDouble(vrijednost2);
            VrijednostRješenje = Formule.VstFormula(Vrijednost1, Vrijednost2);
            MJ1 = MjerneJedinice.Metar;
            MJ2 = MjerneJedinice.Sekunda;
            MJRješenje = MjerneJedinice.Metar;
            FormulaImage = FormuleImageSource.VstFormulaImage;
            OdgovorArray = ListaOdgovora();

            return VratiModel();
        }

        public PitanjeModel SvtSetUp(string vrijednost1, string vrijednost2)
        {
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Put;
            Vrijednost1 = ConvertToDouble(vrijednost1);
            Vrijednost2 = ConvertToDouble(vrijednost2);
            VrijednostRješenje = Formule.SvtFormula(Vrijednost1, Vrijednost2);
            MJ1 = MjerneJedinice.MetarSekunda;
            MJ2 = MjerneJedinice.Sekunda;
            MJRješenje = MjerneJedinice.Metar;
            FormulaImage = FormuleImageSource.SvtFormulaImage;
            OdgovorArray = ListaOdgovora();

            return VratiModel();
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
