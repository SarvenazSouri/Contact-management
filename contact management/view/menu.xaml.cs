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

namespace view
{
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : Window
    {
        public menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ajouter ajout = new Ajouter();
           
            this.Visibility = Visibility.Hidden;
            ajout.Visibility = Visibility.Visible;
            ajout.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Modifier modifier = new Modifier();
            this.Visibility = Visibility.Hidden;
            modifier.Visibility = Visibility.Visible;
            modifier.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Supprimer supprimer = new Supprimer();
            this.Visibility = Visibility.Hidden;
            supprimer.Visibility = Visibility.Visible;
            supprimer.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Afficher afficher = new Afficher();
            this.Visibility = Visibility.Hidden;
            afficher.Visibility = Visibility.Visible;
            afficher.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Rechercher rechercher = new Rechercher();
            this.Visibility = Visibility.Hidden;
            rechercher.Visibility = Visibility.Visible;
            rechercher.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow connexion = new MainWindow();
            this.Visibility = Visibility.Hidden;
            connexion.Visibility = Visibility.Visible;
            connexion.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
