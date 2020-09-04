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
    public partial class IzmenaKapije : Window
    {
        Kapija k;
        Komunikacija kom;
        public IzmenaKapije(Kapija k,Komunikacija komunikacija)
        {
            InitializeComponent();
            this.k = k;
            kom = komunikacija;
        }

        private void BtnIzmenaKapiju_Click(object sender, RoutedEventArgs e)
        {
            Kapija ka = new Kapija();
            ka.KapijaID = Convert.ToInt32(tbKapijaID.Text);
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                ka.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti naziv kapije!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbOpis.Text))
            {
                ka.Opis = tbOpis.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti opis kapije!");
                tbOpis.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbLokacija.Text))
            {
                ka.Lokacija = cmbLokacija.SelectedItem as Lokacija;
            }
            else
            {
                MessageBox.Show("Morate odabrati lokaciju kapije!");
                cmbLokacija.Focus();
                return;
            }
            
            int a = kom.izmeniKapiju(ka);
            if (a == 0)
            {
                MessageBox.Show("Neuspesna izmena kapije!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjena kapija!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbKapijaID.Text = Convert.ToString(k.KapijaID);
            tbNaziv.Text = k.Naziv;
            tbOpis.Text = k.Opis;
            cmbLokacija.ItemsSource =kom.vratiListuLokacija();
        }
    }
}
