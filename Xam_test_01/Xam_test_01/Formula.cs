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
            IzracunVremena(Brzina, Akceleracija);
            PrvaNepoznanica = $"v = { Brzina } m/s";
            DrugaNepoznanica = $"a = { Akceleracija } m/s2";
            Odgovor = $"t = { Math.Round(Vrijeme, 2) } s";
        }

        private void IzracunVremena(double brzina, double akceleracija)
        {
            Vrijeme = brzina / akceleracija;
        }

        private void PitanjeBrzina()
        {
            Pitanje = $"Kojom se brzinom tijelo kreće, ako je akceleracija bila { Akceleracija } m/s2 i tralajala je { Vrijeme } s?";
            IzracunBrzine(Akceleracija, Vrijeme);
            PrvaNepoznanica = $"a = { Akceleracija } m/s2";
            DrugaNepoznanica = $"t = { Vrijeme } s";
            Odgovor = $"v = { Math.Round(Brzina, 2) } m/s";
        }

        private void IzracunBrzine(double akceleracija, double vrijeme)
        {
            Brzina = akceleracija * vrijeme;
        }

        private void PitanjeAkceleracija()
        {
            Pitanje = $"U vremenskom intervalu { Vrijeme } s tijelu se poveča brzina za { Brzina } m/s. Koliko je akceleracija tijela?";
            IzracunAkceleracije(Brzina, Vrijeme);
            PrvaNepoznanica = $"v = { Brzina } m/s";
            DrugaNepoznanica = $"t = { Vrijeme } s";
            Odgovor = $"a = { Math.Round(Akceleracija, 2)} m/s2";
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
    }
}
