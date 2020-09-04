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
    /// Interaction logic for Odmor.xaml
    /// </summary>
    public partial class Odmor : Window
    {
        Radnik r;
        Komunikacija k;
        public Odmor(Radnik r, Komunikacija kom)
        {
            InitializeComponent();
            this.r = r;
            k = kom;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = r.Ime + " " + r.Prezime;
            List<GodisnjiOdmor> listaGodisnjihOdmora = k.vratiListuGodisnjihOdmora();
            for (int i = 0; i < listaGodisnjihOdmora.Count; i++)
            {
                if (listaGodisnjihOdmora[i].Radnik.RadnikID == r.RadnikID && listaGodisnjihOdmora[i].UkupnoZaKoriscenje == 0)
                {
                    MessageBox.Show("Nemate vise slobodnih dana!");
                    this.Close();
                }
            }
            DateTime danasnjiDatum = DateTime.Now;
            List<OdmorDan> lista = k.vratiSlobodneDane();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Radnik.RadnikID == r.RadnikID && lista[i].DatumDo.Date < danasnjiDatum.Date)
                {
                    k.obrisiOdmor(r);
                }
            }

            GodisnjiOdmor go = new GodisnjiOdmor();
            go.Radnik = r;
            go.Godina = DateTime.Now.Year;
            go.OdobrenBroj = 21;
            go.UkupnoZaKoriscenje = 21;
            go.Iskorisceno = 0;

            GodisnjiOdmor god = k.vratiGodisnjiOdmorZaRadnika(r);
            if (god == null)
            {
                k.sacuvajGodisnjiOdmor(go);
            }
        }

        private void BtnSacuvajOdmor_Click(object sender, RoutedEventArgs e)
        {
            List<OdmorDan> listaOdmora = k.vratiSlobodneDane();
            DateTime datum = DateTime.Now.Date;
            if (listaOdmora != null)
            {
                for (int i = 0; i < listaOdmora.Count; i++)
                {
                    if (listaOdmora[i].Radnik.RadnikID == r.RadnikID && listaOdmora[i].DatumDo>=datum && listaOdmora[i].DatumOd<=datum)
                    {
                        MessageBox.Show("Vas odmor je vec odobren. Ne mozete izabrati novi pre isteka starog!");
                        return;
                    }
                }
            }
            OdmorDan o = new OdmorDan();
            o.Radnik = r;

            if (!string.IsNullOrEmpty(dpDatumOd.Text))
            {
                o.DatumOd = dpDatumOd.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Morate odabrati datum od kojeg idete na odmor!");
                dpDatumOd.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(dpDatumDo.Text))
            {
                o.DatumDo = dpDatumDo.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Morate odabrati datum do kojeg idete na odmor!");
                dpDatumDo.Focus();
                return;
            }
            
                int sacuvan = k.sacuvajOdmor(o);
                if (sacuvan == 0)
                {
                    MessageBox.Show("Neuspesno cuvanje odmora!");
                    return;
                }
                else
                {
                    MessageBox.Show("Uspesno sacuvan odmor!");
                }

                List<GodisnjiOdmor> lista = k.vratiListuGodisnjihOdmora();
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Radnik.RadnikID == r.RadnikID)
                    {

                        double brojDana = (o.DatumDo - o.DatumOd).TotalDays;
                        GodisnjiOdmor god = new GodisnjiOdmor();
                        god.Radnik = r;
                        god.UkupnoZaKoriscenje = lista[i].UkupnoZaKoriscenje;
                        god.Iskorisceno = lista[i].Iskorisceno;
                        int a=k.izmeniSlobodneDane(god, brojDana);
                    if (a == 0)
                    {
                        MessageBox.Show("Neuspesna izmena slobodnih dana!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Uspesno izmenjeni slobodni dani!");
                    }
                        this.Close();
                    }
                }
            //}

            
        }
    }
}
