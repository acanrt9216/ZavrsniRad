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
    /// Interaction logic for PregledPraznika.xaml
    /// </summary>
    public partial class PregledPraznika : Window
    {
        private Praznik p;
        Komunikacija k;

        public PregledPraznika(Praznik p,Komunikacija kom)
        {
            InitializeComponent();
            this.p = p;
            k = kom;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbPraznikID.Text = Convert.ToString(p.PraznikID);
            tbNaziv.Text = p.Naziv;
            tbDatumPraznika.Text = Convert.ToString(p.DatumPraznika.ToShortDateString());
        }

        private void BtnIzmeniPraznik_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaPraznika(p,k).ShowDialog();
            
        }

        
    }
}
