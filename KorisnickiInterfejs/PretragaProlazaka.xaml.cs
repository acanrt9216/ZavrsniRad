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
    /// Interaction logic for PretragaProlazaka.xaml
    /// </summary>
    public partial class PretragaProlazaka : Window
    {
        private Radnik r;
        Komunikacija k;
        public PretragaProlazaka(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }
        public static Task proces()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
            });
        }

        public async void pozoviProces()
        {
            await proces();
            dataGrid.ItemsSource = k.vratiListuProlazaka();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            pozoviProces();
        }

        private void BtnPregledProlaska_Click(object sender, RoutedEventArgs e)
        {
            Prolasci p = new Prolasci();
            Prolasci pr = dataGrid.SelectedItem as Prolasci;
            if (pr != null)
            {
                p.ProlazakID = pr.ProlazakID;
                p.Radnik = pr.Radnik;
                p.Pravac = pr.Pravac;
                p.VremeProlaska = pr.VremeProlaska;
                p.Kapija = pr.Kapija;
            }
            new PregledProlazaka(p,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuProlazaka();
        }

        private void BtnObrisiProlazak_Click(object sender, RoutedEventArgs e)
        {
            Prolasci p = dataGrid.SelectedItem as Prolasci;
            int a = k.obrisiProlazak(p);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno brisanje prolaska!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno obrisan prolazak!");
            }
            dataGrid.ItemsSource = k.vratiListuProlazaka();
        }

        private void BtnPretraziProlazak_Click(object sender, RoutedEventArgs e)
        {
            
            string tbime,ime, prezime, pravac, kapija;
            tbime = tbRadnik.Text;
            string[] imeprezime = tbime.Split(' ');
            
            ime = imeprezime[0];
            prezime = imeprezime[1];
            pravac = tbPravac.Text;
            kapija = tbKapija.Text;
            
            dataGrid.ItemsSource = k.vratiProlaskePretraga(ime,prezime,pravac,kapija);
        }
    }
}
