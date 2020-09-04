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
    /// Interaction logic for IzmenaGodisnjihOdmora.xaml
    /// </summary>
    public partial class IzmenaGodisnjihOdmora : Window
    {
        private GodisnjiOdmor go;
        Komunikacija k;
        public IzmenaGodisnjihOdmora(GodisnjiOdmor go,Komunikacija kom)
        {
            InitializeComponent();
            this.go = go;
            k = kom;
        }

        private void BtnIzmenaGodOdmor_Click(object sender, RoutedEventArgs e)
        {
            GodisnjiOdmor godOdmor = new GodisnjiOdmor();
            if (!string.IsNullOrEmpty(tbRadnik.Text))
            {
                godOdmor.Radnik.RadnikID = Convert.ToInt32(tbRadnik.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti id radnika!");
                tbRadnik.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbGodina.Text))
            {
                godOdmor.Godina = Convert.ToInt32(tbGodina.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti godinu koja je u toku!");
                tbGodina.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbOdobrenoDana.Text))
            {
                godOdmor.OdobrenBroj = Convert.ToInt32(tbOdobrenoDana.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti broj odobrenih dana!");
                tbOdobrenoDana.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbUkupnoZaKoriscenje.Text))
            {
                godOdmor.UkupnoZaKoriscenje = Convert.ToInt32(tbUkupnoZaKoriscenje.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti broj dana za ukupno koriscenje!");
                tbUkupnoZaKoriscenje.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbIskorisceno.Text))
            {
                godOdmor.Iskorisceno = Convert.ToInt32(tbIskorisceno.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti broj iskoriscenih dana!");
                tbIskorisceno.Focus();
                return;
            }
            
            int izmenjen = k.izmeniGodisnjiOdmor(godOdmor);
            if (izmenjen == 0)
            {
                MessageBox.Show("Neuspesna izmena godisnjeg odmora!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjen godisnji odmor!");
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbRadnik.Text = Convert.ToString(go.Radnik.RadnikID);
            tbGodina.Text = Convert.ToString(go.Godina);
            tbOdobrenoDana.Text = Convert.ToString(go.OdobrenBroj);
            tbUkupnoZaKoriscenje.Text = Convert.ToString(go.UkupnoZaKoriscenje);
            tbIskorisceno.Text = Convert.ToString(go.Iskorisceno);
        }
    }
}
