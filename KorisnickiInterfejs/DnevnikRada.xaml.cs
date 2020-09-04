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
using Sesija;

namespace KorisnickiInterfejs
{
    /// <summary>
    /// Interaction logic for DnevnikRada.xaml
    /// </summary>
    public partial class DnevnikRada : Window
    {
        private Radnik r;
        Dnevnik d;
        Komunikacija k;
        public DnevnikRada(Radnik r,Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            tpPonedeljak.Visibility = Visibility.Hidden;
            tpUtorak.Visibility = Visibility.Hidden;
            tpSreda.Visibility = Visibility.Hidden;
            tpCetvrtak.Visibility = Visibility.Hidden;
            tpPetak.Visibility = Visibility.Hidden;
            btnSacuvajDnevnik.Visibility = Visibility.Hidden;
            d = new Dnevnik();
            d.Radnik = r;


        }

        private void BtnPonedeljak_Click(object sender, RoutedEventArgs e)
        {

            if (!(btnPonedeljak.Background == Brushes.LightGreen))
            {
                if (tbPonedeljak.Text == "")
                {
                    tpPonedeljak.Visibility = Visibility.Visible;
                    btnUtorak.IsEnabled = false;
                    btnSreda.IsEnabled = false;
                    btnPetak.IsEnabled = false;
                    btnCetvrtak.IsEnabled = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(tbPonedeljak.Text))
                    {
                        d.Ponedeljak = tbPonedeljak.Text;
                    }
                    else
                    {
                        MessageBox.Show("Morate uneti sta ste radili u ponedeljak!");
                        tbPonedeljak.Focus();
                        return;
                    }
                    btnPonedeljak.Background = Brushes.LightGreen;
                    tpPonedeljak.Visibility = Visibility.Hidden;
                    btnUtorak.IsEnabled = true;
                    btnSreda.IsEnabled = true;
                    btnCetvrtak.IsEnabled = true;
                    btnPetak.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("Vec ste popunili dnevnik za ovaj dan!");
            }
        }
            

        private void BtnUtorak_Click(object sender, RoutedEventArgs e)
        {
            if(!(btnUtorak.Background==Brushes.LightGreen))
            {
                if (tbUtorak.Text == "")
                {
                    tpUtorak.Visibility = Visibility.Visible;
                    btnCetvrtak.IsEnabled = false;
                    btnSreda.IsEnabled = false;
                    btnPetak.IsEnabled = false;
                    btnPonedeljak.IsEnabled = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(tbUtorak.Text))
                    {
                        d.Utorak = tbUtorak.Text;
                    }
                    else
                    {
                        MessageBox.Show("Morate uneti sta ste radili u utorak!");
                        tbUtorak.Focus();
                        return;
                    }
                    
                    btnUtorak.Background = Brushes.LightGreen;
                    tpUtorak.Visibility = Visibility.Hidden;
                    btnPetak.IsEnabled = true;
                    btnSreda.IsEnabled = true;
                    btnCetvrtak.IsEnabled = true;
                    btnPonedeljak.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("Vec ste popunili dnevnik za ovaj dan!");
            }
            
        }

        private void BtnSreda_Click(object sender, RoutedEventArgs e)
        {
            if (!(btnSreda.Background == Brushes.LightGreen))
            {
                if (tbSreda.Text == "")
                {
                    tpSreda.Visibility = Visibility.Visible;
                    btnUtorak.IsEnabled = false;
                    btnCetvrtak.IsEnabled = false;
                    btnPetak.IsEnabled = false;
                    btnPonedeljak.IsEnabled = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(tbSreda.Text))
                    {
                        d.Sreda = tbSreda.Text;
                    }
                    else
                    {
                        MessageBox.Show("Morate uneti sta ste radili u sredu!");
                        tbSreda.Focus();
                        return;
                    }
                    
                    btnSreda.Background = Brushes.LightGreen;
                    tpSreda.Visibility = Visibility.Hidden;
                    btnUtorak.IsEnabled = true;
                    btnPetak.IsEnabled = true;
                    btnCetvrtak.IsEnabled = true;
                    btnPonedeljak.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("Vec ste popunili dnevnik za ovaj dan");
            }
            
        }

        private void BtnCetvrtak_Click(object sender, RoutedEventArgs e)
        {
            if (!(btnCetvrtak.Background == Brushes.LightGreen))
            {
                if (tbCetvrtak.Text == "")
                {
                    tpCetvrtak.Visibility = Visibility.Visible;
                    btnUtorak.IsEnabled = false;
                    btnSreda.IsEnabled = false;
                    btnPetak.IsEnabled = false;
                    btnPonedeljak.IsEnabled = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(tbCetvrtak.Text))
                    {
                        d.Cetvrtak = tbCetvrtak.Text;
                    }
                    else
                    {
                        MessageBox.Show("Morate uneti sta ste radili u cetvrtak!");
                        tbCetvrtak.Focus();
                        return;
                    }
                    
                    btnCetvrtak.Background = Brushes.LightGreen;
                    tpCetvrtak.Visibility = Visibility.Hidden;
                    btnUtorak.IsEnabled = true;
                    btnSreda.IsEnabled = true;
                    btnPetak.IsEnabled = true;
                    btnPonedeljak.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("Vec ste popunili dnevnik za ovaj dan");
            }
            
        }

        private void BtnPetak_Click(object sender, RoutedEventArgs e)
        {
            if (!(btnPetak.Background == Brushes.LightGreen))
            {
                if (tbPetak.Text == "")
                {
                    tpPetak.Visibility = Visibility.Visible;
                    btnUtorak.IsEnabled = false;
                    btnSreda.IsEnabled = false;
                    btnCetvrtak.IsEnabled = false;
                    btnPonedeljak.IsEnabled = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(tbPetak.Text))
                    {
                        d.Petak = tbPetak.Text;
                    }
                    else
                    {
                        MessageBox.Show("Morate uneti sta ste radili u petak!");
                        tbPetak.Focus();
                        return;
                    }
                    
                    btnPetak.Background = Brushes.LightGreen;
                    tpPetak.Visibility = Visibility.Hidden;
                    btnUtorak.IsEnabled = true;
                    btnSreda.IsEnabled = true;
                    btnCetvrtak.IsEnabled = true;
                    btnPonedeljak.IsEnabled = true;
                    btnSacuvajDnevnik.Visibility =Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Vec ste popunili dnevnik za ovaj dan");
            }
            
        }

        private void BtnSacuvajDnevnik_Click(object sender, RoutedEventArgs e)
        {
            
            if (btnPonedeljak.Background == Brushes.LightGreen && btnUtorak.Background == Brushes.LightGreen && btnSreda.Background == Brushes.LightGreen && btnCetvrtak.Background == Brushes.LightGreen && btnPetak.Background == Brushes.LightGreen)
            {
                int sacuvan = k.sacuvajDnevnikRada(d);
                if (sacuvan == 0)
                {
                    MessageBox.Show("Neuspesno cuvanje dnevnika!");
                    return;
                }
                else
                {
                    MessageBox.Show("Uspesno sacuvan dnevnik!");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste uneli sve dane za dnevnik rada!");
                return;
            }
            
        }
    }
}
