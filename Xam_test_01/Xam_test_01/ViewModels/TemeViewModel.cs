using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class TemeViewModel
    {
        public TemeViewModel()
        {
            TemeKinematikaCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new PitanjaView());
            });

            //TemeDinamikaCommand = new Command(async () =>
            //{
            //    await Application.Current.MainPage.Navigation.PushAsync(new Page());
            //});

        }

        public Command TemeKinematikaCommand { get; }
        public Command TemeDinamikaCommand { get; }

    }
}
