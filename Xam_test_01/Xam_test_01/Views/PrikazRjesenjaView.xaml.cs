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
        public PrikazRjesenjaView(string param, ArrayList odgovorArray, string imageSource)
        {
            BindingContext = new PrikazRjesenjaViewModel(odgovorArray, imageSource);
            Title = param;

            var zajednickiElementi = new ZajednickiElementiAplikacije();

            var collectionViweFormula = new CollectionView
            {
                ItemTemplate = new ImageFromulaTemplate()
            };
            collectionViweFormula.SetBinding(ItemsView.ItemsSourceProperty, nameof(PrikazRjesenjaViewModel.FormulaCollection));

            var collectionViewOdgovor = new CollectionView
            {
                ItemTemplate = new LableOdgovorTemplate(),
                VerticalScrollBarVisibility = ScrollBarVisibility.Always
            };
            collectionViewOdgovor.SetBinding(ItemsView.ItemsSourceProperty, nameof(PrikazRjesenjaViewModel.OdgovorCollection));

            var backButton = zajednickiElementi.BackNavigationButton("Nazad");
            backButton.SetBinding(Button.CommandProperty, nameof(PrikazRjesenjaViewModel.NazadCommand));

            var grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(110, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(90, GridUnitType.Absolute) }
                }
            };

            grid.Children.Add(collectionViweFormula, 0, 0);

            grid.Children.Add(collectionViewOdgovor, 0, 1);

            grid.Children.Add(backButton, 0, 2);

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
                textLable.SetBinding(Label.TextProperty, nameof(PitanjeModel.Ogovor));
                textLable.FontSize = 18;

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = textLable
                };

                return new StackLayout
                {
                    Children = { frame },
                    Padding = new Thickness(20, 10, 20, 0)
                };
            }

        }

        class ImageFromulaTemplate : DataTemplate
        {
            public ImageFromulaTemplate() : base(LoadOdgovorTemplate)
            {

            }

            private static StackLayout LoadOdgovorTemplate()
            {
                var formulaImage = new Image
                {
                    HeightRequest = 50
                };
                formulaImage.SetBinding(Image.SourceProperty, nameof(PitanjeModel.FormulaImage));


                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = formulaImage,
                    Margin = new Thickness(10, 10, 10, 0)
                };

                return new StackLayout
                {
                    Children = { frame }
                };
            }

        }
    }
}