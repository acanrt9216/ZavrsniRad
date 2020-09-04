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
    /// Interaction logic for PretragaSatnica.xaml
    /// </summary>
    public partial class PretragaSatnica : Window
    {
        private Radnik r;
        Komunikacija k;        

        public PretragaSatnica(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = k.vratiListuSatnica();
        }

        private void BtnPregledSatnice_Click(object sender, RoutedEventArgs e)
        {
            Satnica s = dataGrid.SelectedItem as Satnica;
            new PregledSatnice(s,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuSatnica();

        }

        private void BtnObrisiSatnicu_Click(object sender, RoutedEventArgs e)
        {
            int obrisan = k.obrisiSatnicu(dataGrid.SelectedItem as Satnica);
            if (obrisan == 0)
            {
                MessageBox.Show("Neuspesno obrisana satnica!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno obrisana satnica!");
            }
            dataGrid.ItemsSource = k.vratiListuSatnica();
        }

        private void BtnPretragaSatnica_Click(object sender, RoutedEventArgs e)
        {
            int pom = 0;
            string naziv;
            string opis;
            int brojSati;
            naziv = tbNaziv.Text;
            opis = tbOpis.Text;
            try
            {
                Int32.TryParse(tbBrojSati.Text, out pom);

                brojSati = pom;
            }
            catch (Exception)
            {

                throw;
            }
            
            
            List<Satnica> lista = k.vratiSatnicePretraga(naziv, opis, brojSati);
            dataGrid.ItemsSource = lista;
        }

        private void BtnDodajSatnicu_Click(object sender, RoutedEventArgs e)
        {
            new UnosSatnice(r,k).ShowDialog();
        }
    }
}
