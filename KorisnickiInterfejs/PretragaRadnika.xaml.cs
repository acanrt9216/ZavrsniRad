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
    /// Interaction logic for PretragaRadnika.xaml
    /// </summary>
    public partial class PretragaRadnika : Window
    {
        private Radnik r;
        Komunikacija k;


        public PretragaRadnika(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k=kom;
        }

        private void BtnPretrazi_Click(object sender, RoutedEventArgs e)
        {

            DateTime s;
            string ime;
            string prezime;
            string posao;
            string odeljenje;

            ime = tbIme.Text;
            prezime = tbPrezime.Text;
            try
            {
                DateTime.TryParseExact(tbDatumRodjenja.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.AdjustToUniversal, out s);
            }
            catch (Exception)
            {

                throw;
            }
            posao = tbPosao.Text;
            odeljenje = tbOdeljenje.Text;

            dataGrid.ItemsSource = k.vratiRadnikePretraga(ime,prezime,s,posao,odeljenje);
            if (tbIme.Text == "" && tbPrezime.Text=="" && tbDatumRodjenja.Text == "" && tbPosao.Text == "" && tbOdeljenje.Text == "")
            {
                dataGrid.ItemsSource = k.vratiListuRadnika();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            dataGrid.ItemsSource = k.vratiListuRadnika();
        }

        private void BtnPregledRadnika_Click(object sender, RoutedEventArgs e)
        {
            Radnik ra = dataGrid.SelectedItem as Radnik;
            if (ra != null)
            {
                r.RadnikID = ra.RadnikID;
                r.Ime = ra.Ime;
                r.Prezime = ra.Prezime;
                r.DatumRodjenja = ra.DatumRodjenja;
                r.Posao = ra.Posao;
                r.Plata = ra.Plata;
                r.Username = ra.Username;
                r.Password = ra.Password;
                r.Odeljenje = ra.Odeljenje;
                r.Privilegija = ra.Privilegija;
            }
            new PregledRadnika(r,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuRadnika();
        }

        private void BtnObrisiRadnika_Click(object sender, RoutedEventArgs e)
        {
            Radnik r = dataGrid.SelectedItem as Radnik;
            int brojZaposlenih = k.vratiBrojZaposlenihZaOdeljenje(r.Posao);
            int a = k.obrisiRadnika(r);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno obrisan radnik!");
                return;
            }
            else
            {
                k.izmeniBrojZaposlenihUOdeljenju(r.Odeljenje, brojZaposlenih);
                MessageBox.Show("Uspesno obrisan radnik!");
            }
            dataGrid.ItemsSource = k.vratiListuRadnika();
        }

        private void BtnDodajRadnika_Click(object sender, RoutedEventArgs e)
        {
            new UnosRadnika(r,k).ShowDialog();
        }
    }
}
