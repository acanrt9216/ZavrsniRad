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
    /// Interaction logic for PregledOdeljenje.xaml
    /// </summary>
    public partial class PregledOdeljenje : Window
    {
        Odeljenje o;
        Radnik r;
        Komunikacija k;
        public PregledOdeljenje(Radnik r, Odeljenje o,Komunikacija kom)
        {
            InitializeComponent();
            this.o = o;
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbOdeljenjeID.Text = Convert.ToString(o.OdeljenjeID);
            tbNaziv.Text = o.Naziv;
            tbSefOdeljenja.Text = Convert.ToString(o.SefOdeljenja);
            tbBrojZaposlenih.Text = Convert.ToString(o.BrojZaposlenih);
        }

        private void BtnIzmeniOdeljenje_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaOdeljenja(r,o,k).ShowDialog();
        }
    }
}
