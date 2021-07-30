using System.Windows.Input;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class KorakViewModel
    {
        public KorakViewModel()
        {
            KinematikaCommand = new Command<string>(async param =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new KorakFormuleView(param));
            });

        }

        public ICommand KinematikaCommand { get; }
        public ICommand DinamikaCommand { get; }
    }
}