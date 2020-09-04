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
    /// Interaction logic for PretragaLokacija.xaml
    /// </summary>
    public partial class PretragaLokacija : Window
    {
        private Radnik r;
        Komunikacija kom;
        public PretragaLokacija(Radnik r,Komunikacija komunikacija)
        {
            InitializeComponent();
            this.r = r;
            kom = komunikacija;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            dataGrid.ItemsSource = this.kom.vratiListuLokacija();
        }

        private void BtnPregledLokacije_Click(object sender, RoutedEventArgs e)
        {
            Lokacija l = new Lokacija();
            Lokacija lo = dataGrid.SelectedItem as Lokacija;
            if (lo != null)
            {
                l.LokacijaID = lo.LokacijaID;
                l.Naziv = lo.Naziv;
                l.Opis = lo.Opis;
            }
            new PregledLokacija(l,this.kom).ShowDialog();
            dataGrid.ItemsSource = this.kom.vratiListuLokacija();
        }

        private void BtnObrisiLokaciju_Click(object sender, RoutedEventArgs e)
        {
            Lokacija l = dataGrid.SelectedItem as Lokacija;
            int a = this.kom.obrisiLokaciju(l);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno obrisana lokacija!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno obrisana lokacija!");
            }
            dataGrid.ItemsSource = this.kom.vratiListuLokacija();
        }

        private void BtnPretragaLokacija_Click(object sender, RoutedEventArgs e)
        {
            string naziv, opis;
            naziv = tbNaziv.Text;
            opis = tbOpis.Text;
            dataGrid.ItemsSource = this.kom.vratiLokacijePretraga(naziv,opis);
        }

        private void BtnDodajLokaciju_Click(object sender, RoutedEventArgs e)
        {
            new UnosLokacije(r,this.kom).ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
