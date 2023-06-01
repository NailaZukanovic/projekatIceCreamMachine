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

namespace projekatIceCreamMachine
{
    /// <summary>
    /// Interaction logic for Vlasnik.xaml
    /// </summary>
    public partial class Vlasnik : Window
    {
        public Vlasnik()
        {
            InitializeComponent();
            using (var context = new EvidencijaContext())
            {
                var sladoledi = context.Sladoledi.ToList();


                grafCokolade.Height = sladoledi[0].KolicinaNaStanju * 20;
                grafVanile.Height = sladoledi[1].KolicinaNaStanju * 20;
                grafJagode.Height = sladoledi[2].KolicinaNaStanju * 20;

                cokolada.Text = sladoledi[0].KolicinaNaStanju.ToString();
                vanila.Text = sladoledi[1].KolicinaNaStanju.ToString();
                jagode.Text = sladoledi[2].KolicinaNaStanju.ToString();


               
               
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new EvidencijaContext())
            {
                // Dohvati sladoled iz baze na osnovu ID-ja
                int cokoladaId = 1;
                Sladoled cokolade = context.Sladoledi.Find(cokoladaId);
                int vanilaId = 2;
                Sladoled vanile = context.Sladoledi.Find(vanilaId);
                int jagodaId = 2;
                Sladoled jagoda = context.Sladoledi.Find(jagodaId);

                // Pročitaj novo stanje za čokoladu iz TextBox-a
                int novoStanjeCokolade = int.Parse(stanjeCokolade.Text);
                // Pročitaj novo stanje za čokoladu iz TextBox-a
                int novoStanjeVanile = int.Parse(stanjeVanile.Text);
                // Pročitaj novo stanje za čokoladu iz TextBox-a
                int novoStanjeJagode = int.Parse(stanjeJagode.Text);

                // Ažuriraj polje KolicinaNaStanju
                cokolade.KolicinaNaStanju = novoStanjeCokolade;

                // Ažuriraj polje KolicinaNaStanju
                vanile.KolicinaNaStanju = novoStanjeVanile;
                // Ažuriraj polje KolicinaNaStanju
                jagoda.KolicinaNaStanju = novoStanjeJagode;
                // Sačuvaj promene u bazi
                context.SaveChanges();

                cokolada.Text = novoStanjeCokolade.ToString();
                vanila.Text = novoStanjeVanile.ToString();
                jagode.Text = novoStanjeJagode.ToString();


                grafCokolade.Height = novoStanjeCokolade * 20;
                grafVanile.Height = novoStanjeVanile * 20;
                grafJagode.Height = novoStanjeJagode * 20;

            }
        }
    }
}
