using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Interfaces;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;

namespace Xam_test_01.Grane.Mehanika.Kinematika
{
    public class JednolikoKruznoGibanje : IJednolikoKurznoGibanje
    {
        public string Akceleracija => FizikalneVeličine.Akceleracija;

        public string Brzina => FizikalneVeličine.Brzina;

        public string BrojOkretaja => FizikalneVeličine.BrojOkretaja;

        public string Polumjer => FizikalneVeličine.Polumjer;

        public string Pi => FizikalneVeličine.Pi;

        public string Dijametar => FizikalneVeličine.Dijametar;

        public string KutnaBrzina => FizikalneVeličine.KutnaBrzina;

        public string Kut => FizikalneVeličine.Kut;

        public string VrijemePeriod => FizikalneVeličine.VrijemePeriod;

        public string Frekvencija => FizikalneVeličine.Frekvencija;


        public IKinematikaTijeloModel Tijelo { get; set; }


        public PitanjeModel GeneriranjePitanja(int levelToUse)
        {
            return new PitanjeModel
            {
                Pitanje = $"Ovo je Kruzno pitanje sa znakom {Pi} i kutom {Kut} i kutnom brzinom {KutnaBrzina}",
                VrijednostRješenja = 4
            };
        }
    }
}
