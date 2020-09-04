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
    /// Interaction logic for UnosKapije.xaml
    /// </summary>
    public partial class UnosKapije : Window
    {
        private Radnik r;
        Komunikacija kom;
        public UnosKapije(Radnik r,Komunikacija komunikacija)
        {
            InitializeComponent();
            this.r = r;
            kom = komunikacija;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            cmbLokacija.ItemsSource = kom.vratiListuLokacija();
        }

        private void BtnSacuvajKapiju_Click(object sender, RoutedEventArgs e)
        {
            Kapija k = new Kapija();
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                k.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli naziv kapije!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbOpis.Text))
            {
                k.Opis = tbOpis.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli opis!");
                tbOpis.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbLokacija.Text))
            {
                k.Lokacija = cmbLokacija.SelectedItem as Lokacija;
            }
            else
            {
                MessageBox.Show("Niste odabrali lokaciju!");
                cmbLokacija.Focus();
                return;
            }
            int a = kom.sacuvajKapiju(k);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno cuvanje kapije!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno sacuvana kapija!");
            }
        }
    }
}
