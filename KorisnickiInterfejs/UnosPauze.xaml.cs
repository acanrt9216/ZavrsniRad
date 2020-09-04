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
    /// Interaction logic for UnosPauze.xaml
    /// </summary>
    public partial class UnosPauze : Window
    {
        private Radnik r;
        Komunikacija k;
        public UnosPauze(Radnik r,Komunikacija k)
        {

            InitializeComponent();
            this.r = r;
            this.k = k;
        }

        private void BtnSacuvajPauzu_Click(object sender, RoutedEventArgs e)
        {
            Pauza p = new Pauza();
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                p.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli naziv pauze!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbDuzinaPauze.Text))
            {
                p.DuzinaPauze = Convert.ToInt32(tbDuzinaPauze.Text);
            }
            else
            {
                MessageBox.Show("Niste uneli duzinu pauze!");
                tbDuzinaPauze.Focus();
                return;
            }
            
            int sacuvan = k.sacuvajPauzu(p);
            if (sacuvan == 0)
            {
                MessageBox.Show("Neuspesno cuvanje praznika!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno cuvanje podataka!");
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
