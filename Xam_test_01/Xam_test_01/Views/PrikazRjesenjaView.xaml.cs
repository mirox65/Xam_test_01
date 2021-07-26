using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xam_test_01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrikazRjesenjaView : ContentPage
    {
        private string param;
        private ArrayList odgovorArray;

        public PrikazRjesenjaView()
        {
            InitializeComponent();
        }

        public PrikazRjesenjaView(string param, ArrayList odgovorArray)
        {
            this.param = param;
            this.odgovorArray = odgovorArray;

            BindingContext = new PrikazRjesenjaViewModel(odgovorArray);
            Title = param;

            var zajednickiElementi = new ZajednickiElementiAplikacije();

            var collectionViewOdgovor = new CollectionView
            {
                ItemTemplate = new LableOdgovorTemplate()
            };
            collectionViewOdgovor.SetBinding(ItemsView.ItemsSourceProperty, nameof(PrikazRjesenjaViewModel.OdgovorCollection));

            var backButton = zajednickiElementi.PrimarniNavigacijskiButton("Nazad");
            backButton.SetBinding(Button.CommandProperty, nameof(PrikazRjesenjaViewModel.NazadCommand));

            var grid = new Grid
            {
                Margin = new Thickness(10, 10),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(70, GridUnitType.Absolute) }
                }
            };

            grid.Children.Add(collectionViewOdgovor, 0, 0);

            grid.Children.Add(backButton, 0, 1);

            Content = grid;
        }

        class LableOdgovorTemplate : DataTemplate
        {
            public LableOdgovorTemplate() : base(LoadOdgovorTemplate)
            {

            }

            private static StackLayout LoadOdgovorTemplate()
            {

                var textLable = new Label();
                textLable.SetBinding(Label.TextProperty, nameof(Pitanje.PrikaziOdgovorNaPitanje));

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = textLable
                };

                return new StackLayout
                {
                    Children = { frame },
                    Padding = new Thickness(10, 10)
                };
            }

        }
    }
}