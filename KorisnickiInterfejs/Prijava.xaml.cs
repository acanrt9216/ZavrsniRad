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
    /// Interaction logic for Prijava.xaml
    /// </summary>
    public partial class Prijava : Window
    {
        public Komunikacija k;
        public Prijava()
        {
            InitializeComponent();
            k = new Komunikacija();
            if (k.poveziSeNaServer())
                this.Title = "Povezani ste. Prijavite se!";
        }

        private void BtnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            
            Radnik r = new Radnik();
            string pravac;
            pravac = "IN";
            r.Username = tbKorisnickoIme.Text;
            r.Password = tbLozinka.Text;

            r = k.prijava(r);
            //r = Broker.dajSesiju().prijava(r);
            if (r == null)
            {
                MessageBox.Show("Pogresno korisnicko ili lozinka!");
                tbKorisnickoIme.Clear();
                tbLozinka.Clear();
                tbKorisnickoIme.Focus();
            }
            else
            {
                SimulatorProlaska simulatorProlaska = new SimulatorProlaska(r,pravac,k);
                this.Hide();
                simulatorProlaska.ShowDialog();
                this.Close();
            }
            tbKorisnickoIme.Clear();
            tbLozinka.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            DateTime datum = DateTime.Now.Date;

            List<Praznik> listaPraznika = k.vratiListuPraznika();
            //List<Praznik> listaPraznika = Broker.dajSesiju().vratiPraznike();
            foreach (Praznik praznik in listaPraznika)
            {
                if (praznik.DatumPraznika == datum)
                {
                    Praznik p = new Praznik();
                    p = praznik;
                    if (k.daLiJeDanasPraznik(p, datum)/*Broker.dajSesiju().daLiJeDanasPraznik(p,datum)*/)
                    {
                        MessageBox.Show("Danas je neradan dan! [" + p.Naziv + "]");
                        this.Close();
                    }
                }
            }
        }

        private void BtnZaboravljenaLozinka_Click(object sender, RoutedEventArgs e)
        {

            new ZaboravljenaLozinka(k).ShowDialog();
        }

        private void BtnPropusnica_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new PropusnicaProlazak(k).ShowDialog();
            this.Close();
        }
    }
}
