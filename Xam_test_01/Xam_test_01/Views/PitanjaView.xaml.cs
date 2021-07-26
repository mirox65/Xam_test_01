using Xam_test_01.Models;
using Xam_test_01.Pomocne;
using Xam_test_01.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam_test_01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PitanjaView : ContentPage
    {
        /// <summary>
        /// View koji se bavi generiranjem elementa za provjeru znanja korisnika.
        /// Elementi stranice se generiraju kroz klasu tako da se ne koristi xaml za frontend
        /// </summary>
        /// 

        // Properti za nazive gumba koji se generira iz zajedeničke metode aplikacije
        private readonly string novoPitanje = "Novo pitanje";
        private readonly string prikaziRiješenjeButton = "Prikaži riješenje";
        private readonly string prikaziRješenjeNaziv = "Rješenje zadatka";

        public PitanjaView(string nazivGraneNavigacija)
        {
            // Instanciranje klase zajednicki elementi aplikacije koja sadrži unificirani gumb
            var zajednickiElementi = new ZajednickiElementiAplikacije();

            // Veza sa view modelom koji je potereban jer view model odrađuje poslovnu logiku aplikacije
            BindingContext = new PitanjaViewModel();

            // Naziv stranice koji se prikazuje u navigacijskom elenentu stranice.
            // Naziv dolazi vezan za command property guba sa prijašnjeg view-a u ovom slučaju temaView
            Title = nazivGraneNavigacija;

            // Kolekcija koja može biti i samo label jer sadrži vrijednost string pitanja koje se postavlja korsniku
            // Vezan je za ViewModel vrijednost pitanje kolekcija koji sadrži string i koji se vraća u view za prikaz korisniku
            var collectionViewPitanje = new CollectionView
            {
                ItemTemplate = new LablePitanjeTemplate()
            };
            collectionViewPitanje.SetBinding(ItemsView.ItemsSourceProperty, nameof(PitanjaViewModel.PitanjeCollection));

            // Entry polje (bolje poznato kao input korisnik unosi vrijednost riješenja formule koju je napravio na "papiru" 
            // Entry je vezan za property OdgovorKorisnika u ViewModelu koji se ažurira u stvarno vremenu automatski
            // Entry polje se ne prikazuje priliku instanciranja Pregleda, postaje vidljivo tek kad se generira prvo pitanje
            var unosOdgovora = new Entry
            {
                Placeholder = "Unesi odgovor",
                BackgroundColor = Color.White,
                Margin = new Thickness(20, 10),
            };
            unosOdgovora.SetBinding(Entry.TextProperty, "OdgovorKorisnika");
            unosOdgovora.SetBinding(IsVisibleProperty, nameof(PitanjaViewModel.IsVisible));


            var collectionViewMjernaJedinica = new CollectionView
            {
                ItemTemplate = new LableMjernaJedinicaTemplate()
            };
            collectionViewMjernaJedinica.SetBinding(ItemsView.ItemsSourceProperty, nameof(PitanjaViewModel.MjernaJedinicaOdgovoraCollection));

            var obavjestNakonOdgovora = new CollectionView
            {
                ItemTemplate = new LableObavjestOdgvorTemplate()
            };
            obavjestNakonOdgovora.SetBinding(ItemsView.ItemsSourceProperty, nameof(PitanjaViewModel.ObavijestKorisnikuCollection));


            var collectionViewOdgovor = new CollectionView
            {
                ItemTemplate = new LableOdgovorTemplate()
            };
            collectionViewOdgovor.SetBinding(ItemsView.ItemsSourceProperty, nameof(PitanjaViewModel.OdgovorCollection));

            // Button za generiranje novog pitanja
            // Vezano je na ViewModel na ICommand GenerirajPitanjeCommand
            // Pošto je to button koji korisiti primarne boje instancira se iz zajedničkih elemenata
            // Sam gumb je preopterečena metoda za izradu novog gumba jer naziv gumba i commandProperty nisu ista vrijednost
            var generirajPitanjeButton = zajednickiElementi.PrimarniNavigacijskiButton(novoPitanje, nazivGraneNavigacija);
            generirajPitanjeButton.SetBinding(Button.CommandProperty, nameof(PitanjaViewModel.GenerirajPitanjeCommand));

            // Button koji će prikazati korisniku odogovor nakon što je unešeno riješenje i provjereno
            // Pošto je to jedini gumb ovih vrijednosti onda ga ne generiramo iz zajedničkih elelemnata
            // Ali pošto koristi boje aplikacije da bi se održala uniformiranost boju vuče iz zajedničkih elemenata
            // Gumb nije vidljiv dok se ne unese riješenje
            var prikaziOdgovorButton = zajednickiElementi.PrimarniNavigacijskiButton(prikaziRiješenjeButton, prikaziRješenjeNaziv);
            prikaziOdgovorButton.BackgroundColor = zajednickiElementi.NavigacijaDrugaBoja;
            prikaziOdgovorButton.SetBinding(Button.CommandProperty, nameof(PitanjaViewModel.PrikaziOdgovorCommand));
            prikaziOdgovorButton.SetBinding(IsEnabledProperty, nameof(PitanjaViewModel.IsEnabledRiješenje));

            // Gumb koji korsnik uspoređuje svoje rješenje jednadžbe s rješenjem aplikacije
            var provjeriOdgovorButton = zajednickiElementi.PrimarniNavigacijskiButton("Provjeri rješenje");
            provjeriOdgovorButton.BackgroundColor = zajednickiElementi.BackColorGreen;
            provjeriOdgovorButton.SetBinding(Button.CommandProperty, nameof(PitanjaViewModel.ProvjeriOdgovorCommand));
            provjeriOdgovorButton.SetBinding(Button.IsEnabledProperty, nameof(PitanjaViewModel.IsEnabledProvjeriOdgovor));


            // Generiranje mreže koja će držati elemente aplikacije u pregledu za korisnika
            // Mreža ima dvije kolone i 4 reda
            var grid = new Grid
            {
                Margin = new Thickness(10, 10),

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(0.5, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(90, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(90, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(70 , GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(70 , GridUnitType.Absolute) }
                }
            };

            // Dodavanje elementa na sam pregled neki elementi se protežu preko cijelog reda dok drugi zauzimaju jednu od kolona
            grid.Children.Add(collectionViewPitanje, 0, 0);
            Grid.SetColumnSpan(collectionViewPitanje, 2);

            //grid.Children.Add(collectionViewOdgovor, 0, 1);

            grid.Children.Add(unosOdgovora, 0, 1);
            Grid.SetColumnSpan(unosOdgovora, 2);

            grid.Children.Add(collectionViewMjernaJedinica, 0, 2);
            Grid.SetColumnSpan(collectionViewMjernaJedinica, 2);

            grid.Children.Add(obavjestNakonOdgovora, 0, 3);
            Grid.SetColumnSpan(obavjestNakonOdgovora, 2);

            grid.Children.Add(prikaziOdgovorButton, 0, 4);
            Grid.SetColumnSpan(prikaziOdgovorButton, 1);

            grid.Children.Add(provjeriOdgovorButton, 1, 4);
            Grid.SetColumnSpan(provjeriOdgovorButton, 1);

            grid.Children.Add(generirajPitanjeButton, 0, 5);
            Grid.SetColumnSpan(generirajPitanjeButton, 2);

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

        // Klasa za generiranje elementa stacklayout i label u kojem će se prikazati korisninku metoda se može iskoristiti i za prikaz više elementa bez if ili foreach petlje
        class LablePitanjeTemplate : DataTemplate
        {
            public LablePitanjeTemplate() : base(LoadTemplate)
            {

            }

            private static StackLayout LoadTemplate()
            {
                var zajednickiElementi = new ZajednickiElementiAplikacije();
                var pitanjeTextLable = new Label
                {
                    FontSize = 18
                };
                pitanjeTextLable.SetBinding(Label.TextProperty, nameof(Pitanje.PrikaziGeneriranoPitanje));

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = pitanjeTextLable,
                    BackgroundColor = zajednickiElementi.PrimarnaBoja
                };

                return new StackLayout
                {
                    Children = { frame },
                    Padding = new Thickness(10, 10)
                };
            }
        }

        class LableObavjestOdgvorTemplate : DataTemplate
        {
            public LableObavjestOdgvorTemplate() : base(LoadTemplate)
            {

            }

            private static StackLayout LoadTemplate()
            {
                var zajednickiElementi = new ZajednickiElementiAplikacije();
                var pitanja = new PitanjaViewModel();

                var textLable = new Label
                {
                    FontSize = 18
                };
                textLable.SetBinding(Label.TextProperty, nameof(Pitanje.ObavjestNakonOdgovora));

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = textLable
                };
                frame.SetBinding(BackgroundColorProperty, nameof(Pitanje.BojaPozdaineOdgovora));

                return new StackLayout
                {
                    Children = { frame },
                    Padding = new Thickness(10, 10)
                };
            }
        }

        class LableMjernaJedinicaTemplate : DataTemplate
        {
            public LableMjernaJedinicaTemplate() : base(LoadTemplate)
            {

            }

            private static StackLayout LoadTemplate()
            {
                var zajednickiElementi = new ZajednickiElementiAplikacije();
                var textLable = new Label
                {
                    FontSize = 18,
                };
                textLable.SetBinding(Label.TextProperty, nameof(Pitanje.MjernaJedinicaOdgovora));

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = textLable,
                    BackgroundColor = zajednickiElementi.PrimarnaBoja,
                };

                return new StackLayout
                {
                    Children = { frame },
                    Padding = new Thickness(20, 10)
                };
            }
        }
    }
}