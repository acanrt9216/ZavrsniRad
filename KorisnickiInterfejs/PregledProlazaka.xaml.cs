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
    /// Interaction logic for PregledProlazaka.xaml
    /// </summary>
    public partial class PregledProlazaka : Window
    {
        Prolasci p;
        Komunikacija k;
        public PregledProlazaka(Prolasci p,Komunikacija kom)
        {
            InitializeComponent();
            this.p = p;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbProlazakID.Text = Convert.ToString(p.ProlazakID);
            tbRadnik.Text = Convert.ToString(p.Radnik);
            tbPravac.Text = p.Pravac;
            tbVremeProlaska.Text = Convert.ToString(p.VremeProlaska);
            tbKapija.Text = Convert.ToString(p.Kapija);
        }

        private void BtnIzmeniProlazak_Click(object sender, RoutedEventArgs e)
        {
            new IzmenaProlaska(p,k).ShowDialog();
        }
    }
}
