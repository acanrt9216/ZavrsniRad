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
    /// Interaction logic for IzmenaSatnice.xaml
    /// </summary>
    public partial class IzmenaSatnice : Window
    {
        private Satnica sa;
        Komunikacija k;        
        public IzmenaSatnice(Satnica sa,Komunikacija kom)
        {
            InitializeComponent();
            this.sa = sa;
            k = kom;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbSatnicaID.Text = Convert.ToString(sa.SatnicaID);
            tbNaziv.Text = sa.Naziv;
            tbOpis.Text = sa.Opis;
            tbBrojSati.Text = Convert.ToString(sa.BrojSati);
        }

        private void BtnIzmenaSatnice_Click(object sender, RoutedEventArgs e)
        {
            Satnica sa = new Satnica();
            sa.SatnicaID = Convert.ToInt32(tbSatnicaID.Text);
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                sa.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti naziv satnice!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbOpis.Text))
            {
                sa.Opis = tbOpis.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti opis satnice!");
                tbOpis.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbBrojSati.Text))
            {
                sa.BrojSati = Convert.ToInt32(tbBrojSati.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti broj sati satnice!");
                tbBrojSati.Focus();
                return;
            }
            
            int izmenjen = k.izmeniSatnicu(sa);
            if (izmenjen == 0)
            {
                MessageBox.Show("Neuspesno izmenjena satnica!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjena satnica!");
            }
        }

        
    }
}
