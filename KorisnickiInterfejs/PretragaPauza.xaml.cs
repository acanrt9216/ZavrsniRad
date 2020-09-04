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
    /// Interaction logic for PretragaPauza.xaml
    /// </summary>
    public partial class PretragaPauza : Window
    {
        private Radnik r;
        Komunikacija k;
        public PretragaPauza(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            dataGrid.ItemsSource = k.vratiListuPauza();
        }

        private void BtnPretragaPauze_Click(object sender, RoutedEventArgs e)
        {
            int pom = 0;
            string naziv;
            int duzinaPauze = 0;
            naziv = tbNaziv.Text;
            try
            {
                Int32.TryParse(tbDuzinaPauze.Text, out pom);
                duzinaPauze = pom;
            }
            catch (Exception)
            {

                throw;
            }

            dataGrid.ItemsSource = k.vratiPauzePretraga(naziv, duzinaPauze);
        }

        private void BtnObrisiPauzu_Click(object sender, RoutedEventArgs e)
        {
            int obrisan = k.obrisiPauzu(dataGrid.SelectedItem as Pauza);
            if (obrisan == 0)
            {
                MessageBox.Show("Neuspesno brisanje pauze!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno brisanje pauze!");
            }
            dataGrid.ItemsSource = k.vratiListuPauza();
        }

        private void BtnPregledPauze_Click(object sender, RoutedEventArgs e)
        {
            Pauza p = dataGrid.SelectedItem as Pauza;
            new PregledPauze(p,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuPauza();
        }

        private void BtnDodajPauzu_Click(object sender, RoutedEventArgs e)
        {
            new UnosPauze(r,k).ShowDialog();
        }
    }
}
