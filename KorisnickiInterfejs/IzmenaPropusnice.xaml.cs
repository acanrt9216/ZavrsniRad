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
    /// Interaction logic for IzmenaPropusnice.xaml
    /// </summary>
    public partial class IzmenaPropusnice : Window
    {
        Propusnica p;
        Komunikacija k;
        public IzmenaPropusnice(Propusnica p,Komunikacija kom)
        {
            InitializeComponent();
            this.p = p;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            tbPropusnicaID.Text = Convert.ToString(p.PropusnicaID);
            tbIme.Text = p.Ime;
            tbPrezime.Text = p.Prezime;
            tbRazlog.Text = p.Razlog;
            tbDatum.Text = p.Datum.ToString("dd.MM.yyyy");
        }

        private void BtnIzmenaPropusnice_Click(object sender, RoutedEventArgs e)
        {
            Propusnica pr = new Propusnica();
            pr.PropusnicaID = Int32.Parse(tbPropusnicaID.Text);
            if (!string.IsNullOrEmpty(tbIme.Text))
            {
                pr.Ime = tbIme.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti ime!");
                tbPrezime.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPrezime.Text))
            {
                pr.Prezime = tbPrezime.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti prezime!");
                tbPrezime.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbRazlog.Text))
            {
                pr.Razlog = tbRazlog.Text;
            }
            else
            {
                MessageBox.Show("Morate uneti razlog!");
                tbRazlog.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(tbDatum.Text))
            {
                pr.Datum = DateTime.Parse(tbDatum.Text);
            }
            else
            {
                MessageBox.Show("Morate uneti datum propusnice!");
                tbDatum.Focus();
                return;
            }
            
            int izmenjen = k.izmeniPropusnicu(pr);
            if (izmenjen == 0)
            {
                MessageBox.Show("Neuspesna izmena propusnice!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno izmenjena propusnica!");
            }
        }
    }
}
