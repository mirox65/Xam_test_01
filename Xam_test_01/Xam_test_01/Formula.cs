using System;

namespace Xam_test_01
{
    public class Formula
    {
        public string Pitanje { get; internal set; }
        public double Akceleracija { get; set; }
        public double Brzina { get; set; }
        public double BrzinaNula { get; set; }
        public double Vrijeme { get; set; }
        public string PrvaNepoznanica { get; set; }
        public string DrugaNepoznanica { get; set; }
        public string TrecaNepoznanica { get; set; }
        public string Odgovor { get; set; }

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
            IzracunVremena();
            PrvaNepoznanica = $"v = { Brzina } m/s";
            DrugaNepoznanica = $"a = { Akceleracija } m/s2";
            Odgovor = $"t = { Vrijeme } s";
        }

        private void IzracunVremena()
        {
            Vrijeme = Brzina / Akceleracija;
        }

        private void PitanjeBrzina()
        {
            Pitanje = $"Kojom se brzinom tijelo kreće, ako je akceleracija bila { Akceleracija } m/s2 i tralajala je { Vrijeme } s?";
            IzracunBrzine();
            PrvaNepoznanica = $"a = { Akceleracija } m/s2";
            DrugaNepoznanica = $"t = { Vrijeme } s";
            Odgovor = $"v = { Brzina } m/s";
        }

        private void IzracunBrzine()
        {
            Brzina = Akceleracija * Vrijeme;
        }

        private void PitanjeAkceleracija()
        {
            Pitanje = $"U vremenskom intervalu { Vrijeme } s tijelu se poveča brzina za { Brzina } m/s. Koliko je akceleracija tijela?";
            IzracunAkceleracije();
            PrvaNepoznanica = $"v = { Brzina } m/s";
            DrugaNepoznanica = $"t = { Vrijeme } s";
            Odgovor = $"a = { Akceleracija } m/s2";
        }

        private void IzracunAkceleracije()
        {
            Akceleracija = Brzina / Vrijeme;
        }

        private void RandomBrojevi()
        {
            Brzina = random.Next(1, 10);
            Vrijeme = random.Next(1, 10);
            Akceleracija = random.Next(1, 10);
        }
    }
}
