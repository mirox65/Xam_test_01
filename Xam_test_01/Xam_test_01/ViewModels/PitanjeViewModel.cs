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
    public class PitanjeViewModel : INotifyPropertyChanged
    {
        private readonly OdabirGranaPitanja odabirGranaPitanja = new OdabirGranaPitanja();

        public PitanjeViewModel(string naziv)
        {
            PitanjeCollection = new ObservableCollection<PitanjeModel>();
            OdgovorCollection = new ObservableCollection<PitanjeModel>();
            ObavijestKorisnikuCollection = new ObservableCollection<PitanjeModel>();
            MjernaJedinicaOdgovoraCollection = new ObservableCollection<PitanjeModel>();

            GenerirajPitanjeCommand = new Command<string>(param =>
            {
                PitanjeCollection.Clear();
                OdgovorCollection.Clear();
                ObavijestKorisnikuCollection.Clear();
                MjernaJedinicaOdgovoraCollection.Clear();
                IsVisible = true;
                OdgovorKorisnika = string.Empty;
                IsEnabledRiješenje = false;

                GenPitanje = odabirGranaPitanja.GeneriranjePitanja(param);


                var pitanje = new PitanjeModel
                {
                    Pitanje = GenPitanje.Pitanje
                };
                PitanjeCollection.Add(pitanje);

                var mjernaJedinica = new PitanjeModel
                {
                    MJRješenje = $"Unesi odgovor u {GenPitanje.MJRješenje}"
                };
                MjernaJedinicaOdgovoraCollection.Add(mjernaJedinica);

                MinVrijednostRješnja = GenPitanje.MinVrijednostRješenja;
                MaxVrijednostRješenja = GenPitanje.MaxVrijednostRješenja;
                IsEnabledProvjeriOdgovor = true;
            });

            ProvjeriOdgovorCommand = new Command(async () =>
            {
                ConvertToDouble();
                int rezultat;

                if (MinVrijednostRješnja <= OdgovorKorisnikaDouble && OdgovorKorisnikaDouble <= MaxVrijednostRješenja)
                {
                    var obavjest = new PitanjeModel
                    {
                        ObavjestNakonOdgovora = "Točno",
                        BojaPozdaineOdgovora = Color.LightGreen
                    };
                    ObavijestKorisnikuCollection.Add(obavjest);
                    rezultat = 1;
                }
                else
                {
                    var obavjest = new PitanjeModel
                    {
                        ObavjestNakonOdgovora = "Netočno",
                        BojaPozdaineOdgovora = Color.LightPink
                    };
                    ObavijestKorisnikuCollection.Add(obavjest);
                    rezultat = 0;
                }
                IsEnabledProvjeriOdgovor = false;
                IsEnabledRiješenje = true;
                await DataBaseService.InsertInto(naziv, rezultat, GenPitanje.Level);
            });

            PrikaziOdgovorCommand = new Command<string>(async param =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new PrikazRjesenjaView(param, GenPitanje.OdgovorArray, GenPitanje.FormulaImage));
                IsEnabledProvjeriOdgovor = false;
            });

            NapredakCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new NapredakView(naziv));
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

        private double maxVrijednostRješenja;

        public double MaxVrijednostRješenja
        {
            get { return maxVrijednostRješenja; }
            set { maxVrijednostRješenja = value; }
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

        public ObservableCollection<PitanjeModel> OdgovorCollection { get; }
        public ObservableCollection<PitanjeModel> PitanjeCollection { get; }
        public ObservableCollection<PitanjeModel> ObavijestKorisnikuCollection { get; }
        public ObservableCollection<PitanjeModel> MjernaJedinicaOdgovoraCollection { get; }
        public ICommand GenerirajPitanjeCommand { get; }
        public ICommand PrikaziOdgovorCommand { get; }
        public ICommand ProvjeriOdgovorCommand { get; }
        public ICommand NapredakCommand { get; }
        public PitanjeModel GenPitanje { get; private set; }
    }
}
