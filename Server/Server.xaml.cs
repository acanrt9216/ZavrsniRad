using Biblioteka;
using Sesija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Server
{
    public partial class ServerKlasa : Window
    {

        public DataGrid dataGrid1;
        ServerKlasa s;
        public BindingList<Prolasci> listaProlazaka;
        private BindingList<Radnik> listaUlogovanihRadnika;
        public BindingList<Prolasci> ListaProlazaka { get => listaProlazaka; set => listaProlazaka = value; }

        public DataGrid DataGrid1 { get => dataGrid1; set => dataGrid1 = value; }
        public BindingList<Radnik> ListaUlogovanihRadnika { get => listaUlogovanihRadnika; set => listaUlogovanihRadnika = value; }

        public ServerKlasa()
        {
            InitializeComponent();
            listaProlazaka = new BindingList<Prolasci>();
            listaUlogovanihRadnika = new BindingList<Radnik>();
            s = new ServerKlasa(this);
            if (s.pokreniServer()) this.Title = "Pokrenut!";
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid1 = dataGrid;
            dataGrid1.ItemsSource = listaProlazaka;

            lvRadnici.ItemsSource = listaUlogovanihRadnika;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(osvezi);
            dt.Interval = TimeSpan.FromSeconds(30);
            dt.Start();
        }
        void osvezi(object sender, EventArgs e)
        {
            BindingList<Prolasci> lista = dataGrid1.ItemsSource as BindingList<Prolasci>;
            if (lista.Count>0)
            {
                Broker.dajSesiju().sacuvajProlaske(lista);
                dataGrid1.ItemsSource = null;
                listaProlazaka.Clear();
                dataGrid1.ItemsSource = listaProlazaka;
            }
            
        }
    }
}
