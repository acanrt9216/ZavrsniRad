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
    /// Interaction logic for IzmenaOdeljenja.xaml
    /// </summary>
    public partial class IzmenaOdeljenja : Window
    {
        Odeljenje o;
        Radnik r;
        Komunikacija k;
        public IzmenaOdeljenja(Radnik r,Odeljenje o,Komunikacija kom)
        {
            InitializeComponent();
            this.o = o;
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbOdeljenjeID.Text = Convert.ToString(o.OdeljenjeID);
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                tbNaziv.Text = o.Naziv;
            }
            else
            {
                MessageBox.Show("Morate uneti naziv odeljenja!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbSefOdeljenja.Text))
            {
                cmbSefOdeljenja.ItemsSource = k.vratiListuRadnika();
            }
            else
            {
                MessageBox.Show("Morate odabrati sefa odeljenja odeljenja!");
                cmbSefOdeljenja.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbBrojZaposlenih.Text))
            {
                tbBrojZaposlenih.Text = Convert.ToString(o.BrojZaposlenih);
            }
            else
            {
                MessageBox.Show("Morate uneti broj zaposlenih odeljenja!");
                tbBrojZaposlenih.Focus();
                return;
            }
            
            
            if (r.Privilegija == 2)
            {
                cmbSefOdeljenja.IsEnabled = false;
                cmbSefOdeljenja.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnIzmenaOdeljenja_Click(object sender, RoutedEventArgs e)
        {
            Odeljenje od = new Odeljenje();
            od.OdeljenjeID = Convert.ToInt32(tbOdeljenjeID.Text);
            od.Naziv = tbNaziv.Text;
            if (r.Privilegija == 2)
            {
                od.SefOdeljenja = o.SefOdeljenja as Radnik;
            }
            else
            {
                od.SefOdeljenja = cmbSefOdeljenja.SelectedItem as Radnik;
            }
             
            od.BrojZaposlenih = Convert.ToInt32(tbBrojZaposlenih.Text);

            int a = k.izmeniOdeljenje(od);
            if (a == 0)
            {
                MessageBox.Show("Neuspesna izmena odeljenja!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjeno odeljenje!");
            }
        }
    }
}
