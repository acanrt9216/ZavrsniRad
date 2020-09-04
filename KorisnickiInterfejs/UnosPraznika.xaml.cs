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
    /// Interaction logic for UnosPraznika.xaml
    /// </summary>
    public partial class UnosPraznika : Window
    {
        Radnik r;
        Komunikacija k;
        public UnosPraznika(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BtnSacuvajPraznik_Click(object sender, RoutedEventArgs e)
        {
            Praznik praznik = new Praznik();

            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                praznik.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli naziv praznika!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbDatumPraznika.Text))
            {
                praznik.DatumPraznika = Convert.ToDateTime(tbDatumPraznika.Text);
            }
            else
            {
                MessageBox.Show("Niste uneli datum praznika!");
                tbDatumPraznika.Focus();
                return;
            }

            int sacuvan = k.sacuvajPraznik(praznik);
            if (sacuvan == 0)
            {
                MessageBox.Show("Neuspesno cuvanje praznika!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno sacuvan praznik!");
            }
            this.Close();
        }
    }
}
