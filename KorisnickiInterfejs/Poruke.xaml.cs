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
    /// Interaction logic for Poruke.xaml
    /// </summary>
    public partial class Poruke : Window
    {
        Radnik r;
        public Komunikacija k;
        public Poruke(Radnik r,Komunikacija k)
        {
            InitializeComponent();
            this.r = r;
            this.k = k;

        }

        private void BtnPosaljiPoruku_Click(object sender, RoutedEventArgs e)
        {
            if(cbPosaljiSvima.IsChecked == true)
            {
                Poruka p = new Poruka();
                p.Posaljilac = r;
                p.Tekst = tbPoruka.Text;
                List<Radnik> listaRadnika = cmbRadnici.ItemsSource as List<Radnik>;
                int poslato = k.sacuvajPoruke(p, listaRadnika);
                if (poslato == 0)
                {
                    MessageBox.Show("Neuspesno slanje poruka!");
                    return;
                }
                else
                {
                    MessageBox.Show("Uspesno poslate poruke!");
                    cmbRadnici.Text = "";
                    tbPoruka.Clear();
                }
            }
            else
            {
                Poruka p = new Poruka();
                p.Posaljilac = r;
                if (!string.IsNullOrEmpty(cmbRadnici.Text))
                {
                    p.Primalac = cmbRadnici.SelectedItem as Radnik;
                }
                else
                {
                    MessageBox.Show("Morate odabrati radnika kome zelite poslati poruku!");
                    cmbRadnici.Focus();
                    return;
                }

                if (!string.IsNullOrEmpty(tbPoruka.Text))
                {
                    p.Tekst = tbPoruka.Text;
                }
                else
                {
                    MessageBox.Show("Morate uneti poruku koju zelite da posaljete!");
                    tbPoruka.Focus();
                    return;
                }

                int sacuvan = k.sacuvajPoruku(p);
                if (sacuvan == 0)
                {
                    MessageBox.Show("Neuspesno poslata poruka!");
                    return;
                }
                else
                {
                    MessageBox.Show("Uspesno poslata poruka!");
                }
                cmbRadnici.Text = "";
                tbPoruka.Clear();
            }
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            if (!(r.Ime == "Direktor"))
            {
                cbPosaljiSvima.Visibility = Visibility.Collapsed;
            }
            
            cmbRadnici.ItemsSource = k.vratiListuRadnika();
            tbPrimljenePoruke.IsEnabled = false;

            List<Poruka> listaPoruka = k.vratiPorukeZaRadnika(r);
            if (listaPoruka != null)
            {
                foreach (Poruka po in listaPoruka)
                {
                    if (po.Primalac.RadnikID == r.RadnikID)
                    {
                        //if (po.Posaljilac.Ime == "Direktor")
                        //{
                        //    tbPrimljenePoruke.Foreground = Brushes.Red;
                        //    tbPrimljenePoruke.Text = po.Posaljilac.Ime + " " + po.Posaljilac.Prezime + ": " + po.Tekst + "\n\n";
                        //}
                        //else
                        //{
                        tbPrimljenePoruke.Text += po.Posaljilac.Ime + " " + po.Posaljilac.Prezime + ": " + po.Tekst + "\n\n";
                        //}

                    }
                }
            }
            
        }

        private void BtnObrisiPoruke_Click(object sender, RoutedEventArgs e)
        {
            tbPrimljenePoruke.Text = "";
            int obrisan = k.obrisiPorukeZaRadnika(r);
            if (obrisan == 0)
            {
                MessageBox.Show("Neuspesno brisanje poruka!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno obrisane poruke!");
            }
        }
    }
}
