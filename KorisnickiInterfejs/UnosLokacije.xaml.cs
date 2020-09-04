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
    /// Interaction logic for UnosLokacije.xaml
    /// </summary>
    public partial class UnosLokacije : Window
    {
        private Radnik r;
        Komunikacija k;
        
        public UnosLokacije(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void BtnSacuvajLokaciju_Click(object sender, RoutedEventArgs e)
        {
            Lokacija l = new Lokacija();
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                l.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli naziv!");
                tbNaziv.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(tbOpis.Text))
            {
                l.Opis = tbOpis.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli opis!");
                tbOpis.Focus();
                return;
            }
            

            int a = k.sacuvajLokaciju(l);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno cuvanje lokacije!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno sacuvana lokacija!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
