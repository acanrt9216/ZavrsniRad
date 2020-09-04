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
    /// Interaction logic for PretragaGodisnjegOdmora.xaml
    /// </summary>
    public partial class PretragaGodisnjegOdmora : Window
    {
        Radnik r;
        Komunikacija k;
        public PretragaGodisnjegOdmora(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            dataGrid.ItemsSource = k.vratiListuGodisnjihOdmora();
        }

        private void BtnPretragaGodisnjeg_Click(object sender, RoutedEventArgs e)
        {
            int pom1 = 0;
            int pom2 = 0;
            try
            {
                Int32.TryParse(tbGodina.Text, out pom1);
            }
            catch (Exception)
            {

                throw;
            }
            int godina = pom1;
            try
            {
                Int32.TryParse(tbUkupnoZaKoriscenje.Text, out pom2);
            }
            catch (Exception)
            {

                throw;
            }
            int ukupno = pom2;
            
            
            dataGrid.ItemsSource = k.vratiGodisnjeOdmorePretraga(godina, ukupno);
        }

        private void BtnPregledGodOdmora_Click(object sender, RoutedEventArgs e)
        {
            GodisnjiOdmor go = dataGrid.SelectedItem as GodisnjiOdmor;
            new PregledGodisnjegOdmora(go,k).ShowDialog();
            dataGrid.ItemsSource = k.vratiListuGodisnjihOdmora();
        }

        private void BtnObrisiGodOdmor_Click(object sender, RoutedEventArgs e)
        {
            int obrisan = k.obrisiGodisnjiOdmor(dataGrid.SelectedItem as GodisnjiOdmor);
            if (obrisan == 0)
            {
                MessageBox.Show("Neuspesno brisanje godisnjeg odmora!");
                return;
            }
            else
            {
                MessageBox.Show("Uspesno obrisan godisnji odmor!");
            }
            dataGrid.ItemsSource = k.vratiListuGodisnjihOdmora();
        }
    }
}
