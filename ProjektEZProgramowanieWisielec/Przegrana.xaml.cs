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
    /// <summary>
    /// Logika interakcji dla klasy Przegrana.xaml
    /// </summary>
    public partial class Przegrana : Window
    {
        string[] multiplayerSettingsContent;

        public Przegrana()
        {
            multiplayerSettingsContent = System.IO.File.ReadAllLines("multiplayer.txt");
            InitializeComponent();
            
        }



        private void btnDoMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnJeszczeRaz_Click(object sender, RoutedEventArgs e)
        {
            if(int.Parse(multiplayerSettingsContent[0]) == 0)
            {
                GameWindowSolo gameWindow = new GameWindowSolo();
                gameWindow.Show();
                this.Close();
            }
            else
            {
                MultiPlayer multiplayerWindow = new MultiPlayer();
                multiplayerWindow.Show();
                this.Close();
            }
            
        }
    }
}
