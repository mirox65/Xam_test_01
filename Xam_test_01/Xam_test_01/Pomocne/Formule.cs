using System;
using System.Collections;
using System.Collections.Generic;

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

        public static double Sv0vtFormula(double vrijednost1, double vrijednost2, double vrijednost3)
        {
            return Math.Round(((vrijednost1 + vrijednost2) * vrijednost3) / 2, 2);
        }

        internal static double Svv0aFormula(double vrijednost1, double vrijednost2, double vrijednost3)
        {
            return Math.Round((Math.Pow(vrijednost1, 2) - Math.Pow(vrijednost2, 2)) / (2 * vrijednost3), 2);
        }

        internal static double Avv0sFormula(double vrijednost1, double vrijednost2, double vrijednost3)
        {
            return Math.Round((Math.Pow(vrijednost1, 2) - Math.Pow(vrijednost2, 2)) / (2 * vrijednost3), 2);
        }

        internal static double Avv0tFormula(double vrijednost1, double vrijednost2, double vrijednost3)
        {
            return Math.Round((vrijednost1 - vrijednost2) / vrijednost3, 2);
        }

        internal static double OmegaPiVTFormula(double pi, double vrijemePeriod)
        {
            return Math.Round(2*pi / vrijemePeriod, 2);
        }

        internal static double FntFormula(double brojOkretaja, double vrijeme)
        {
            return Math.Round(brojOkretaja / vrijeme, 2);
        }

        internal static double VTtnFormula(double vrijeme, double brojOkretaja)
        {
            return Math.Round(vrijeme / brojOkretaja, 2);
        }
    }
}
