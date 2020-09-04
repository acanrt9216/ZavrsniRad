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
    /// Interaction logic for IzmenaRadnika.xaml
    /// </summary>
    public partial class IzmenaRadnika : Window
    {
        Radnik r;
        Komunikacija k;
        public IzmenaRadnika(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            cmbPrivilegija.Items.Add("Radnik");
            cmbPrivilegija.Items.Add("Administrator");
            cmbPrivilegija.Items.Add("Direktor");
            tbRadnikID.Text = Convert.ToString(r.RadnikID);
            tbIme.Text = r.Ime;
            tbPrezime.Text = r.Prezime;
            tbDatumRodjenja.Text = Convert.ToString(r.DatumRodjenja);
            tbPosao.Text = r.Posao;
            tbPlata.Text = Convert.ToString(r.Plata);
            tbUsername.Text = r.Username;
            tbPassword.Text = r.Password;
            cmbOdeljenje.ItemsSource = k.vratiListuOdeljenja();
        }
        private void BtnIzmeniRadnika_Click(object sender, RoutedEventArgs e)
        {
            Radnik ra = new Radnik();
            ra.RadnikID = Convert.ToInt32(tbRadnikID.Text);
            if (!string.IsNullOrEmpty(tbIme.Text))
            {
                ra.Ime = tbIme.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti ime radnika!");
                tbIme.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPrezime.Text))
            {
                ra.Prezime = tbPrezime.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti prezime radnika!");
                tbPrezime.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbDatumRodjenja.Text))
            {
                ra.DatumRodjenja = Convert.ToDateTime(tbDatumRodjenja.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti datum rodjenja radnika!");
                tbDatumRodjenja.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPosao.Text))
            {
                ra.Posao = tbPosao.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti posao radnika!");
                tbPosao.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPlata.Text))
            {
                ra.Plata = Convert.ToInt32(tbPlata.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti platu radnika!");
                tbPlata.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbUsername.Text))
            {
                ra.Username = tbUsername.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti username radnika!");
                tbUsername.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                ra.Password = tbPassword.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti password radnika!");
                tbPassword.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbOdeljenje.Text))
            {
                ra.Odeljenje = cmbOdeljenje.SelectedItem as Odeljenje;
            }
            else
            {
                MessageBox.Show("Morate odabrati odeljenje radnika!");
                cmbOdeljenje.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbPrivilegija.Text))
            {
                if (cmbPrivilegija.Text == "Radnik")
                {
                    ra.Privilegija = 1;
                }
                else
                if (cmbPrivilegija.Text == "Administrator")
                {
                    ra.Privilegija = 2;
                }
                else
                if (cmbPrivilegija.Text == "Direktor")
                {
                    ra.Privilegija = 3;
                }

            }
            else
            {
                MessageBox.Show("Morate odabrati privilegiju radnika!");
                cmbPrivilegija.Focus();
                return;
            }
            
            if (!(ra.Odeljenje.Naziv == r.Odeljenje.Naziv))
            {
                int brojPlus = Broker.dajSesiju().vratiBrojZaposlenihZaIzmenuRadnika(ra.Odeljenje) + 1;
                int brojMinus = Broker.dajSesiju().vratiBrojZaposlenihZaIzmenuRadnika(r.Odeljenje) - 1;
                k.izmeniBrojZaposlenihUOdeljenju(ra.Odeljenje, brojPlus);
                k.izmeniBrojZaposlenihUOdeljenju(r.Odeljenje, brojMinus);
            }




            int a = k.izmeniRadnika(ra);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno izmenjen radnik!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjen radnik!");
            }
        }
    }
}
