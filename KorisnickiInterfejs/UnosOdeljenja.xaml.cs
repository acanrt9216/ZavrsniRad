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
    /// Interaction logic for UnosOdeljenja.xaml
    /// </summary>
    public partial class UnosOdeljenja : Window
    {
        private Radnik r;
        Komunikacija k;

        public UnosOdeljenja(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void BtnSacuvajOdeljenje_Click(object sender, RoutedEventArgs e)
        {
            Odeljenje o = new Odeljenje();
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                o.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli naziv odeljenja!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbSefOdeljenja.Text))
            {
                o.SefOdeljenja = cmbSefOdeljenja.SelectedItem as Radnik;
            }
            else
            {
                MessageBox.Show("Niste odabrali sefa odeljenja!");
                cmbSefOdeljenja.Focus();
                return;
            }

            o.BrojZaposlenih = 0;

            int a = k.sacuvajOdeljenje(o);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno cuvanje odeljenja!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno sacuvano odeljenje!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSefOdeljenja.ItemsSource = k.vratiListuRadnika();
        }
    }
}
