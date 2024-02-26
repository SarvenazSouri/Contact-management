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
    /// Interaction logic for Afficher.xaml
    /// </summary>
    public partial class Afficher : Window
    {
        public Afficher()
        {
            InitializeComponent();
            List<Contact> liste = BLL.Manager.Afficher();
            StackPanel myStackPanel = new StackPanel();
            foreach (Contact l in liste)
            {
                TextBlock myTextBlock = new TextBlock();
                myTextBlock.Text = l.ToString();
                
                myStackPanel.Children.Add(myTextBlock);
            }
            
            scrollViewer.Content = myStackPanel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menu menu = new menu();
            this.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Visible;
            menu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void OrdreCoisis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = ordreCoisis.SelectedItem.ToString();
            selection = selection.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            List<Contact> liste = BLL.Manager.AfficherOrdre(selection);

            StackPanel myStackPanel = new StackPanel();
            foreach (Contact l in liste)
            {
                TextBlock myTextBlock = new TextBlock();
                myTextBlock.Text = l.ToString();

                myStackPanel.Children.Add(myTextBlock);
            }

            scrollViewer.Content = myStackPanel;
        }
    }
}
