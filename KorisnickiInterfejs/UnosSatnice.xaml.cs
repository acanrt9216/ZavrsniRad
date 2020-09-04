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
    /// Interaction logic for UnosSatnice.xaml
    /// </summary>
    public partial class UnosSatnice : Window
    {
        private Radnik r;
        Komunikacija k;        
        public UnosSatnice(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void BtnSacuvajSatnicu_Click(object sender, RoutedEventArgs e)
        {
            Satnica s = new Satnica();
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                s.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli naziv satnice!");
                tbNaziv.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(tbOpis.Text))
            {
                s.Opis = tbOpis.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli opis satnice!");
                tbOpis.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbBrojSati.Text))
            {
                s.BrojSati = Convert.ToInt32(tbBrojSati.Text);
            }
            else
            {
                MessageBox.Show("Niste uneli broj sati satnice!");
                tbBrojSati.Focus();
                return;
            }
            
            
            int sacuvan = k.sacuvajSatnicu(s);
            if (sacuvan == 0)
            {
                MessageBox.Show("Neuspesno cuvanje satnice!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno sacuvana satnica!");
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
