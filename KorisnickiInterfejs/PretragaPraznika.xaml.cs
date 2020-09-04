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
    /// Interaction logic for PretragaPraznika.xaml
    /// </summary>
    public partial class PretragaPraznika : Window
    {
        private Radnik r;
        Komunikacija k;       
        public PretragaPraznika(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            dataGrid.ItemsSource = k.vratiListuPraznika();
        }

        private void BtnPretragaPraznika_Click(object sender, RoutedEventArgs e)
        {
            string naziv;
            DateTime datum;
            DateTime pom;
            naziv = tbNaziv.Text;
            try
            {
                DateTime.TryParseExact(tbDatumPraznika.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.AdjustToUniversal, out pom);
            }
            catch (Exception)
            {

                throw;
            }
            

            datum = pom;
            dataGrid.ItemsSource = k.vratiPraznikePretraga(naziv, datum);
        }

        private void BtnObrisiPraznik_Click(object sender, RoutedEventArgs e)
        {
            int obrisan = k.obrisiPraznik(dataGrid.SelectedItem as Praznik);
            if (obrisan == 0)
            {
                MessageBox.Show("Neuspesno brisanje praznika!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno brisanje praznika!");
            }
            dataGrid.ItemsSource = k.vratiListuPraznika();
        }

        private void BtnPregledPraznika_Click(object sender, RoutedEventArgs e)
        {
            Praznik p = dataGrid.SelectedItem as Praznik;
            new PregledPraznika(p,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuPraznika();
        }

        private void BtnDodajPraznik_Click(object sender, RoutedEventArgs e)
        {
            new UnosPraznika(r,k).ShowDialog();
        }
    }
}
