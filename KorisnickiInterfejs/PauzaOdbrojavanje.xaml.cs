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
using System.Windows.Threading;

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for Pauza.xaml
    /// </summary>
    public partial class PauzaOdbrojavanje : Window
    {
        Radnik r;
        Komunikacija k;
        DispatcherTimer timer;
        TimeSpan ts;
        int duzinaPauze;
        public PauzaOdbrojavanje(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
            duzinaPauze = 0;
        }

        private void BtnZapocniPauzu_Click(object sender, RoutedEventArgs e)
        {
            duzinaPauze = 0;
            duzinaPauze = k.vratiBrojMinutaPauze(cmbVrstePauza.Text);
            if (lblVreme.Text == "")
            {
                ts = TimeSpan.FromMinutes(duzinaPauze);
                timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    lblVreme.Text = ts.ToString("c");
                    if (ts == TimeSpan.Zero)
                        timer.Stop();
                    ts = ts.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);
                timer.Start();
            }
            else
            {
                MessageBox.Show("Morate prekinuti prethodnu pauzu!");
            }
            
        }

        private void BtnPrekiniPauzu_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            lblVreme.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            cmbVrstePauza.ItemsSource = k.vratiListuPauza();
        }
    }
}
