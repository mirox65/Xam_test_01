using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Xam_test_01.Pomocne
{
    public static class Formule
    {

        public static double SvtFormula(double brzina, double vrijeme)
        {
            return Math.Round(brzina * vrijeme, 2);
        }

        public static double TsvFormula(double put, double brzina)
        {
            return Math.Round(put / brzina, 2);
        }

        public static double VstFormula(double put, double vrijeme)
        {
            return Math.Round(put / vrijeme, 2);
        }

        public static double AvtFormula(double brzina, double vrijeme)
        {
            return Math.Round(brzina / vrijeme, 2);
        }

        public static double VatFormula(double akceleracija, double vrijeme)
        {
            return Math.Round(akceleracija * vrijeme, 2);
        }

        public static double TvaFormula(double brzina, double akceleracija)
        {
            return Math.Round(brzina / akceleracija, 2);
        }

        internal static object VstFormula(object putVrijednost, double vrijemeVrijednost)
        {
            throw new NotImplementedException();
        }
    }

    public class Vrijdnosti
    {
        public ArrayList SvtPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Brzina, MjerneJedinice.MetarSekunda, FizikalneVeličine.Vrijeme, MjerneJedinice.Sekunda};
        public ArrayList TsvPrazneVrijednosti { get; set; } = new ArrayList { FizikalneVeličine.Put, MjerneJedinice.Metar, FizikalneVeličine.Brzina, MjerneJedinice.MetarSekunda };
        public ArrayList VstPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Put, MjerneJedinice.Metar, FizikalneVeličine.Vrijeme, MjerneJedinice.Sekunda};
        public ArrayList AvtPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Brzina, MjerneJedinice.MetarSekunda, FizikalneVeličine.Vrijeme, MjerneJedinice.Sekunda};
        public ArrayList VatPrazneVrijednosti { get; set; } = new ArrayList { FizikalneVeličine.Akceleracija, MjerneJedinice.MetarSekundaNa2, FizikalneVeličine.Vrijeme, MjerneJedinice.Sekunda };
        public ArrayList TvaPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Brzina, MjerneJedinice.MetarSekunda, FizikalneVeličine.Akceleracija, MjerneJedinice.MetarSekundaNa2};

        public ArrayList PrazneVrijednosti(string param)
        {
            ArrayList ar = new ArrayList();
            switch (param)
            {
                case ("Svt"):
                    return SvtPrazneVrijednosti;
                case ("Tsv"):
                    return TsvPrazneVrijednosti;
                case ("Vst"):
                    return VstPrazneVrijednosti;
                case ("Avt"):
                    return AvtPrazneVrijednosti;
                case ("Vat"):
                    return VatPrazneVrijednosti;
                case ("Tva"):
                    return TvaPrazneVrijednosti;
            }
            return ar;
        }
    }
}
