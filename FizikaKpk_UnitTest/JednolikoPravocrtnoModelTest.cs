using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;

namespace FizikaKpk_UnitTest
{
    [TestClass]
    public class JednolikoPravocrtnoModelTest
    {
        private readonly double brzina = 7.42;
        private readonly double vrijeme = 4.15;
        private readonly double put = 30.79;

        [TestMethod]
        public void TsvSetUp_VrijednostiModela_PovratModel()
        {
            var model = new JednolikoPravocrtnoModel();

            var pitanjeModel = model.OdabirMetode("Tsv", put.ToString(), brzina.ToString());
            var prvaFizVeličina = pitanjeModel.FizVel1;
            var drugaFizVeličina = pitanjeModel.FizVel2;
            var fizVeličinaRješenja = pitanjeModel.FizVelRjesenja;
            var formulaImageSource = pitanjeModel.FormulaImage;
            var prvaMJ = pitanjeModel.MJ1;
            var drugaMJ = pitanjeModel.MJ2;
            var rješenjeMJ = pitanjeModel.MJRješenje;
            var brojElemenataPolja = pitanjeModel.OdgovorArray.Count;
            var vrijednost1 = pitanjeModel.Vrijednost1;
            var vrijednost2 = pitanjeModel.Vrijednost2;
            var vrijednostRj = pitanjeModel.VrijednostRješenja;

            Assert.AreEqual("s", prvaFizVeličina);
            Assert.AreEqual("v", drugaFizVeličina);
            Assert.AreEqual("t", fizVeličinaRješenja);
            Assert.AreEqual("TsvFormula.PNG", formulaImageSource);
            Assert.AreEqual("m", prvaMJ);
            Assert.AreEqual("m/s", drugaMJ);
            Assert.AreEqual("s", rješenjeMJ);
            Assert.AreEqual(4, brojElemenataPolja);
            Assert.AreEqual(put, vrijednost1);
            Assert.AreEqual(brzina, vrijednost2);
            Assert.AreEqual(vrijeme, vrijednostRj);
        }

        [TestMethod]
        public void SvtSetUp_VrijednostModela_PovratModel()
        {
            var model = new JednolikoPravocrtnoModel();

            var pitanjeModel = model.OdabirMetode("Svt", brzina.ToString(), vrijeme.ToString());
            var fizVel1 = pitanjeModel.FizVel1;
            var fizVel2 = pitanjeModel.FizVel2;
            var fizVelRj = pitanjeModel.FizVelRjesenja;
            var formulaImageSource = pitanjeModel.FormulaImage;
            var mj1 = pitanjeModel.MJ1;
            var mj2 = pitanjeModel.MJ2;
            var mjRj = pitanjeModel.MJRješenje;
            var brojElemenataPolja = pitanjeModel.OdgovorArray.Count;
            var vrijednost1 = pitanjeModel.Vrijednost1;
            var vrijednost2 = pitanjeModel.Vrijednost2;
            var vrijednostRj = pitanjeModel.VrijednostRješenja;

            Assert.AreEqual("v", fizVel1);
            Assert.AreEqual("t", fizVel2);
            Assert.AreEqual("s", fizVelRj);
            Assert.AreEqual("SvtFormula.PNG", formulaImageSource);
            Assert.AreEqual("m/s", mj1);
            Assert.AreEqual("s", mj2);
            Assert.AreEqual("m", mjRj);
            Assert.AreEqual(4, brojElemenataPolja);
            Assert.AreEqual(brzina, vrijednost1);
            Assert.AreEqual(vrijeme, vrijednost2);
            Assert.AreEqual(put, vrijednostRj);
        }

        [TestMethod]
        public void VstSetUp_VrijednostiModela_PovratModel()
        {
            var model = new JednolikoPravocrtnoModel();

            var pitanjeModel = model.OdabirMetode("Vst", put.ToString(), vrijeme.ToString());
            var fizVel1 = pitanjeModel.FizVel1;
            var fizVel2 = pitanjeModel.FizVel2;
            var fizVelRj = pitanjeModel.FizVelRjesenja;
            var formulaImageSource = pitanjeModel.FormulaImage;
            var mj1 = pitanjeModel.MJ1;
            var mj2 = pitanjeModel.MJ2;
            var mjRj = pitanjeModel.MJRješenje;
            var brojElemenataPolja = pitanjeModel.OdgovorArray.Count;
            var vrijednost1 = pitanjeModel.Vrijednost1;
            var vrijednost2 = pitanjeModel.Vrijednost2;
            var vrijednostRj = pitanjeModel.VrijednostRješenja;

            Assert.AreEqual("s", fizVel1);
            Assert.AreEqual("t", fizVel2);
            Assert.AreEqual("v", fizVelRj);
            Assert.AreEqual("VstFormula.PNG", formulaImageSource);
            Assert.AreEqual("m", mj1);
            Assert.AreEqual("s", mj2);
            Assert.AreEqual("m/s", mjRj);
            Assert.AreEqual(4, brojElemenataPolja);
            Assert.AreEqual(put, vrijednost1);
            Assert.AreEqual(vrijeme, vrijednost2);
            Assert.AreEqual(brzina, vrijednostRj);
        }
    }

}
