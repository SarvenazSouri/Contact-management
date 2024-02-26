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
using Model;

namespace view
{
    /// <summary>
    /// Interaction logic for Rechercher.xaml
    /// </summary>
    public partial class Rechercher : Window
    {
        public Rechercher()
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
            string recherche = this.textbox1.Text;
            List<Contact> liste = BLL.Manager.AfficherRecherche(recherche);
            StackPanel myStackPanel = new StackPanel();
            foreach (Contact l in liste)
            {
                TextBlock myTextBlock = new TextBlock();
                myTextBlock.Text = l.ToString();

                myStackPanel.Children.Add(myTextBlock);
            }

            label1.Content = myStackPanel;
        }
    }
}
