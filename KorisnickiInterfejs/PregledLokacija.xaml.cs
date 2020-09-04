using Biblioteka;
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
    /// Interaction logic for PregledLokacija.xaml
    /// </summary>
    public partial class PregledLokacija : Window
    {
        Lokacija l;
        Komunikacija k;
        public PregledLokacija(Lokacija l,Komunikacija kom)
        {
            InitializeComponent();
            this.l = l;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbLokacijaID.Text = Convert.ToString(l.LokacijaID);
            tbNaziv.Text = l.Naziv;
            tbOpis.Text = l.Opis;
        }

        private void BtnIzmeniLokaciju_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaLokacije(l,k).ShowDialog();
        }
    }
}
