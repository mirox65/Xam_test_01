using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xam_test_01
{
    public class DrugaStranicaViewModel
    {
        public Command SelectedKinematika { get; }

        public DrugaStranicaViewModel()
        {
            SelectedKinematika = new Command(async () =>
            {
                var pageKinematika = new MainPage();

                await Application.Current.MainPage.Navigation.PushAsync(pageKinematika);
            });
        }
    }
}
