using System.ComponentModel;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class TipViewModel : INotifyPropertyChanged
    {

        public TipViewModel()
        {
            PitanjeCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new TemeView());
            });

            KorakCommand = new Command(() =>
            {
                //throw new NotImplementedException();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command PitanjeCommand { get; }

        public Command KorakCommand { get; }

    }

}
