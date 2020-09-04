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
    /// Interaction logic for PretragaKapija.xaml
    /// </summary>
    public partial class PretragaKapija : Window
    {
        Radnik r;
        Komunikacija kom;

        public PretragaKapija(Radnik r,Komunikacija komunikacija)
        {
            InitializeComponent();
            this.r = r;
            kom = komunikacija;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {  
            dataGrid.ItemsSource = this.kom.vratiListuKapija();
            this.Title = r.Ime + " " + r.Prezime;
        }

        private void BtnPregledKapije_Click(object sender, RoutedEventArgs e)
        {
            Kapija k = new Kapija();
            Kapija ka = dataGrid.SelectedItem as Kapija;
            if (ka != null)
            {
                k.KapijaID = ka.KapijaID;
                k.Naziv = ka.Naziv;
                k.Opis = ka.Opis;
                k.Lokacija = ka.Lokacija;
            }
            new PregledKapija(k,this.kom).ShowDialog();
            dataGrid.ItemsSource = this.kom.vratiListuKapija();
        }

        

        private void BtnObrisiKapiju_Click(object sender, RoutedEventArgs e)
        {
            Kapija k = dataGrid.SelectedItem as Kapija;
            int a = this.kom.obrisiKapiju(k);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno obrisana kapija!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno obrisana kapija!");
            }
            dataGrid.ItemsSource = this.kom.vratiListuKapija();
        }

        private void BtnPretraziKapije_Click(object sender, RoutedEventArgs e)
        {
            string naziv, opis, lokacija;
            naziv = tbNaziv.Text;
            opis = tbOpis.Text;
            lokacija = tbLokacija.Text;
            dataGrid.ItemsSource = this.kom.vratiKapijePretraga(naziv, opis, lokacija);
        }

        private void BtnDodajKapiju_Click(object sender, RoutedEventArgs e)
        {
            new UnosKapije(r,this.kom).ShowDialog();
        }
    }
}
