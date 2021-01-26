using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xam_test_01
{
    public class PrvaStranicaViewModel
    {
        public Command SelectedVjezbajCommand { get; }

        public PrvaStranicaViewModel()
        {
            SelectedVjezbajCommand = new Command(async () =>
            {
                var drugaStranica = new DrugaStranica();

                await Application.Current.MainPage.Navigation.PushAsync(drugaStranica);

            });
        }
    }
}
