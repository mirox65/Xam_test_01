using System;
using System.Collections;

namespace Xam_test_01
{
    public class Formula
    {
        public string Pitanje { get; set; }
        public double Akceleracija { get; set; }
        public double Brzina { get; set; }
        public double BrzinaNula { get; set; }
        public double Vrijeme { get; set; }
        public string StoRacunamo { get; set; }
        public string FormulaZaIspis { get; set; }
        public string PrvaNepoznanica { get; set; }
        public string DrugaNepoznanica { get; set; }
        public string TrecaNepoznanica { get; set; }
        public string Odgovor { get; set; }
        public ArrayList OdgovorArray { get; set; }

        readonly Random random = new Random();

        public void GeneriranjePitanja()
        {
            RandomBrojevi();

            int tema = random.Next(1, 4);
            switch (tema)
            {
                case 1:
                    PitanjeAkceleracija();
                    break;
                case 2:
                    PitanjeBrzina();
                    break;
                case 3:
                    PitanjeVrijeme();
                    break;
            }
        }

        private void PitanjeVrijeme()
        {
            Pitanje = $"Za koliko vremena je tijelo nešto pri brzini { Brzina } m/s ako je akcleracija iznosila { Akceleracija } m/s2?";
            IzracunVremena(Brzina, Akceleracija);
            StoRacunamo = "t=?";
            FormulaZaIspis = "t=v/a";
            PrvaNepoznanica = $"v = { Brzina } m/s";
            DrugaNepoznanica = $"a = { Akceleracija } m/s2";
            Odgovor = $"t = { Math.Round(Vrijeme, 2) } s";
            ArrayOdgovor(StoRacunamo, FormulaZaIspis, PrvaNepoznanica, DrugaNepoznanica, Odgovor);
        }

        private void IzracunVremena(double brzina, double akceleracija)
        {
            Vrijeme = brzina / akceleracija;
        }

        private void PitanjeBrzina()
        {
            Pitanje = $"Kojom se brzinom tijelo kreče, ako je akceleracija bila { Akceleracija } m/s2 i tralajala je { Vrijeme } s?";
            IzracunBrzine(Akceleracija, Vrijeme);
            StoRacunamo = "v=?";
            FormulaZaIspis = "v=a*t";
            PrvaNepoznanica = $"a = { Akceleracija } m/s2";
            DrugaNepoznanica = $"t = { Vrijeme } s";
            Odgovor = $"v = { Math.Round(Brzina, 2) } m/s";
            ArrayOdgovor(StoRacunamo, FormulaZaIspis, PrvaNepoznanica, DrugaNepoznanica, Odgovor);
        }

        private void IzracunBrzine(double akceleracija, double vrijeme)
        {
            Brzina = akceleracija * vrijeme;
        }

        private void PitanjeAkceleracija()
        {
            Pitanje = $"U vremenskom intervalu { Vrijeme } s tijelu se poveća brzina za { Brzina } m/s. Koliko je akceleracija tijela?";
            IzracunAkceleracije(Brzina, Vrijeme);
            StoRacunamo = "a=?";
            FormulaZaIspis = "a=v/t";
            PrvaNepoznanica = $"v = { Brzina } m/s";
            DrugaNepoznanica = $"t = { Vrijeme } s";
            Odgovor = $"a = { Math.Round(Akceleracija, 2)} m/s2";
            ArrayOdgovor(StoRacunamo, FormulaZaIspis, PrvaNepoznanica, DrugaNepoznanica, Odgovor);
        }

        private void IzracunAkceleracije(double brzina, double vrijeme)
        {
            Akceleracija = brzina / vrijeme;
        }

        private void RandomBrojevi()
        {
            Brzina = random.Next(1, 10);
            Vrijeme = random.Next(1, 10);
            Akceleracija = random.Next(1, 10);
        }

        private void ArrayOdgovor(string stoRacunamo, string formulaZaIspis, string prvaNep, string drugaNep, string odgovor)
        {
            var ar = new ArrayList();
            ar.Add(stoRacunamo);
            ar.Add(formulaZaIspis);
            ar.Add(prvaNep);
            ar.Add(drugaNep);
            ar.Add(odgovor);

            OdgovorArray = ar;
        }
    }
}
