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
    /// Logika interakcji dla klasy MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        public MultiPlayer()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxHaslo.Text.Length < 4)
            {
                MessageBox.Show("Więcej kreatywniości :p");
            }
            else
            {
                StreamWriter swZ = File.CreateText("multiplayer.txt");
                swZ.WriteLine("1");
                swZ.WriteLine(TextBoxHaslo.Text);
                swZ.Close();

                GameWindowSolo gameWindow = new GameWindowSolo();
                gameWindow.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
