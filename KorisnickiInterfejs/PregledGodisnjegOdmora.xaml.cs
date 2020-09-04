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

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for PregledGodisnjegOdmora.xaml
    /// </summary>
    public partial class PregledGodisnjegOdmora : Window
    {
        private GodisnjiOdmor go;
        Komunikacija k;
        public PregledGodisnjegOdmora(GodisnjiOdmor go,Komunikacija kom)
        {
            InitializeComponent();
            this.go = go;
            k = kom;
        }

        private void BtnIzmeniGodisnjiOdmor_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaGodisnjihOdmora(go,k).ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbRadnik.Text = Convert.ToString(go.Radnik.RadnikID);
            tbGodina.Text = Convert.ToString(go.Godina);
            tbOdobrenBrojDana.Text = Convert.ToString(go.OdobrenBroj);
            tbUkupnoZaKoriscenje.Text = Convert.ToString(go.UkupnoZaKoriscenje);
            tbIskorisceno.Text = Convert.ToString(go.Iskorisceno);
        }
    }
}
