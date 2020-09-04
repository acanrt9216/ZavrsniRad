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
    /// Interaction logic for UnosRadnika.xaml
    /// </summary>
    public partial class UnosRadnika : Window
    {
        private Radnik r;
        Komunikacija k;

        public UnosRadnika(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void BtnSacuvajRadnika_Click(object sender, RoutedEventArgs e)
        {
            Radnik r = new Radnik();
            if (!string.IsNullOrEmpty(tbIme.Text))
            {
                r.Ime = tbIme.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli ime radnika!");
                tbIme.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPrezime.Text))
            {
                r.Prezime = tbPrezime.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli prezime radnika!");
                tbPrezime.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbDatumRodjenja.Text))
            {
                r.DatumRodjenja = Convert.ToDateTime(tbDatumRodjenja.Text);
            }
            else
            {
                MessageBox.Show("Niste uneli datum rodjenja za radnika!");
                tbDatumRodjenja.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPosao.Text))
            {
                r.Posao = tbPosao.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli posao za radnika!");
                tbPosao.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPlata.Text))
            {
                r.Plata = Convert.ToInt32(tbPlata.Text);
            }
            else
            {
                MessageBox.Show("Niste uneli platu za radnika!");
                tbPlata.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cmbOdeljenje.Text))
            {
                r.Odeljenje = cmbOdeljenje.SelectedItem as Odeljenje;
            }
            else
            {
                MessageBox.Show("Niste uneli odeljenje za radnika!");
                cmbOdeljenje.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(cmbPrivilegija.Text))
            {
                if (cmbPrivilegija.Text == "Radnik")
                {
                    r.Privilegija = 1;
                }
                if (cmbPrivilegija.Text == "Administrator")
                {
                    r.Privilegija = 2;
                }
                if (cmbPrivilegija.Text == "Direktor")
                {
                    r.Privilegija = 3;
                }
            }
            else
            {
                MessageBox.Show("Niste odabrali privilegiju!");
                cmbPrivilegija.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(cmbSatnica.Text))
            {
                r.Satnica = cmbSatnica.SelectedItem as Satnica;
            }
            else
            {
                MessageBox.Show("Niste odabrali satnicu!");
                cmbSatnica.Focus();
                return;
            }
            int brojZaposlenih = k.vratiBrojZaposlenihZaOdeljenje(r.Posao)+1;
            k.izmeniBrojZaposlenihUOdeljenju(r.Odeljenje, brojZaposlenih);

            int a = k.sacuvajRadnika(r);
            if (a == 0)
            {
                MessageBox.Show("Neuspesno cuvanje radnika!");
            }
            else
            {
                GodisnjiOdmor go = new GodisnjiOdmor();
                Radnik radnik = k.vratiRadnikaZaGodisnjiOdmor(r);
                go.Radnik = radnik;
                go.Godina = DateTime.Now.Year;
                go.OdobrenBroj = 21;
                go.UkupnoZaKoriscenje = 21;
                go.Iskorisceno = 0;
                k.sacuvajGodisnjiOdmor(go);
               
                MessageBox.Show("Uspesno sacuvan radnik!");
                this.Close();
                
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbOdeljenje.ItemsSource = k.vratiListuOdeljenja();
            cmbSatnica.ItemsSource = k.vratiListuSatnica();
            cmbPrivilegija.Items.Add("Radnik");
            cmbPrivilegija.Items.Add("Administrator");
            cmbPrivilegija.Items.Add("Direktor");
        }
    }
}
