using System.Windows;

namespace view
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string id = this.textBox1.Text;
            string mdp = this.password.Password;
            if (BLL.Manager.RechercheLogin(id, mdp))
            {
                menu menu = new menu();
                this.Visibility = Visibility.Hidden;
                menu.Visibility = Visibility.Visible;
                menu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else
            {
                MessageBox.Show("Username ou Password est incorrect");
            }
        }
        
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string id = this.textBox1.Text;
            string mdp = this.password.Password;
            if (BLL.Manager.CreateUser(id, mdp))
            {
                MessageBox.Show("compte cree");
                menu menu = new menu();
                this.Visibility = Visibility.Hidden;
                menu.Visibility = Visibility.Visible;
                menu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else
            {
                MessageBox.Show("Username ou Password deja utiliser");
            }
        }
    }
}
