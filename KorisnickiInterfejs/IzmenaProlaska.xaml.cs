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
    /// Interaction logic for IzmenaProlaska.xaml
    /// </summary>
    public partial class IzmenaProlaska : Window
    {
        Prolasci p;
        Komunikacija k;
        public IzmenaProlaska(Prolasci p,Komunikacija kom)
        {
            InitializeComponent();
            this.p = p;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            tbProlazakID.Text = Convert.ToString(p.ProlazakID);
            cmbRadnik.ItemsSource = k.vratiListuRadnika();
            cmbPravac.Items.Add("IN");
            cmbPravac.Items.Add("OUT");
            tbVremeProlaska.Text = Convert.ToString(p.VremeProlaska);
            cmbKapija.ItemsSource = k.vratiListuKapija();
        }

        private void BtnIzmeniProlazak_Click(object sender, RoutedEventArgs e)
        {
            Prolasci pr = new Prolasci();
            pr.ProlazakID = Convert.ToInt32(tbProlazakID.Text);
            if (!string.IsNullOrEmpty(cmbRadnik.Text))
            {
                pr.Radnik = cmbRadnik.SelectedItem as Radnik;
            }
            else
            {
                MessageBox.Show("Morate odabrati radnika!");
                cmbRadnik.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbPravac.Text))
            {
                pr.Pravac = cmbPravac.Text;
            }
            else
            {
                MessageBox.Show("Morate odabrati pravac!");
                cmbPravac.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbVremeProlaska.Text))
            {
                pr.VremeProlaska = Convert.ToDateTime(tbVremeProlaska.Text);
            }
            else
            {
                MessageBox.Show("Morate odabrati vreme prolaska!");
                tbVremeProlaska.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbKapija.Text))
            {
                pr.Kapija = cmbKapija.SelectedItem as Kapija;
            }
            else
            {
                MessageBox.Show("Morate odabrati kapiju!");
                cmbKapija.Focus();
                return;
            }
            
            int a = k.izmeniProlazak(pr);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno izmenjen prolazak!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjen prolazak!");
            }
        }
    }
}
