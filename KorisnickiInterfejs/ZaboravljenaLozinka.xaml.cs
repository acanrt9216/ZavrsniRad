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
    /// Interaction logic for ZaboravljenaLozinka.xaml
    /// </summary>
    public partial class ZaboravljenaLozinka : Window
    {
        Komunikacija k;
        public ZaboravljenaLozinka(Komunikacija kom)
        {
            InitializeComponent();
            k = kom;
            
        }

        private void BtnVratiSifru_Click(object sender, RoutedEventArgs e)
        {
            Radnik r = new Radnik();
            if (!string.IsNullOrEmpty(tbIme.Text))
            {
                r.Ime = tbIme.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli ime!");
                tbIme.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPrezime.Text))
            {
                r.Prezime = tbPrezime.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli prezime!");
                tbPrezime.Focus();
                return;
            }
            
            Radnik radnik = new Radnik();
            radnik = k.vratiZaboravljenuLozinku(r);
            MessageBox.Show("Vase korisnicko ime je: (" + radnik.Username + ") ,a lozinka je: (" + radnik.Password + ")");
            this.Close();
        }
    }
}
