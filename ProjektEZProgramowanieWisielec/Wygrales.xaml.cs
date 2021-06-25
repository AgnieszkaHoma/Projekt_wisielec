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
    /// Logika interakcji dla klasy Wygrales.xaml
    /// </summary>
    public partial class Wygrales : Window
    {
        string[] multiplayerSettingsContent;
        public Wygrales()
        {
            InitializeComponent();
            multiplayerSettingsContent = System.IO.File.ReadAllLines("multiplayer.txt");
        }

        private void btnJeszczeRaz_Click(object sender, RoutedEventArgs e)
        {
            ///jeśli stan solo, czyli zero, to wrócić się prosto do gry
            if (int.Parse(multiplayerSettingsContent[0]) == 0)
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

        private void btnDoMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
