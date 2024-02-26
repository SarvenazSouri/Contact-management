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
    /// Interaction logic for Supprimer.xaml
    /// </summary>
    public partial class Supprimer : Window
    {
        public Supprimer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menu menu = new menu();

            this.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Visible;
            menu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string numModif = this.textBoxModifNum.Text;

            if (BLL.Manager.SupprUser(numModif))
            {
                MessageBox.Show("Suppression reussi avec succes");
                menu menu = new menu();

                this.Visibility = Visibility.Hidden;
                menu.Visibility = Visibility.Visible;
                menu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else
            {
                MessageBox.Show("Verifiez vos saisie");
            }
        }
    }
}
