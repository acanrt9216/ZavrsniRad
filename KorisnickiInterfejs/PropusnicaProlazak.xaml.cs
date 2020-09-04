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
    /// Interaction logic for PropusnicaProlazak.xaml
    /// </summary>
    public partial class PropusnicaProlazak : Window
    {
        Komunikacija k;
        public PropusnicaProlazak(Komunikacija kom)
        {
            InitializeComponent();
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbRazlog.Items.Add("Sluzbeno");
            cmbRazlog.Items.Add("Privatno");
        }

        private void BtnSacuvajPropusnicu_Click(object sender, RoutedEventArgs e)
        {
            Propusnica p = new Propusnica();
            p.Ime = tbIme.Text;
            p.Prezime = tbPrezime.Text;
            p.Razlog = cmbRazlog.Text;
            p.Datum = DateTime.Now.Date;
            k.sacuvajPropusnicu(p);
            this.Hide();
            new Prijava().ShowDialog();
            this.Close();
        }
    }
}
