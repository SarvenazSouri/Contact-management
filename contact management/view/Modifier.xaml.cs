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
    /// Interaction logic for Modifier.xaml
    /// </summary>
    public partial class Modifier : Window
    {
        public Modifier()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            string numModif = this.textBoxNumModif.Text;
            string nom = this.textBoxNom.Text;
            string prenom = this.textBoxPrenom.Text;
            string adresse = this.textBoxAdresse.Text;
            string tel1 = this.textBoxTel1.Text;
            string tel2 = this.textBoxTel2.Text;
            string note = this.textBoxNote.Text;

            if (BLL.Manager.ModifierUser(numModif, nom, prenom, adresse, tel1, tel2, note))
            {
                MessageBox.Show("Modification reussi avec succes");
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
