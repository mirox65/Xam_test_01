using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Pomocne;

namespace FizikaKpk_UnitTest
{
    [TestClass]
    public class FormuleTests
    {
        private readonly double brzina = 7.42;
        private readonly double vrijeme = 4.15;
        private readonly double put = 30.79;

        [TestMethod]
        public void SvtFormula_Izračun_PovratDoubleVrijednost()
        {
            var rezultat = Formule.SvtFormula(brzina, vrijeme);

            Assert.AreEqual(put, rezultat);
        }

        [TestMethod]
        public void VstFormula_Izračun_PovratDoubleVrijednost()
        {
            var rezultat = Formule.VstFormula(put, vrijeme);

            Assert.AreEqual(brzina, rezultat);
        }

        [TestMethod]
        public void TsvFormula_Izračun_PovratDoubleVrijednost()
        {
            var rezultat = Formule.TsvFormula(put, brzina);

            Assert.AreEqual(vrijeme, rezultat);
        }
    }
}
