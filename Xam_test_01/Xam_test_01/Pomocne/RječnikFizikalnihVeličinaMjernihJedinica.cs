using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xam_test_01.Pomocne
{
    public class RječnikFizikalnihVeličinaMjernihJedinica
    {
        public ArrayList SvtFizikalneVeličine { get; set; } = new ArrayList { FizikalneVeličine.Brzina, FizikalneVeličine.Vrijeme };
        public ArrayList TsvFizikalneVeličine { get; set; } = new ArrayList { FizikalneVeličine.Put, FizikalneVeličine.Brzina };
        public ArrayList VstFizikalneVeličine { get; set; } = new ArrayList { FizikalneVeličine.Put, FizikalneVeličine.Vrijeme };

        public Dictionary<string, string> DicFizVelMJ { get; private set; }

        public string NazivMJ(string fizVeličina)
        {
            return DicFizVelMJ.First(x => x.Key == fizVeličina).Value;
        }

        public Dictionary<string, string> FzikalneMjerneJediniceRiječnik(string param)
        {
            switch (param)
            {
                case "m, s":
                    return KinematikaOsnovneJedinice();
                case "km, h":
                    return KinematikaKiloJedinice();
                case "km, s":
                    return TijeloModelKiloJedinice();
            }
            return DicFizVelMJ;
        }

        private Dictionary<string, string> TijeloModelKiloJedinice() => DicFizVelMJ = new Dictionary<string, string>
        {
            { FizikalneVeličine.Put, MjerneJedinice.Metar },
            { FizikalneVeličine.Vrijeme, MjerneJedinice.Sekunda },
            { FizikalneVeličine.Brzina, MjerneJedinice.KilometarSat },
            { FizikalneVeličine.VNulaBrzina, MjerneJedinice.KilometarSat },
            { FizikalneVeličine.Akceleracija, MjerneJedinice.MetarSekundaNa2 }
        };

        private Dictionary<string, string> KinematikaKiloJedinice() => DicFizVelMJ = new Dictionary<string, string>
        {
            { FizikalneVeličine.Put, MjerneJedinice.Kilometar },
            { FizikalneVeličine.Vrijeme, MjerneJedinice.Sat },
            { FizikalneVeličine.Brzina, MjerneJedinice.KilometarSat },
            { FizikalneVeličine.VNulaBrzina, MjerneJedinice.KilometarSat },
            { FizikalneVeličine.Akceleracija, MjerneJedinice.MetarSekundaNa2 }
        };

        private Dictionary<string, string> KinematikaOsnovneJedinice() => DicFizVelMJ = new Dictionary<string, string>
        {

            { FizikalneVeličine.Put, MjerneJedinice.Metar },
            { FizikalneVeličine.Vrijeme, MjerneJedinice.Sekunda },
            { FizikalneVeličine.Brzina, MjerneJedinice.MetarSekunda },
            { FizikalneVeličine.Akceleracija, MjerneJedinice.MetarSekundaNa2 },
            { FizikalneVeličine.VNulaBrzina, MjerneJedinice.MetarSekunda },
            { FizikalneVeličine.BrojOkretaja, string.Empty },
            { FizikalneVeličine.Frekvencija, MjerneJedinice.Herz },
            { FizikalneVeličine.VrijemePeriod, MjerneJedinice.Sekunda },
            { FizikalneVeličine.KutnaBrzina, MjerneJedinice.RadSekunda },
            { FizikalneVeličine.Pi, string.Empty }

        };

        public ArrayList SetFizikalnihVeličina(string param)
        {
            var ar = new ArrayList();
            switch (param)
            {
                case ("Svt"):
                    return SvtFizikalneVeličine;
                case ("Tsv"):
                    return TsvFizikalneVeličine;
                case ("Vst"):
                    return VstFizikalneVeličine;
            }
            return ar;
        }
    }
}
