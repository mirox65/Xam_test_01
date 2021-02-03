using Xam_test_01.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PitanjaView : ContentPage
    {
        public PitanjaView()
        {
            var pitanje = new Pitanje();

            BindingContext = new PitanjaViewModel();

            Title = "Kinematika";

            var collectionViewPitanje = new CollectionView
            {
                ItemTemplate = new LablePitanjeTemplate()
            };

            collectionViewPitanje.SetBinding(ItemsView.ItemsSourceProperty, nameof(PitanjaViewModel.PitanjeCollection));

            var collectionViewOdgovor = new CollectionView
            {
                ItemTemplate = new LableOdgovorTemplate()
            };

            collectionViewOdgovor.SetBinding(ItemsView.ItemsSourceProperty, nameof(PitanjaViewModel.OdgovorCollection));

            //var textLablePitanje = new Label
            //{
            //    Text = "Pitanje",
            //    FontSize = 16,
            //    Margin = new Thickness(15)
            //};

            //textLablePitanje.SetBinding(Label.TextProperty, nameof(PitanjaViewModel.LablePitanja));

            //var textLableOdgovor = new Label
            //{
            //    Text = "Odgovor",
            //    FontSize = 16,
            //    Margin = new Thickness(15)
            //};

            var generirajPitanjeButton = new Button
            {
                Text = "Generator pitanja",
                BackgroundColor = pitanje.PrimarnaBoja,
                TextColor = Color.Black,
                TextTransform = TextTransform.Uppercase,
                FontSize = 18
            };

            generirajPitanjeButton.SetBinding(Button.CommandProperty, nameof(PitanjaViewModel.GenerirajPitanjeCommand));

            var prikaziOdgovorButton = new Button
            {
                Text = "Prikaži riješenje",
                BackgroundColor = pitanje.NavigacijaDrugaBoja,
                TextColor = Color.Black,
                TextTransform = TextTransform.Uppercase,
                FontSize = 18,
                IsVisible = false
            };

            prikaziOdgovorButton.SetBinding(Button.CommandProperty, nameof(PitanjaViewModel.PrikaziOdgovorCommand));
            prikaziOdgovorButton.SetBinding(IsVisibleProperty, nameof(PitanjaViewModel.Vidljivo));

            var grid = new Grid
            {
                Margin = new Thickness(10, 10),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(0.3, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(70 , GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(70 , GridUnitType.Absolute) }
                }
            };

            //grid.Children.Add(textLablePitanje, 0, 0);
            //grid.Children.Add(textLableOdgovor, 0, 1);
            grid.Children.Add(collectionViewPitanje, 0, 0);
            grid.Children.Add(collectionViewOdgovor, 0, 1);
            grid.Children.Add(prikaziOdgovorButton, 0, 2);
            grid.Children.Add(generirajPitanjeButton, 0, 3);

            Content = grid;
        }

        class LableOdgovorTemplate : DataTemplate
        {
            public LableOdgovorTemplate () : base(LoadOdgovorTemplate)
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

        class LablePitanjeTemplate : DataTemplate
        {
            public LablePitanjeTemplate() : base(LoadTemplate)
            {

            }

            private static StackLayout LoadTemplate()
            {
                var pitanje = new Pitanje();
                var textLable = new Label();
                textLable.FontSize = 18;
                textLable.SetBinding(Label.TextProperty, nameof(Pitanje.PrikaziGeneriranoPitanje));

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = textLable,
                    BackgroundColor = pitanje.PrimarnaBoja
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