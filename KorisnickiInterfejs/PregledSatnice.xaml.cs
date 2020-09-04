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
    /// Interaction logic for PregledSatnice.xaml
    /// </summary>
    public partial class PregledSatnice : Window
    {
        private Satnica s;
        Komunikacija k;
        public PregledSatnice(Satnica s,Komunikacija kom)
        {
            InitializeComponent();
            this.s = s;
            k = kom;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbSatnicaID.Text = Convert.ToString(s.SatnicaID);
            tbNaziv.Text = s.Naziv;
            tbOpis.Text = s.Opis;
            tbBrojSati.Text = Convert.ToString(s.BrojSati);
        }

        private void BtnIzmeniSatnicu_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaSatnice(s,k).ShowDialog();
        }

        
    }
}
