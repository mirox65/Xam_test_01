using System;
using System.Collections.Generic;
using System.Text;
using Xam_test_01.Models;
using Xamarin.Forms;

namespace Xam_test_01.Pomocne
{
    internal class ZajednickiElementiAplikacije
    {
        /// <summary>
        /// Zajednički elementi aplikacije kao gumbi, boje i stringovi koji će stvarati samu apikaciju
        /// </summary>
        /// <param name="naziv"></param>
        /// <returns></returns>
        /// 

        // Properties boje inicijalizirane u samom propertiju

        public Color NavigacijaDrugaBoja { get; set; } = Color.FromRgb(153, 153, 255);
        public Color PrimarnaBoja { get; set; } = Color.FromRgb(255, 255, 153);
        public Color GridBackColor { get; set; } = Color.FromRgb(243, 242, 242);
        public Color BackColorGreen { get; set; } = Color.FromRgb(113, 188, 104);

        // Gumbi

        internal Button PrimarniNavigacijskiButton(string naziv) => new Button
        {
            Text = naziv,
            BackgroundColor = PrimarnaBoja,
            TextColor = Color.Black,
            TextTransform = TextTransform.Uppercase,
            FontSize = 18,
            CommandParameter = naziv,
            Margin = new Thickness(20, 10, 20, 0),
            HeightRequest = 100
        };

        internal ImageButton FormulaNavButton(string v1, string v2) => new ImageButton
        {
            Source = v1,
            BackgroundColor = PrimarnaBoja,
            HeightRequest = 100,
            Padding = 20,
            Margin = new Thickness(20, 10, 20, 0),
            CommandParameter = v2
        };

        internal Button PrimarniNavigacijskiButton(string naziv, string temaPitanja) => new Button
        {
            Text = naziv,
            BackgroundColor = PrimarnaBoja,
            TextColor = Color.Black,
            TextTransform = TextTransform.Uppercase,
            FontSize = 18,
            CommandParameter = temaPitanja,
            Margin = new Thickness(20, 10, 20, 0),
            HeightRequest = 100
        };

        internal Button BackNavigationButton(string naziv) => new Button
        {
            Text = naziv,
            BackgroundColor = PrimarnaBoja,
            TextColor = Color.Black,
            TextTransform = TextTransform.Uppercase,
            FontSize = 18,
            Margin = new Thickness(10),
            HeightRequest = 100
        };

        internal Button OtherButton(string naziv) => new Button
        {
            Text = naziv,
            BackgroundColor = PrimarnaBoja,
            TextColor = Color.Black,
            TextTransform = TextTransform.Uppercase,
            FontSize = 18,
            CommandParameter = naziv
        };

        internal Button OtherButton(string naziv, string param) => new Button
        {
            Text = naziv,
            BackgroundColor = PrimarnaBoja,
            TextColor = Color.Black,
            TextTransform = TextTransform.Uppercase,
            FontSize = 18,
            CommandParameter = param
        };

        internal ImageButton FormulaNavButton(string param) => new ImageButton
        {
            Source = BibliotekaSlika.ImageSource(param),
            BackgroundColor = PrimarnaBoja,
            HeightRequest = 100,
            Padding = 20,
            Margin = new Thickness(20, 10, 20, 0),
            CommandParameter = param
        };
    }
}
