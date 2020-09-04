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
    /// Interaction logic for PretragaPropusnica.xaml
    /// </summary>
    public partial class PretragaPropusnica : Window
    {
        Radnik r;
        Komunikacija k;
        public PretragaPropusnica(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            dataGrid.ItemsSource = k.vratiListuPropusnica();
        }

        private void BtnPregledPropusnice_Click(object sender, RoutedEventArgs e)
        {
            Propusnica p = dataGrid.SelectedItem as Propusnica;
            new PregledPropusnice(p,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuPropusnica();
        }

        private void BtnObrisiPropusnicu_Click(object sender, RoutedEventArgs e)
        {
            int obrisan = k.obrisiPropusnicu(dataGrid.SelectedItem as Propusnica);
            if (obrisan == 0)
            {
                MessageBox.Show("Neuspesno brisanje propusnice!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno obrisana propusnica!");
            }
            dataGrid.ItemsSource = k.vratiListuPropusnica();
        }

        private void BtnDodajPropusnicu_Click(object sender, RoutedEventArgs e)
        {
            new UnosPropusnice(r,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuPropusnica();
        }

        private void BtnPretragaPropusnice_Click(object sender, RoutedEventArgs e)
        {
            string ime;
            string prezime;
            string razlog;
            DateTime pom;
            DateTime datum;
            ime = tbIme.Text;
            prezime = tbPrezime.Text;

            razlog = tbRazlog.Text;
            try
            {
                DateTime.TryParse(tbDatum.Text, null, System.Globalization.DateTimeStyles.None, out pom);
                datum = pom;
            }
            catch (Exception)
            {

                throw;
            }
            if (tbIme.Text == "" && tbPrezime.Text == "" && tbRazlog.Text == "" && tbDatum.Text == "")
            {
                dataGrid.ItemsSource = k.vratiListuPropusnica();
            }
            else
            {
                dataGrid.ItemsSource = k.vratiPropusnicePretraga(ime, prezime ,razlog, datum);
            }
        }
    }
}
