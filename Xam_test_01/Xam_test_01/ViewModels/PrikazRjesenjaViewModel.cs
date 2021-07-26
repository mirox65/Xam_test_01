using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xam_test_01.Models;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class PrikazRjesenjaViewModel
    {
        public PrikazRjesenjaViewModel(ArrayList odgovorArray)
        {

            OdgovorCollection = new ObservableCollection<Pitanje>();

            foreach (var element in odgovorArray)
            {
                var rjesenje = new Pitanje
                {
                    PrikaziOdgovorNaPitanje = element.ToString()
                };
                OdgovorCollection.Add(rjesenje);
            }

            NazadCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        public PrikazRjesenjaViewModel() { }

        public ObservableCollection<Pitanje> OdgovorCollection { get; }
        public ICommand NazadCommand { get; }
    }
}
