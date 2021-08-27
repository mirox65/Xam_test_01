using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xam_test_01.Models;
using Xamarin.Forms;

namespace Xam_test_01.ViewModels
{
    public class PrikazRjesenjaViewModel
    {
        public PrikazRjesenjaViewModel(ArrayList odgovorArray, string imageSource)
        {

            OdgovorCollection = new ObservableCollection<PitanjeModel>();
            FormulaCollection = new ObservableCollection<PitanjeModel>();

            var formulaImage = new PitanjeModel
            {
                FormulaImage = imageSource
            };
            FormulaCollection.Add(formulaImage);

            foreach (var element in odgovorArray)
            {
                var rjesenje = new PitanjeModel
                {
                    Odgovor = element.ToString()
                };
                OdgovorCollection.Add(rjesenje);
            }

            NazadCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        //public PrikazRjesenjaViewModel() { }

        public ObservableCollection<PitanjeModel> OdgovorCollection { get; }
        public ObservableCollection<PitanjeModel> FormulaCollection { get; }
        public ICommand NazadCommand { get; }
    }
}
