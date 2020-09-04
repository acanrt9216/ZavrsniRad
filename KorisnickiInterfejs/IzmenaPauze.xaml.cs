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
    /// Interaction logic for IzmenaPauze.xaml
    /// </summary>
    public partial class IzmenaPauze : Window
    {
        private Pauza p;
        Komunikacija k;
        public IzmenaPauze(Pauza p,Komunikacija kom)
        {
            InitializeComponent();
            this.p = p;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbPauzaID.Text = Convert.ToString(p.PauzaID);
            tbNaziv.Text = p.Naziv;
            tbDuzinaPauze.Text = Convert.ToString(p.DuzinaPauze);
        }

        private void BtnIzmenaPauze_Click(object sender, RoutedEventArgs e)
        {
            Pauza pa = new Pauza();
            pa.PauzaID = Convert.ToInt32(tbPauzaID.Text);
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {
                pa.Naziv = tbNaziv.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti naziv pauze!");
                tbNaziv.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbDuzinaPauze.Text))
            {
                pa.DuzinaPauze = Convert.ToInt32(tbDuzinaPauze.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti duzinu pauze!");
                tbDuzinaPauze.Focus();
                return;
            }
            
            

            int izmenjen = k.izmeniPauzu(pa);
            if (izmenjen == 0)
            {
                MessageBox.Show("Neuspesno izmenjena pauza!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjena pauza!");
            }
            this.Close();
        }
    }
}
