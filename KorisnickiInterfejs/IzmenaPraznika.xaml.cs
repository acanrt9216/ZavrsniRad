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
    /// Interaction logic for IzmenaPraznika.xaml
    /// </summary>
    public partial class IzmenaPraznika : Window
    {
        private Praznik p;
        Komunikacija k;       

        public IzmenaPraznika(Praznik p,Komunikacija kom)
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

        private void BtnIzmenaPraznika_Click(object sender, RoutedEventArgs e)
        {
            Praznik pr = new Praznik();
            pr.PraznikID = Convert.ToInt16(tbPraznikID.Text);
            if (!string.IsNullOrEmpty(tbNaziv.Text))
            {

            }
            else
            {
                MessageBox.Show("Morate uneti naziv praznika!");
                tbNaziv.Focus();
                return;
            }
            pr.Naziv = tbNaziv.Text;
            pr.DatumPraznika = Convert.ToDateTime(tbDatumPraznika.Text);
            int izmenjen = k.izmeniPraznik(pr);
            if (izmenjen == 0)
            {
                MessageBox.Show("Neuspesno izmenjen praznik!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjen praznik!");
            }
        }
    }
}
