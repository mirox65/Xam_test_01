using System.Windows.Input;
using Xam_test_01.Views;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class TemeViewModel
    {
        public TemeViewModel()
        {
            OdabirGraneFizikeCommand = new Command<string>(async param =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new PitanjeView(param));
            });
        }

        public ICommand OdabirGraneFizikeCommand { get; }
    }
}
