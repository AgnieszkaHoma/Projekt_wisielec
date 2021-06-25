using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace ProjektEZProgramowanieWisielec
{
    public partial class GameWindowSolo : Window
    {
        List<TextBox> myTextboxList = new List<TextBox>();
        List<Image> szubienicaSticks = new List<Image>();

        Random randomNumber = new Random();

        string[] multiplayerSettings;
        string[] wszystkieHasla;
        string haslo;

        public GameWindowSolo()
        {
            multiplayerSettings = System.IO.File.ReadAllLines("multiplayer.txt");
            InitializeComponent();

            myTextboxList.Add(TextBoxLitera1);
            myTextboxList.Add(TextBoxLitera2);
            myTextboxList.Add(TextBoxLitera3);
            myTextboxList.Add(TextBoxLitera4);
            myTextboxList.Add(TextBoxLitera5);
            myTextboxList.Add(TextBoxLitera6);
            myTextboxList.Add(TextBoxLitera7);
            myTextboxList.Add(TextBoxLitera8);
            myTextboxList.Add(TextBoxLitera9);
            myTextboxList.Add(TextBoxLitera10);
            myTextboxList.Add(TextBoxLitera11);
            myTextboxList.Add(TextBoxLitera12);
            myTextboxList.Add(TextBoxLitera13);
            myTextboxList.Add(TextBoxLitera14);
            myTextboxList.Add(TextBoxLitera15);
            myTextboxList.Add(TextBoxLitera16);
            myTextboxList.Add(TextBoxLitera17);
            myTextboxList.Add(TextBoxLitera18);

            szubienicaSticks.Add(szub1);
            szubienicaSticks.Add(szub2);
            szubienicaSticks.Add(szub3);
            szubienicaSticks.Add(szub4);
            szubienicaSticks.Add(szub5);
            szubienicaSticks.Add(szub6);
            szubienicaSticks.Add(szub7);
            szubienicaSticks.Add(szub8);
            szubienicaSticks.Add(szub9);
            szubienicaSticks.Add(szub10);
            szubienicaSticks.Add(szub11);
            szubienicaSticks.Add(szub12);

            ///wczytanie wszystkich możliwych haseł i wybranie jednego
            wszystkieHasla = System.IO.File.ReadAllLines("hasla.txt");
            randomNumber.Next(0, wszystkieHasla.Length);
            haslo = wszystkieHasla[randomNumber.Next(0, wszystkieHasla.Length)];

            ///jeśli multiplayer był włączony 
            if(int.Parse(multiplayerSettings[0]) == 1) 
            {
                haslo = multiplayerSettings[1];
            }

            /// ustawienie widocznych pól tak, by pasowały do ilości liter
            for (int i = 0; i < haslo.Length; i++)
            {
                myTextboxList[i].Visibility = Visibility.Visible;
            }
            MessageBox.Show(haslo.ToString());
        }

        int iloscProb = 12;
        int liczbaPoprawnych;
        bool czyZnalezionoLitere = false;
        bool czyBylBlond = false;
        
        char wybranaLitera;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wybranaLitera = (char)TextBoxWybranaLitera.Text[0];
            for(int i=0; i < haslo.Length ; i++)
            {
                if ((char)haslo[i] == wybranaLitera)
                {
                    liczbaPoprawnych ++;
                    myTextboxList[i].Text = wybranaLitera.ToString();
                    czyZnalezionoLitere = true;
                }
            }
            if (czyZnalezionoLitere == false)
            {
                czyBylBlond = true;
            }

            if (czyBylBlond == true)
            {
                iloscProb--;
                labelLicznik.Content = iloscProb.ToString();
                szubienicaSticks[iloscProb].Opacity = 100;
                czyBylBlond = false;
                czyZnalezionoLitere = false;
            }
            czyZnalezionoLitere = false;

            ///sprawdzenie warunku przegranej
            if(iloscProb == 0)
            {
                Przegrana przegranaWindow = new Przegrana();
                przegranaWindow.Show();
                this.Close();
            }

            ///sprawdzenie warunku wygranej
            if(liczbaPoprawnych == haslo.Length)
            {
                Wygrales wygranaWindow = new Wygrales();
                wygranaWindow.Show();
                this.Close();
            }
        }

    }
}
