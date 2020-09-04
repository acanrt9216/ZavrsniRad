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
    /// Interaction logic for PremestiRadnikeUOdeljenje.xaml
    /// </summary>
    public partial class PremestiRadnikeUOdeljenje : Window
    {
        Radnik r;
        Komunikacija k;       
        public PremestiRadnikeUOdeljenje(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            cmbIzOdeljenja.ItemsSource = k.vratiListuOdeljenja();
            cmbUOdeljenje.ItemsSource = k.vratiListuOdeljenja();
        }

        private void BtnPremesti_Click(object sender, RoutedEventArgs e)
        {
            Radnik r = lvRadnici.SelectedItem as Radnik;
            Odeljenje oIz = cmbIzOdeljenja.SelectedItem as Odeljenje;
            Odeljenje oU = cmbUOdeljenje.SelectedItem as Odeljenje;
            k.izmeniOdeljenjeRadnika(r, oU);
            
            lvRadnici.ItemsSource = k.vratiRadnikaZaOdeljenje(oIz);
            lvOdeljenje.ItemsSource = k.vratiRadnikaZaOdeljenje(oU);
            int brojPlus = lvOdeljenje.Items.Count;
            int brojMinus = lvRadnici.Items.Count;
            k.izmeniBrojZaposlenihUOdeljenju(oIz, brojMinus);
            k.izmeniBrojZaposlenihUOdeljenju(oU, brojPlus);
        }

        private void CmbIzOdeljenja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Odeljenje o = cmbIzOdeljenja.SelectedItem as Odeljenje;
            lvRadnici.ItemsSource = k.vratiRadnikaZaOdeljenje(o);
        }

        private void CmbUOdeljenje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Odeljenje o = cmbUOdeljenje.SelectedItem as Odeljenje; 
            lvOdeljenje.ItemsSource = k.vratiRadnikaZaOdeljenje(o);
        }
    }
}
