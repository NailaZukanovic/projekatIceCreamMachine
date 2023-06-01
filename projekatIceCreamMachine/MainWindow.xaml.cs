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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projekatIceCreamMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Prilozi { get; set; }
        public ObservableCollection<string> Velicina { get; set; }

        public ObservableCollection<string> KasikaKornet { get; set; }
        public ObservableCollection<string> Dodaci { get; set; }

        public ObservableCollection<string> Nardzbina { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Prilozi = new ObservableCollection<string>
        {
            "cokolada",
            "vanila",
            "jagoda"
        };

            Velicina = new ObservableCollection<string>
        {
            "mala korpa",
            "srednja korpa",
            "velika korpa"
        };

            KasikaKornet= new ObservableCollection<string>
        {
            "kasika",
            "kornet"
        };

            Dodaci = new ObservableCollection<string>
        {
            "cokoladne mrvice",
            "kikiriki",
            "preliv"
        };
            Nardzbina = new ObservableCollection<string>();

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _dbContext = new EvidencijaContext();

            if (kovanica.Text != null)
                if (kovanica.Text.ToString() == "5" || int.Parse(kovanica.Text.ToString()) > 5)
                    this.Nardzbina.Add("5");
                else
                    if (int.Parse(kovanica.Text.ToString()) < 5)
                    MessageBox.Show("Niste uneli pravi iznos novca");
            else
                this.Nardzbina.Add(kartica.Text.ToString());
            string nazivSladoleda = Nardzbina[0]; // Naziv sladoleda dobiven od korisnika
             
            int kolicinaZaOduzeti = 1; // Količina koju želite oduzeti

            var sladoled = _dbContext.Sladoledi.FirstOrDefault(s => s.Naziv == nazivSladoleda.ToLower());

            if (sladoled != null)
            {
                if (sladoled.KolicinaNaStanju >= kolicinaZaOduzeti)
                {
                    sladoled.KolicinaNaStanju -= kolicinaZaOduzeti;
                    _dbContext.SaveChanges();
                    MessageBox.Show("Uspješno ste oduzeli količinu sladoleda iz zalihe.");
                }
                else
                {
                    MessageBox.Show("Nedovoljna količina sladoleda na stanju.");
                }
            }
            else
            {
                MessageBox.Show("Sladoled s navedenim nazivom ne postoji.");
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            string selectedItem = (string)listBox.SelectedItem;
            this.Nardzbina.Add(selectedItem);
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            string selectedItem = (string)listBox.SelectedItem;
            this.Nardzbina.Add(selectedItem);
        }

        private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            string selectedItem = (string)listBox.SelectedItem;
            this.Nardzbina.Add(selectedItem);
        }

        private void ListBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            string selectedItem = (string)listBox.SelectedItem;
            this.Nardzbina.Add(selectedItem);

        }
    }
}
