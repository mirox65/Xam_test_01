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

            Assert.AreEqual("s", prvaFizVeličina);
            Assert.AreEqual("v", drugaFizVeličina);
            Assert.AreEqual("t", fizVeličinaRješenja);
            Assert.AreEqual("TsvFormula.PNG", formulaImageSource);
            Assert.AreEqual("m", prvaMJ);
            Assert.AreEqual("m/s", drugaMJ);
            Assert.AreEqual("s", rješenjeMJ);
            Assert.AreEqual(4, brojElemenataPolja);
        }
    }
}
