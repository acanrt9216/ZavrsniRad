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
    /// Interaction logic for DnevnikRadaSefOdeljenja.xaml
    /// </summary>
    public partial class DnevnikRadaSefOdeljenja : Window
    {
        Radnik r;
        Komunikacija k;
        public DnevnikRadaSefOdeljenja(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            dataGrid.ItemsSource = k.vratiDnevnikeZaSefa(r);
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void DataGrid_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            Dnevnik dnevnik = dataGrid.SelectedItem as Dnevnik;
            if (dnevnik == null)
            {
                dataGrid.ItemsSource = k.vratiDnevnikeZaSefa(r);
            }
            else
            {
                tbRadnik.Text = Convert.ToString(dnevnik.Radnik);
                tbPonedeljak.Text = dnevnik.Ponedeljak;
                tbUtorak.Text = dnevnik.Utorak;
                tbSreda.Text = dnevnik.Sreda;
                tbCetvrtak.Text = dnevnik.Cetvrtak;
                tbPetak.Text = dnevnik.Petak;
            }
            

        }

        private void BtnPotvrdiDnevnik_Click(object sender, RoutedEventArgs e)
        {
            Dnevnik dnevnik = dataGrid.SelectedItem as Dnevnik;

            int obrisan = k.obrisiDnevnik(dnevnik);
            if (obrisan == 0)
            {
                MessageBox.Show("Neuspesna potvrda dnevnika!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno potvrdjen dnevnik!");
            }
            dataGrid.ItemsSource=k.vratiDnevnikeZaSefa(r);
            tbRadnik.Text = "";
            tbPonedeljak.Text = "";
            tbUtorak.Text = "";
            tbSreda.Text = "";
            tbCetvrtak.Text = "";
            tbPetak.Text = "";
        }

        private void DataGrid_Selected_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
