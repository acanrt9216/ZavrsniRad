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
    /// Interaction logic for UnosPropusnice.xaml
    /// </summary>
    public partial class UnosPropusnice : Window
    {
        Radnik r;
        Komunikacija k;
        public UnosPropusnice(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void BtnSacuvajPropusnicu_Click(object sender, RoutedEventArgs e)
        {
            Propusnica p = new Propusnica();
            if (!string.IsNullOrEmpty(tbIme.Text))
            {
                p.Ime = tbIme.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli ime!");
                tbIme.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbPrezime.Text))
            {
                p.Prezime = tbPrezime.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli prezime!");
                tbPrezime.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbRazlog.Text))
            {
                p.Razlog = tbRazlog.Text;
            }
            else
            {
                MessageBox.Show("Niste uneli razlog!");
                tbRazlog.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(tbDatum.Text))
            {
                p.Datum = Convert.ToDateTime(tbDatum.Text);
            }
            else
            {
                MessageBox.Show("Niste uneli datum propusnice!");
                tbDatum.Focus();
                return;
            }
            
            int sacuvan = k.sacuvajPropusnicu(p);
            if (sacuvan == 0)
            {
                MessageBox.Show("Neuspesno cuvanje propusnice!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno sacuvana propusnica!");
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
