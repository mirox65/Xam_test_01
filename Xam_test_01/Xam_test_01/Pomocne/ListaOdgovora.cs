using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;

namespace Xam_test_01.Pomocne
{
    public class ListaOdgovora
    {
        public PitanjeModel PitanjeModel { get; set; }

        public ArrayList ListaOdgovoraDvijeVarijable(PitanjeModel pitanje)
        {
            PitanjeModel = pitanje;
            return new ArrayList
            {
                PrvaVrijednost(),
                DrugaVrijednost(),
                StoRacunamo(),
                Odgovor()
            };
        }

        internal ArrayList ListaOdgvoraTriVarijable(PitanjeModel pitanje)
        {
            PitanjeModel = pitanje;
            return new ArrayList
            {
                PrvaVrijednost(),
                DrugaVrijednost(),
                TrećaVrijednost(),
                StoRacunamo(),
                Odgovor()
            };
        }


        private string Odgovor()
        {
            return $"{ PitanjeModel.FizVelRjesenja } = { PitanjeModel.VrijednostRješenja } { PitanjeModel.MJRješenje }";
        }

        private string StoRacunamo()
        {
            return $"{ PitanjeModel.FizVelRjesenja } = ?";
        }

        private string PrvaVrijednost()
        {
            return $"{ PitanjeModel.FizVel1 } = { PitanjeModel.Vrijednost1 } { PitanjeModel.MJ1 }";
        }

        private string DrugaVrijednost()
        {
            return $"{ PitanjeModel.FizVel2 } = { PitanjeModel.Vrijednost2 } { PitanjeModel.MJ2 }";
        }
        
        private string TrećaVrijednost()
        {
            return $"{ PitanjeModel.FizVel3 } = { PitanjeModel.Vrijednost3 } { PitanjeModel.MJ3 }";
        }

    }
}
