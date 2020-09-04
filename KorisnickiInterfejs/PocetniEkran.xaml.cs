using Biblioteka;
using MahApps.Metro;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PocetniEkran : Window
    {
        Radnik r;
        public Komunikacija k;
        public PocetniEkran(Komunikacija k,Radnik r)
        {
            InitializeComponent();
            this.r = r;
            this.k = k;
            this.Title = r.Ime + " " + r.Prezime;
        }

        private void MnUnosRadnika_Click(object sender, RoutedEventArgs e)
        {
            new UnosRadnika(r,k).ShowDialog();
        }
        

        private void MnUnosOdeljenja_Click(object sender, RoutedEventArgs e)
        {
            new UnosOdeljenja(r,k).ShowDialog();
        }

        private void MnUnosKapija_Click(object sender, RoutedEventArgs e)
        {
            new UnosKapije(r,k).ShowDialog();
        }

        private void MnUnosLokacija_Click(object sender, RoutedEventArgs e)
        {
            new UnosLokacije(r,k).ShowDialog();
        }

        private void MnPretragaRadnika_Click(object sender, RoutedEventArgs e)
        {
            new PretragaRadnika(r,k).ShowDialog();
        }

        private void MnPretragaOdeljenja_Click(object sender, RoutedEventArgs e)
        {
            new PretragaOdeljenja(r,k).ShowDialog();
        }

        private void MnPretragaKapija_Click(object sender, RoutedEventArgs e)
        {
            new PretragaKapija(r,k).ShowDialog();
        }

        private void MnPretragaLokacija_Click(object sender, RoutedEventArgs e)
        {
            new PretragaLokacija(r,k).ShowDialog();
        }

        private void MnPretragaProlazaka_Click(object sender, RoutedEventArgs e)
        {
            new PretragaProlazaka(r,k).ShowDialog();
        }

        private void MnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MnIzvestajRadnik_Click(object sender, RoutedEventArgs e)
        {
            new IzvestajRadnik().ShowDialog();
        }

        private void MnIzvestajOdeljenje_Click(object sender, RoutedEventArgs e)
        {
            new IzvestajOdeljenje().ShowDialog();
        }

        private void MnIzvestajKapija_Click(object sender, RoutedEventArgs e)
        {
           new IzvestajKapije().ShowDialog();
        }

        private void MnIzvestajLokacija_Click(object sender, RoutedEventArgs e)
        {
            new IzvestajLokacije().ShowDialog();
        }

        private void MnIzvestajProlasci_Click(object sender, RoutedEventArgs e)
        {
            new IzvestajProlasci().ShowDialog();
        }

        private void MnOpcije_Click(object sender, RoutedEventArgs e)
        {
            new Podesavanja().ShowDialog();

        }

        private void MnOdjava_Click(object sender, RoutedEventArgs e)
        {
            string pravac = "OUT";
            SimulatorProlaska simulatorProlaska = new SimulatorProlaska(r, pravac,k);
            this.Hide();
            simulatorProlaska.ShowDialog();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime datum = DateTime.Now;
            int brojSati = k.vratiBrojSatiZaRadnika(r.Satnica);
            double brojS = brojSati;
            lblVremeOd.Text = datum.ToString("HH:mm");
            lblVremeDo.Text = datum.AddHours(brojS).ToString("HH:mm");


            if (r.Privilegija == 1)
            {
                mnStavke.Visibility = Visibility.Collapsed;
                mnIzvestaji.Visibility = Visibility.Collapsed;
                mnKontrola.Visibility = Visibility.Collapsed;

                if (!k.daLiJeRadnikSefOdeljenja(r))
                {
                    mnDnevnikRadaSefOdeljenja.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mnDnevnikRada.Visibility = Visibility.Collapsed;
                    mnDnevnikRadaSefOdeljenja.Visibility = Visibility.Visible;
                }


            }
            if (r.Privilegija == 2)
            {
                mnDnevnikRada.Visibility = Visibility.Collapsed;
                mnDnevnikRadaSefOdeljenja.Visibility = Visibility.Collapsed;
                mnParoviINOUT.Visibility = Visibility.Collapsed;
            }
            if (r.Privilegija == 3)
            {
                mnPauza.Visibility = Visibility.Collapsed;
                mnOdmor.Visibility = Visibility.Collapsed;
                mnDnevnikRada.Visibility = Visibility.Collapsed;
                mnDnevnikRadaSefOdeljenja.Visibility = Visibility.Collapsed;
                mnStandardniIzvestaji.Visibility = Visibility.Collapsed;
                mnPropusnice.Visibility = Visibility.Collapsed;
                mnKorisnik1Separator.Visibility = Visibility.Collapsed;
                mnKorisnik1Separator1.Visibility = Visibility.Collapsed;
               
                
            }
        }

        private void MnPodaci_Click(object sender, RoutedEventArgs e)
        {
            new PregledPrijavljenogKorisnika(r, k).ShowDialog();
        }

        private void MnPauza_Click(object sender, RoutedEventArgs e)
        {
            new PauzaOdbrojavanje(r, k).ShowDialog();
        }

        private void MnPoruke_Click(object sender, RoutedEventArgs e)
        {
            new Poruke(r,k).ShowDialog();
        }
        

        private void MnRadniciOdeljenja_Click(object sender, RoutedEventArgs e)
        {
            new PremestiRadnikeUOdeljenje(r, k).ShowDialog();
        }

        private void MnParoviINOUT_Click(object sender, RoutedEventArgs e)
        {
            new KontrolaProlazakaInOut(r, k).ShowDialog();
        }
        
        private void MnPraznici_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MnPropusnice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnUnosSatnice_Click(object sender, RoutedEventArgs e)
        {
            new UnosSatnice(r, k).ShowDialog();
        }

        private void MnPretragaSatnice_Click(object sender, RoutedEventArgs e)
        {
            new PretragaSatnica(r, k).ShowDialog();
        }

        private void MnUnosPraznika_Click(object sender, RoutedEventArgs e)
        {
            new UnosPraznika(r, k).ShowDialog();
        }

        private void MnPretragaPraznika_Click(object sender, RoutedEventArgs e)
        {
            new PretragaPraznika(r, k).ShowDialog();
        }

        private void MnUnosPauza_Click(object sender, RoutedEventArgs e)
        {
            new UnosPauze(r, k).ShowDialog();
        }

        private void MnPretragaPauza_Click(object sender, RoutedEventArgs e)
        {
            new PretragaPauza(r, k).ShowDialog();
        }
        

        private void MnPretragaGodisnjihOdmora_Click(object sender, RoutedEventArgs e)
        {
            new PretragaGodisnjegOdmora(r, k).ShowDialog();
        }

        private void MnMesecniIzvestaj_Click(object sender, RoutedEventArgs e)
        {
            //new IzvestajMesecni().ShowDialog();
        }

        private void MnIzvestajGodisnjiOdmori_Click(object sender, RoutedEventArgs e)
        {
            new IzvestajGodisnjiOdmor().ShowDialog();
        }
        

        private void MnUnosPropusnice_Click(object sender, RoutedEventArgs e)
        {
            //new UnosPropusnice(r).ShowDialog();
        }

        private void MnPretragaPropusnica_Click(object sender, RoutedEventArgs e)
        {
            new PretragaPropusnica(r, k).ShowDialog();
        }

        private void MnDnevnikRada_Click(object sender, RoutedEventArgs e)
        {
            if (k.daLiJeDnevnikRadaUnesen(r))
            {
                MessageBox.Show("Vec ste uneli dnevnik rada za ovu nedelju!");
            }
            else
            {
                new DnevnikRada(r, k).ShowDialog();
            }
            
        }

        private void MnOdmor_Click(object sender, RoutedEventArgs e)
        {
            new Odmor(r, k).ShowDialog();
        }

        private void MnPorukeDirektor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnUnos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnDnevnikRadaSefOdeljenja_Click(object sender, RoutedEventArgs e)
        {
            new DnevnikRadaSefOdeljenja(r, k).ShowDialog();
        }

        private void MnPauza_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult rezultat = MessageBox.Show("Da li zelite da se izlogujete?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (rezultat)
            {
                case MessageBoxResult.Yes:
                    string pravac = "OUT";
                    SimulatorProlaska simulatorProlaska = new SimulatorProlaska(r, pravac, k);
                    this.Hide();
                    simulatorProlaska.ShowDialog();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
