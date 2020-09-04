using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SimulatorProlaska.xaml
    /// </summary>
    public partial class SimulatorProlaska : Window
    {
        private Radnik r;
        BindingList<Prolasci> listaProlazaka;
        Komunikacija k;
        string pravac;
        public SimulatorProlaska(Radnik r,string pravac,Komunikacija k)
        {
            InitializeComponent();
            this.r = r;
            this.pravac = pravac;
            this.k = k;
            listaProlazaka = new BindingList<Prolasci>();
        }

        private void BtnSacuvajProlazak_Click(object sender, RoutedEventArgs e)
        {
            Prolasci p = new Prolasci();
            if (!string.IsNullOrEmpty(cmbRadnik.Text))
            {
                p.Radnik = cmbRadnik.SelectedItem as Radnik;
            }
            else
            {
                MessageBox.Show("Niste odabrali radnika!");
                cmbRadnik.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbPravac.Text))
            {
                p.Pravac = cmbPravac.Text;
            }
            else
            {
                MessageBox.Show("Niste odabrali pravac!");
                cmbPravac.Focus();
                return;
            }
            p.VremeProlaska = DateTime.Now;
            if (!string.IsNullOrEmpty(cmbKapija.Text))
            {
                p.Kapija = cmbKapija.SelectedItem as Kapija;
            }
            else
            {
                MessageBox.Show("Niste odabrali kapiju!");
                cmbKapija.Focus();
                return;
            }
            
            if (cmbPravac.Text == "IN")
            {
                k.posaljiNaServerProlazak(p);
                k.posaljiNaServerRadnika(r);

                PocetniEkran pocetniEkran = new PocetniEkran(k,r);
                this.Hide();
                pocetniEkran.ShowDialog();
                this.Close();
            }
            else
            {
                k.odjaviRadnika(p,r);
                Prijava prijavaForm = new Prijava();
                this.Hide();
                prijavaForm.ShowDialog();
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            DateTime datum = DateTime.Now.Date;

            
            if (pravac == "IN")
            {
                bool pom = k.daLiJeRadnikPrijavljen(r);
                if (pom == false)
                {
                    cmbPravac.Items.Add(pravac);
                    cmbKapija.ItemsSource = k.vratiListuKapija();
                    cmbRadnik.ItemsSource = k.vratiRadnikaZaComboBox(r);
                }
                else
                {
                    MessageBox.Show("Vec ste danas ulogovani na posao!");
                    this.Close();
                    new Prijava().ShowDialog();
                }
            }
            else
            {
                cmbPravac.Items.Add(pravac);
                cmbKapija.ItemsSource = k.vratiListuKapija();
                cmbRadnik.ItemsSource = k.vratiRadnikaZaComboBox(r);
            }
            

            OdmorDan o = k.vratiOdmorZaRadnika(r);
            if (!(o == null))
            {
                bool odmor = k.daLiJeRadnikNaOdmoru(o, datum);
                if (odmor)
                {
                    MessageBox.Show("Na odmoru ste!");
                    this.Close();
                    new Prijava().ShowDialog();
                }
            }
        }
    }
}
