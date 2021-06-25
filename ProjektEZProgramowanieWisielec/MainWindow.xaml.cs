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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ProjektEZProgramowanieWisielec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] multiplayerSettingsContent;
        public MainWindow()
        {
            InitializeComponent();
            multiplayerSettingsContent = System.IO.File.ReadAllLines("multiplayer.txt");
        }

        private void btnSolo_Click(object sender, RoutedEventArgs e)
        {
            GameWindowSolo window = new GameWindowSolo();
            window.Show();
            this.Close();
            StreamWriter multiplayerSettings = File.CreateText("multiplayer.txt");
            multiplayerSettings.WriteLine("0");
            multiplayerSettings.WriteLine(multiplayerSettingsContent[1]);
            multiplayerSettings.Close();
        }

        private void btnZnajomi_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayer window = new MultiPlayer();
            window.Show();
            this.Close();
        }
    }
}
