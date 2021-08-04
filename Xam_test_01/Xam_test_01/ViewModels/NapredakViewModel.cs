using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xam_test_01.Services;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class NapredakViewModel : INotifyPropertyChanged
    {

        public NapredakViewModel(string grana)
        {
            var level = DataBaseService.SelectLevel(grana).Result;
            var totalAnsswers = DataBaseService.SelectCount(grana, level).Result;
            var correctAnswers = DataBaseService.SelectCorrectCount(grana, level).Result;
            var postotak = Math.Round((double)correctAnswers / totalAnsswers * 100);

            Razina = $"Razina {level} ";
            Ukupno = $"Rezulata {correctAnswers} / {totalAnsswers}";
            if(totalAnsswers == 0)
            {
                postotak = 0;
            }
            Postotak = $"Postotak: {postotak}%";

            NazadCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string razina;

        public string Razina
        {
            get => razina;
            set
            {
                razina = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Razina));
                OnPropertyChanged();
            }
        }

        private string ukupno;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Ukupno
        {
            get => ukupno;
            set
            {
                ukupno = value;
                OnPropertyChanged();
            }
        }

        private string tocno;

        public string Postotak
        {
            get => tocno;
            set
            {
                tocno = value;
                OnPropertyChanged();
            }
        }

        public ICommand NazadCommand { get; }
    }
}
