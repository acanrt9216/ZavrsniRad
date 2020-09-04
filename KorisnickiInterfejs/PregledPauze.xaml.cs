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

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for PregledPauze.xaml
    /// </summary>
    public partial class PregledPauze : Window
    {
        private Pauza p;
        Komunikacija k;
        public PregledPauze(Pauza p,Komunikacija kom)
        {
            InitializeComponent();
            this.p = p;
            k = kom;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbPauzaID.Text = Convert.ToString(p.PauzaID);
            tbNaziv.Text = p.Naziv;
            tbDuzinaPauze.Text = Convert.ToString(p.DuzinaPauze);
        }

        private void BtnIzmeniPauzu_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaPauze(p,k).ShowDialog();
        }
    }
}
