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
    /// Interaction logic for PregledRadnika.xaml
    /// </summary>
    public partial class PregledRadnika : Window
    {
        Radnik r;
        Komunikacija k;
        public PregledRadnika(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbRadnikID.Text = Convert.ToString(r.RadnikID);
            tbIme.Text = r.Ime;
            tbPrezime.Text = r.Prezime;
            tbDatumRodjenja.Text = Convert.ToString(r.DatumRodjenja);
            tbPosao.Text = r.Posao;
            tbPlata.Text = Convert.ToString(r.Plata);
            tbUsername.Text = r.Username;
            tbPassword.Text = r.Password;
            tbOdeljenje.Text = Convert.ToString(r.Odeljenje);
            tbPrivilegija.Text = Convert.ToString(r.Privilegija);
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

        private void BtnIzmeniRadnika_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaRadnika(r,k).ShowDialog();
        }
    }
}
