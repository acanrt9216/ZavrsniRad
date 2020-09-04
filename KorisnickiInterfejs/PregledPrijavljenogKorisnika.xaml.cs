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
    /// Interaction logic for PregledPrijavljenogKorisnika.xaml
    /// </summary>
    public partial class PregledPrijavljenogKorisnika : Window
    {
        Radnik r;
        Komunikacija k;
        public PregledPrijavljenogKorisnika(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            tbRadnikID.Text = Convert.ToString(r.RadnikID);
            tbIme.Text = r.Ime;
            tbPrezime.Text = r.Prezime;
            tbDatumRodjenja.Text = Convert.ToString(r.DatumRodjenja.ToShortDateString());
            tbPosao.Text = r.Posao;
            tbPlata.Text = Convert.ToString(r.Plata);
            tbUsername.Text = r.Username;
            tbPassword.Text = r.Password;
            tbOdeljenje.Text = Convert.ToString(r.Odeljenje);
            tbPrivilegija.Text = Convert.ToString(r.Privilegija);
            tbOdmor.Text = Convert.ToString(Broker.dajSesiju().vratiBrojSlobodnihDana(r));
            if (tbPrivilegija.Text == "1")
            {
                tbPrivilegija.Text = "Radnik";
            }
            if (tbPrivilegija.Text == "2")
            {
                tbPrivilegija.Text = "Administrator";
            }
            if (tbPrivilegija.Text == "3")
            {
                tbPrivilegija.Text = "Direktor";
            }
        }
    }
}
