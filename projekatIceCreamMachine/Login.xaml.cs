using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace projekatIceCreamMachine
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public ObservableCollection<string> useri { get; set; }
        public Login()
        {
            InitializeComponent();

            useri = new ObservableCollection<string> {
                "korisnik",
                "vlasnik"
            };
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            string selectedItem = (string)listBox.SelectedItem;
            if (selectedItem == "korisnik")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (selectedItem == "vlasnik")
            {
                MessageBox.Show("Unesite kredencijale");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string korisnickoIme = username.Text.ToString();
            string sifra = password.Text.ToString();

            using (var context = new EvidencijaContext())
            {
                var user = context.Korisnici.FirstOrDefault(u => u.Username == korisnickoIme && u.Password == sifra);

                if (user != null)
                {
                    // Prijavljivanje je uspješno, nastavite s logikom aplikacije
                    Vlasnik mainWindow = new Vlasnik();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    // Prijavljivanje nije uspjelo, prikažite poruku o pogrešnom unosu
                    MessageBox.Show("Uneli ste pogresan login");
                }
            }
        }
    }
}
