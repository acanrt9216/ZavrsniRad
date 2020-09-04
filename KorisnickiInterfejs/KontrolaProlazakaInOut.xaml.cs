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
    /// Interaction logic for KontrolaProlazakaInOut.xaml
    /// </summary>
    public partial class KontrolaProlazakaInOut : Window
    {
        Radnik r;
        Komunikacija k;
        public KontrolaProlazakaInOut(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
        }

        private void CalendarInOut_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calendarInOut.SelectedDate.HasValue)
            {
                DateTime datum = calendarInOut.SelectedDate.Value;
                List<Prolasci> listaProlazaka = k.vratiListuProlazaka();
                lvRadnici.ItemsSource = k.vratiListuRadnikaZaCalendarINOUT(listaProlazaka, datum);

            }
        }
    }
}
