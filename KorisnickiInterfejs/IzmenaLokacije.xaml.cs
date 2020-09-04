using Biblioteka;
using Sesija;
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

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for IzmenaLokacije.xaml
    /// </summary>
    public partial class IzmenaLokacije : Window
    {
        Lokacija l;
        Komunikacija k;
        public IzmenaLokacije(Lokacija l,Komunikacija kom)
        {
            InitializeComponent();
            this.l = l;
            k = kom;
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbLokacijaID.Text = Convert.ToString(l.LokacijaID);
            tbNaziv.Text = l.Naziv;
            tbOpis.Text = l.Opis;
        }
        private void BtnIzmenaLokacije_Click(object sender, RoutedEventArgs e)
        {
            Lokacija lo = new Lokacija();
            lo.LokacijaID = Convert.ToInt32(tbLokacijaID.Text);
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                lo.Naziv = tbNaziv.Text;

            }
            else
            {
                MessageBox.Show("Morate uneti naziv!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbOpis.Text))
            {
                lo.Opis = tbOpis.Text;

            }
            else
            {
                MessageBox.Show("Morate uneti opis!");
                tbOpis.Focus();
                return;
            }
            
            int a = k.izmeniLokaciju(lo);
            if (a == 0)
            {
                MessageBox.Show("Nije izmenjena lokacija!");
                return;
            }
            else
            {
                MessageBox.Show("Izmenjena lokacija!");
            }
        }

    }
}
