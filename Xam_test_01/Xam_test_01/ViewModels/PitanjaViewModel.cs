using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xam_test_01.Services;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01.ViewModel
{
    public class PitanjaViewModel : INotifyPropertyChanged
    {
        Formula formula = new Formula();
        private readonly OdabirGranaPitanja odabirGranaPitanja = new OdabirGranaPitanja();

        public PitanjaViewModel(string naziv, int level)
        {
            PitanjeCollection = new ObservableCollection<Pitanje>();
            OdgovorCollection = new ObservableCollection<Pitanje>();
            ObavijestKorisnikuCollection = new ObservableCollection<Pitanje>();
            MjernaJedinicaOdgovoraCollection = new ObservableCollection<Pitanje>();

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

            ProvjeriOdgovorCommand = new Command( async () =>
            {
                int rezultat;
                ConvertToDouble();
                if (MinVrijednostRješnja <= OdgovorKorisnikaDouble && OdgovorKorisnikaDouble <= MaxVrijednostRješenja)
                {
                    var obavjest = new Pitanje
                    {
                        ObavjestNakonOdgovora = "Točno",
                        BojaPozdaineOdgovora = Color.LightGreen
                    };
                    ObavijestKorisnikuCollection.Add(obavjest);
                    rezultat = 1;
                }
                else
                {
                    var obavjest = new Pitanje
                    {
                        ObavjestNakonOdgovora = "Netočno",
                        BojaPozdaineOdgovora = Color.LightPink
                    };
                    ObavijestKorisnikuCollection.Add(obavjest);
                    rezultat = 0;
                }
                IsEnabledProvjeriOdgovor = false;
                IsEnabledRiješenje = true;
                await DataBaseService.InsertInto(naziv, rezultat, level);
            });

            PrikaziOdgovorCommand = new Command<string>(async param =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new PrikazRjesenjaView(param, odabirGranaPitanja.OdgovorArray));
                IsEnabledProvjeriOdgovor = false;
            });
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

        bool isVisible;

        public bool IsVisible
        {
            get => isVisible;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Pitanje> OdgovorCollection { get; }
        public ObservableCollection<Pitanje> PitanjeCollection { get; }
        public ObservableCollection<Pitanje> ObavijestKorisnikuCollection { get; }
        public ObservableCollection<Pitanje> MjernaJedinicaOdgovoraCollection { get; }
        public ICommand GenerirajPitanjeCommand { get; }
        public ICommand PrikaziOdgovorCommand { get; }
        public ICommand ProvjeriOdgovorCommand { get; }
    }
}
