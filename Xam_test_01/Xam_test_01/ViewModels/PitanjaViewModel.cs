using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xam_test_01.Models;
using Xamarin.Forms;

namespace Xam_test_01.Views
{
    public class PitanjaViewModel : INotifyPropertyChanged
    {
        Formula formula = new Formula();

        public PitanjaViewModel()
        {
            PitanjeCollection = new ObservableCollection<Pitanje>();
            OdgovorCollection = new ObservableCollection<Pitanje>();

            GenerirajPitanjeCommand = new Command(() =>
            {
                PitanjeCollection.Clear();
                OdgovorCollection.Clear();
                formula.GeneriranjePitanja();

                var pitanje = new Pitanje
                {
                    PrikaziGeneriranoPitanje = formula.Pitanje
                };

                PitanjeCollection.Add(pitanje);
                Vidljivo = true;
            });

            PrikaziOdgovorCommand = new Command(() =>
            {
                foreach (var element in formula.OdgovorArray)
                {
                    var odgovor = new Pitanje
                    {
                        PrikaziOdgovorNaPitanje = element.ToString()                        
                    };
                    OdgovorCollection.Add(odgovor);
                }                
                Vidljivo = false;
            });
        }

        string labelOdgovor;

        public string LabelOdgovor
        {
            get => labelOdgovor;
            set
            {
                labelOdgovor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(LabelOdgovor));
            }
        }

        string lablePitanja;

        public event PropertyChangedEventHandler PropertyChanged;

        public string LablePitanja
        {
            get => lablePitanja;
            set
            {
                lablePitanja = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(LablePitanja));
            }
        }

        bool vidljivo;

        public bool Vidljivo
        {
            get => vidljivo;
            set
            {
                vidljivo = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Pitanje> OdgovorCollection { get; }
        public ObservableCollection<Pitanje> PitanjeCollection { get; }
        public Command GenerirajPitanjeCommand { get; }
        public Command PrikaziOdgovorCommand { get; }

    }
}
