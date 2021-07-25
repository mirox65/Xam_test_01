using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xamarin.Forms;

namespace Xam_test_01.Views
{
    public class PitanjaViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// ViewModel pomoćna klasa View-a pitanje ovdje se odrađuje sva poslovna logika. Podižu se komande i sav kod koji dolazi sa View.
        /// ViewModel priprema i vraća obrađene podatke View-u u koje se prikazuju elementi korisniku.
        /// Najbitiniji property je commandproperty koji se nalazi u navigacijskom gumbu, te po njegovoj vrijendosti se dalje određuje koja će se tema koristit.
        /// </summary>
        /// 

        // Instanciranje klase odabirGranePitanja koja se poziva i priedaje se string s temom pitanja koju će popratne klase vratiti korisniku kao pitanje.
        private readonly OdabirGranaPitanja odabirGranaPitanja = new OdabirGranaPitanja();

        public PitanjaViewModel()
        {
            // Instanciranje kolekcija u kojima će se spremati vrijednosti generiranih pitanja i odgovora. Ova kolekcija se nadgleda te po promjeni vrijendosti ažurira.
            PitanjeCollection = new ObservableCollection<Pitanje>();
            OdgovorCollection = new ObservableCollection<Pitanje>();
            ObavijestKorisnikuCollection = new ObservableCollection<Pitanje>();
            MjernaJedinicaOdgovoraCollection = new ObservableCollection<Pitanje>();


            // Komanda koja se poziva pritiskom na navigacijski gumb Novo pitanje
            // Gumb prosljeđuje parametar naziv teme kao string koji se koristi prilokom generiranja pitanja u istomenoj klasi
            GenerirajPitanjeCommand = new Command<string>(param =>
                {
                    PitanjeCollection.Clear();
                    OdgovorCollection.Clear();
                    ObavijestKorisnikuCollection.Clear();
                    MjernaJedinicaOdgovoraCollection.Clear();
                    IsVisible = true;
                    OdgovorKorisnika = string.Empty;
                    IsEnabledRiješenje = false;
                    odabirGranaPitanja.GeneriranjePitanja(param);

                    var pitanje = new Pitanje
                    {
                        PrikaziGeneriranoPitanje = odabirGranaPitanja.Pitanje
                    };
                    PitanjeCollection.Add(pitanje);
                    var mjernaJedinica = new Pitanje
                    {
                        MjernaJedinicaOdgovora = $"Unesi odgovor u {odabirGranaPitanja.MjernaJedinicaOdgvora}"
                    };
                    MinVrijednostRješnja = odabirGranaPitanja.MinVrijednostRješenja;
                    MaxVrijednostRješenja = odabirGranaPitanja.MaxVrijednostRješenja;
                    MjernaJedinicaOdgovoraCollection.Add(mjernaJedinica);
                    IsEnabledProvjeriOdgovor = true;
                });

            ProvjeriOdgovorCommand = new Command(() =>
            {
                ConvertToDouble();
                if (MinVrijednostRješnja <= OdgovorKorisnikaDouble && OdgovorKorisnikaDouble <= MaxVrijednostRješenja)
                {
                    var obavjest = new Pitanje
                    {
                        ObavjestNakonOdgovora = "Točno"
                    };
                    ObavijestKorisnikuCollection.Add(obavjest);
                }
                else
                {
                    var obavjest = new Pitanje
                    {
                        ObavjestNakonOdgovora = "Netočno"
                    };
                    ObavijestKorisnikuCollection.Add(obavjest);
                }
                IsEnabledProvjeriOdgovor = false;
                IsEnabledRiješenje = true;
            });


            // Komanda koja se poziva pritiskom na gumb prikaži odgovor te time prikazuje točno rješenje korisniku.
            // I ovoj metodi se određuje je li gumb vidljiv korisnik ili ne.
            PrikaziOdgovorCommand = new Command(() =>
            {
                foreach (var element in odabirGranaPitanja.OdgovorArray)
                {
                    var odgovor = new Pitanje
                    {
                        PrikaziOdgovorNaPitanje = element.ToString()
                    };
                    OdgovorCollection.Add(odgovor);
                }
                IsEnabledProvjeriOdgovor = false;
            });
        }

        // Full property za label odgovor koji se generiraju u samam View-u.
        private string labelOdgovor;

        public string LabelOdgovor
        {
            get => labelOdgovor;
            set
            {
                labelOdgovor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(LabelOdgovor));
            }
        }

        // Full properti za label pitanje koji se generira u samm View-u
        private string lablePitanja;

        public string LablePitanja
        {
            get => lablePitanja;
            set
            {
                lablePitanja = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(LablePitanja));
            }
        }

        // Full property za odogovr korsnika. Unosom vrijednosti na View-u vrijednost property-a se mijenja te se na pritisak gumba provjeri rješenje uspoređuje sa sistemskim rješenjem.
        private string odgovorKorisnika;

        public string OdgovorKorisnika
        {
            get => odgovorKorisnika;
            set
            {
                odgovorKorisnika = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(OdgovorKorisnika));
            }
        }

        public double OdgovorKorisnikaDouble { get; set; }

        private void ConvertToDouble()
        {
            if (string.IsNullOrWhiteSpace(OdgovorKorisnika))
                return;
            OdgovorKorisnikaDouble = Convert.ToDouble(OdgovorKorisnika);
        }

        private double minVrijednostRješenja;

        public double MinVrijednostRješnja
        {
            get { return minVrijednostRješenja; }
            set { minVrijednostRješenja = value; }
        }

        private double maxVrijesnotRješenja;

        public double MaxVrijednostRješenja
        {
            get { return maxVrijesnotRješenja; }
            set { maxVrijesnotRješenja = value; }
        }


        private string obavjestNakonOdgovora;

        public string ObavjestNakonOdgovora
        {
            get => obavjestNakonOdgovora;
            set
            {
                obavjestNakonOdgovora = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ObavjestNakonOdgovora));
            }
        }


        // Full Boolean property koji se postavlja na istinto ukoliko element treba biti prikazan korsniku.
        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set 
            { 
                isVisible = value;
                OnPropertyChanged();
            }
        }


        private bool isEnabledProvjeriOdgovor;

        public bool IsEnabledProvjeriOdgovor
        {
            get => isEnabledProvjeriOdgovor;
            set
            {
                isEnabledProvjeriOdgovor = value;
                OnPropertyChanged();
            }
        }

        private bool isEnabledRiješenje;

        public bool IsEnabledRiješenje
        {
            get { return isEnabledRiješenje; }
            set 
            { 
                isEnabledRiješenje = value;
                OnPropertyChanged();
            }
        }


        // Property promjena vrijednosti koji se dobije kroz interfejs koji je vezan za klasu.

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Preko ovih paprametara View dolazi do vrijednosti komandi i kolekcija koje prikazuje korisniku.
        public ObservableCollection<Pitanje> OdgovorCollection { get; }
        public ObservableCollection<Pitanje> PitanjeCollection { get; }
        public ObservableCollection<Pitanje> ObavijestKorisnikuCollection { get; }
        public ObservableCollection<Pitanje> MjernaJedinicaOdgovoraCollection { get; }
        public ICommand GenerirajPitanjeCommand { get; }
        public ICommand PrikaziOdgovorCommand { get; }
        public ICommand ProvjeriOdgovorCommand { get; }

    }
}
