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
    /// Interaction logic for PregledKapija.xaml
    /// </summary>
    public partial class PregledKapija : Window
    {
        Kapija k;
        Komunikacija kom;
        public PregledKapija(Kapija k,Komunikacija komunikacija)
        {
            InitializeComponent();
            this.k = k;
            kom = komunikacija;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbKapijaID.Text = Convert.ToString(k.KapijaID);
            tbNaziv.Text = k.Naziv;
            tbOpis.Text = k.Opis;
            tbLokacija.Text = Convert.ToString(k.Lokacija);
        }

        private void BtnIzmeniKapiju_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaKapije(k,kom).ShowDialog();
        }
    }
}
