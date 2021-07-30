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

    public static class Vrijdnosti
    {
        public static ArrayList SvtPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Brzina, FizikalneVeličine.Vrijeme};
        public static ArrayList TsvPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Brzina, FizikalneVeličine.Put};
        public static ArrayList VstPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Put, FizikalneVeličine.Vrijeme};
        public static ArrayList AvtPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Brzina, FizikalneVeličine.Vrijeme};
        public static ArrayList VatPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Akceleracija, FizikalneVeličine.Vrijeme};
        public static ArrayList TvaPrazneVrijednosti { get; set; } = new ArrayList {FizikalneVeličine.Brzina, FizikalneVeličine.Akceleracija};
    }
}
