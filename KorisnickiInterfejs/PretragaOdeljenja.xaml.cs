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
using Biblioteka;
using Sesija;

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for PretragaOdeljenja.xaml
    /// </summary>
    public partial class PretragaOdeljenja : Window
    {
        private Radnik r;
        Komunikacija k;

        public PretragaOdeljenja(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            dataGrid.ItemsSource = k.vratiListuOdeljenja();
        }

        private void BtnPregledOdeljenja_Click(object sender, RoutedEventArgs e)
        {
            Odeljenje o = new Odeljenje();
            Odeljenje od = dataGrid.SelectedItem as Odeljenje;
            if (od != null)
            {
                o.OdeljenjeID = od.OdeljenjeID;
                o.Naziv = od.Naziv;
                o.SefOdeljenja = od.SefOdeljenja;
                o.BrojZaposlenih = od.BrojZaposlenih;
            }
            new PregledOdeljenje(r,o,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuOdeljenja();
        }
        private void BtnObrisiOdeljenje_Click(object sender, RoutedEventArgs e)
        {
            Odeljenje o = dataGrid.SelectedItem as Odeljenje;
            int a = k.obrisiOdeljenje(o);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno obrisano odeljenje!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno obrisano odeljenje!");
            }
            dataGrid.ItemsSource = k.vratiListuOdeljenja();
        }

        private void BtnPretraziOdeljenje_Click(object sender, RoutedEventArgs e)
        {
            int brojZaposlenih=0;
            int broj = 0;
            string naziv,ime,prezime;
            naziv = tbNaziv.Text;
            string[] sefOdeljenja = tbSefOdeljenja.Text.Split(' ');
            ime = sefOdeljenja[0];
            prezime = sefOdeljenja[1];
            if(Int32.TryParse(tbBrojZaposlenih.Text,out broj))
            {
                brojZaposlenih = Convert.ToInt32(tbBrojZaposlenih.Text);
            }
            

            dataGrid.ItemsSource = k.vratiOdeljenjePretraga(naziv,ime,prezime,brojZaposlenih);
        }

        private void BtnDodajOdeljenje_Click(object sender, RoutedEventArgs e)
        {
            new UnosOdeljenja(r,k).ShowDialog();
        }
    }
}
