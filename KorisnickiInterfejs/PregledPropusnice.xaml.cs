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
    /// Interaction logic for PregledPropusnice.xaml
    /// </summary>
    public partial class PregledPropusnice : Window
    {
        Propusnica p;
        Komunikacija k;
        public PregledPropusnice(Propusnica p,Komunikacija kom)
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
            tbDatum.Text = Convert.ToString(p.Datum);
        }

        private void BtnIzmeniPropusnicu_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaPropusnice(p,k).ShowDialog();
        }
    }
}
