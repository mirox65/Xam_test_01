using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Models
{
    public class JednolikoUbrzanoPitanjeModel
    {
        private readonly RječnikFizikalnihVeličinaMjernihJedinica dicVrijednosti = new RječnikFizikalnihVeličinaMjernihJedinica();
        private readonly ListaOdgovora listaOdgovora = new ListaOdgovora();

        public string FizVel1 { get; set; }
        public string FizVel2 { get; set; }
        public string FizVel3 { get; private set; }
        public string FizVelRjesenje { get; set; }
        public double Vrijednost1 { get; set; }
        public double Vrijednost2 { get; set; }
        public double Vrijednost3 { get; private set; }
        public double VrijednostRješenje { get; set; }
        public string MJ1 { get; set; }
        public string MJ2 { get; set; }
        public string MJ3 { get; private set; }
        public string MJRješenje { get; set; }
        public string FormulaImage { get; set; }
        public ArrayList OdgovorArray { get; set; }
        public Dictionary<string, string> DicVrijednosti { get; set; }

        public PitanjeModel OdabirMetode(string param, IUbrzanoTijeloModel tijelo)
        {
            DicVrijednosti = dicVrijednosti.FzikalneMjerneJediniceRiječnik(tijelo.VeličinaMjerneJedinice);
            switch (param)
            {
                case ("Avv0s"):
                    Avv0sSetUp(param, tijelo);
                    break;
                case ("Avv0t"):
                    Avv0tSetUp(param, tijelo);
                    break;
                case ("Sv0vt"):
                    Sv0vtSetUp(param, tijelo);
                    break;
                case ("Svv0a"):
                    Svv0aSetUp(param, tijelo);
                    break;
            }
            OdgovorArray = listaOdgovora.ListaOdgvoraTriVarijable(VratiModel());
            return VratiModel();
        }

        private void Svv0aSetUp(string param, IUbrzanoTijeloModel tijelo)
        {
            // stavljamo vrijednost VNula na nulu. jer u početnom trenutku miruje
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.VNulaBrzina;
            FizVel3 = FizikalneVeličine.Akceleracija;
            FizVelRjesenje = FizikalneVeličine.Put;

            // ako je brzina tijela u kilometrima akceleracija je u metrima i time sve vrijednosti spuštamo na metre
            if (tijelo.VeličinaMjerneJedinice == "km, s")
            {
                Vrijednost1 = Math.Round(tijelo.BrzinaVrijednost/3.6, 2);
                Vrijednost2 = 0;
                Vrijednost3 = tijelo.AkceleracijaVrijednost;
                VrijednostRješenje = Formule.Svv0aFormula(Vrijednost1, Vrijednost2, Vrijednost3);
                DicVrijednosti = dicVrijednosti.FzikalneMjerneJediniceRiječnik("m, s");
            }
            else
            {
                Vrijednost1 = tijelo.BrzinaVrijednost;
                Vrijednost2 = 0;
                Vrijednost3 = tijelo.AkceleracijaVrijednost;
                VrijednostRješenje = Formule.Svv0aFormula(Vrijednost1, Vrijednost2, Vrijednost3);
            }

            MJ1 = dicVrijednosti.NazivMJ(FizVel1);
            MJ2 = dicVrijednosti.NazivMJ(FizVel2);
            MJ3 = dicVrijednosti.NazivMJ(FizVel3);
            MJRješenje = dicVrijednosti.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }

        private void Avv0sSetUp(string param, IUbrzanoTijeloModel tijelo)
        {
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.VNulaBrzina;
            FizVel3 = FizikalneVeličine.Put;
            FizVelRjesenje = FizikalneVeličine.Akceleracija;
            if (tijelo.VeličinaMjerneJedinice == "km, s")
            {
                Vrijednost1 = Math.Round(tijelo.BrzinaVrijednost/3.6,2);
                Vrijednost2 = Math.Round(tijelo.VNulaBrzinaVrijednost/3.6,2);
                Vrijednost3 = Math.Round(tijelo.PutVrijednost,2);
                VrijednostRješenje = Formule.Avv0sFormula(Vrijednost1, Vrijednost2, Vrijednost3);
                DicVrijednosti = dicVrijednosti.FzikalneMjerneJediniceRiječnik("m, s");
            }
            else
            {
                Vrijednost1 = tijelo.BrzinaVrijednost;
                Vrijednost2 = tijelo.VNulaBrzinaVrijednost;
                Vrijednost3 = tijelo.PutVrijednost;
                VrijednostRješenje = Formule.Avv0sFormula(Vrijednost1, Vrijednost2, Vrijednost3);
            }
            MJ1 = dicVrijednosti.NazivMJ(FizVel1);
            MJ2 = dicVrijednosti.NazivMJ(FizVel2);
            MJ3 = dicVrijednosti.NazivMJ(FizVel3);
            MJRješenje = dicVrijednosti.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }

        private void Avv0tSetUp(string param, IUbrzanoTijeloModel tijelo)
        {
            FizVel1 = FizikalneVeličine.Brzina;
            FizVel2 = FizikalneVeličine.VNulaBrzina;
            FizVel3 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Akceleracija;
            if (tijelo.VeličinaMjerneJedinice == "km, s")
            {
                Vrijednost1 = Math.Round(tijelo.BrzinaVrijednost / 3.6, 2);
                Vrijednost2 = Math.Round(tijelo.VNulaBrzinaVrijednost / 3.6,2);
                Vrijednost3 = Math.Round(tijelo.VrijemeVrijednost,2);
                VrijednostRješenje = Formule.Avv0tFormula(Vrijednost1, Vrijednost2, Vrijednost3);
                DicVrijednosti = dicVrijednosti.FzikalneMjerneJediniceRiječnik("m, s");
            }
            else
            {
                Vrijednost1 = tijelo.BrzinaVrijednost;
                Vrijednost2 = tijelo.VNulaBrzinaVrijednost;
                Vrijednost3 = tijelo.VrijemeVrijednost;
                VrijednostRješenje = Formule.Avv0tFormula(Vrijednost1, Vrijednost2, Vrijednost3);
            }
            MJ1 = dicVrijednosti.NazivMJ(FizVel1);
            MJ2 = dicVrijednosti.NazivMJ(FizVel2);
            MJ3 = dicVrijednosti.NazivMJ(FizVel3);
            MJRješenje = dicVrijednosti.NazivMJ(FizVelRjesenje);
            FormulaImage = RječnikSlika.ImageSource(param);
        }

        private void Sv0vtSetUp(string param, IUbrzanoTijeloModel tijelo)
        {
            FizVel1 = FizikalneVeličine.VNulaBrzina;
            FizVel2 = FizikalneVeličine.Brzina;
            FizVel3 = FizikalneVeličine.Vrijeme;
            FizVelRjesenje = FizikalneVeličine.Put;

            if (tijelo.VeličinaMjerneJedinice == "km, s")
            {
                Vrijednost1 = 0;
                Vrijednost2 = Math.Round(tijelo.BrzinaVrijednost / 3.6, 2);
                Vrijednost3 = tijelo.VrijemeVrijednost;
                VrijednostRješenje = Formule.Sv0vtFormula(Vrijednost1, Vrijednost2, Vrijednost3);
                DicVrijednosti = dicVrijednosti.FzikalneMjerneJediniceRiječnik("m, s");
            }
            else
            {
                Vrijednost1 = 0;
                Vrijednost2 = tijelo.BrzinaVrijednost;
                Vrijednost3 = tijelo.VrijemeVrijednost;
                VrijednostRješenje = Formule.Sv0vtFormula(Vrijednost1, Vrijednost2, Vrijednost3);
                DicVrijednosti = dicVrijednosti.FzikalneMjerneJediniceRiječnik("m, s");
            }

            MJ1 = dicVrijednosti.NazivMJ(FizVel1);
            MJ2 = dicVrijednosti.NazivMJ(FizVel2);
            MJ3 = dicVrijednosti.NazivMJ(FizVel3);
            MJRješenje = dicVrijednosti.NazivMJ(FizVelRjesenje);

            FormulaImage = RječnikSlika.ImageSource(param);
        }

        private PitanjeModel VratiModel() => new PitanjeModel
        {
            FizVel1 = FizVel1,
            FizVel2 = FizVel2,
            FizVel3= FizVel3,
            FizVelRjesenja = FizVelRjesenje,
            Vrijednost1 = Vrijednost1,
            Vrijednost2 = Vrijednost2,
            Vrijednost3 = Vrijednost3,
            VrijednostRješenja = VrijednostRješenje,
            MJ1 = MJ1,
            MJ2 = MJ2,
            MJ3 = MJ3,
            MJRješenje = MJRješenje,
            FormulaImage = FormulaImage,
            OdgovorArray = OdgovorArray,
        };
    }
}

