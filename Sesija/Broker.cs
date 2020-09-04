using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sesija
{
    public class Broker
    {

        OleDbConnection konekcija;
        OleDbCommand komanda;
        OleDbTransaction transakcija;

        void konektujSe()
        {
            konekcija = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Aca\ZavrsniRad\BazaPodataka.mdb");
            komanda = konekcija.CreateCommand();
        }

        Broker()
        {
            konektujSe();
        }

        public static Broker instanca;
        public static Broker dajSesiju()
        {
            if (instanca == null)
            {
                instanca = new Broker();
            }
            return instanca;
        }

        public Radnik prijava(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Odeljenje.OdeljenjeID AS Odeljenje_OdeljenjeID, Odeljenje.Naziv AS Odeljenje_Naziv, Radnik.RadnikID, Odeljenje.SefOdeljenja, Odeljenje.BrojZaposlenih, Radnik.Ime, Radnik.Prezime, Radnik.DatumRodjenja, Radnik.Posao, Radnik.Plata, Radnik.Username, Radnik.Password, Radnik.OdeljenjeID AS Radnik_OdeljenjeID, Radnik.Privilegija, Satnica.SatnicaID AS Satnica_SatnicaID, Satnica.Naziv AS Satnica_Naziv, Satnica.Opis, Satnica.BrojSati, Radnik.SatnicaID AS Radnik_SatnicaID FROM Odeljenje INNER JOIN(Satnica INNER JOIN Radnik ON Satnica.[SatnicaID] = Radnik.[SatnicaID]) ON Odeljenje.[OdeljenjeID] = Radnik.[OdeljenjeID] where Username ='" + r.Username+"' and Password='"+r.Password+"'";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Odeljenje o = new Odeljenje();
                    o.OdeljenjeID = citac.GetInt32(0);
                    o.Naziv = citac.GetString(1);
                    r.RadnikID = citac.GetInt32(2);
                    o.SefOdeljenja = r;
                    o.BrojZaposlenih = citac.GetInt32(4);

                    
                    r.Ime = citac.GetString(5);
                    r.Prezime = citac.GetString(6);
                    r.DatumRodjenja = citac.GetDateTime(7);
                    r.Posao = citac.GetString(8);
                    r.Plata = citac.GetInt32(9);
                    r.Odeljenje = o;
                    r.Privilegija = citac.GetInt32(13);

                    Satnica s = new Satnica();
                    s.SatnicaID = citac.GetInt32(14);
                    s.Naziv = citac.GetString(15);
                    s.Opis = citac.GetString(16);
                    s.BrojSati = citac.GetInt32(17);
                    r.Satnica = s;

                    return r;
                }
                citac.Close();
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public Radnik vratiZaboravljenuLozinku(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select Username,Password From Radnik Where Ime='"+r.Ime+"' And Prezime='" + r.Prezime + "'";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik radnik = new Radnik();
                    radnik.Username = citac.GetString(0);
                    radnik.Password = citac.GetString(1);

                    return radnik;
                }
                citac.Close();
                return null;
                
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Odeljenje> vratiOdeljenja()
        {
            List<Odeljenje> lista = new List<Odeljenje>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT o.OdeljenjeID, o.Naziv,r.RadnikID, r.Ime, r.Prezime, o.SefOdeljenja, o.BrojZaposlenih FROM Odeljenje o INNER JOIN Radnik r ON o.SefOdeljenja = r.RadnikID";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Odeljenje o = new Odeljenje();
                    o.OdeljenjeID = citac.GetInt32(0);
                    o.Naziv = citac.GetString(1);
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(2);
                    r.Ime = citac.GetString(3);
                    r.Prezime = citac.GetString(4);
                    o.SefOdeljenja = r;
                    o.BrojZaposlenih = citac.GetInt32(6);

                    lista.Add(o);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Kapija> vratiKapije()
        {
            List<Kapija> lista = new List<Kapija>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Lokacija inner join Kapija on Lokacija.LokacijaID=Kapija.LokacijaID";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Lokacija l = new Lokacija();
                    l.LokacijaID = citac.GetInt32(0);
                    l.Naziv = citac.GetString(1);
                    l.Opis = citac.GetString(2);

                    Kapija k = new Kapija();
                    k.KapijaID = citac.GetInt32(3);
                    k.Naziv = citac.GetString(4);
                    k.Opis = citac.GetString(5);
                    k.Lokacija = l;

                    lista.Add(k);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Kapija> vratiKapijeZaIzvestaj(Kapija k)
        {
            List<Kapija> lista = new List<Kapija>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Lokacija inner join Kapija on Lokacija.LokacijaID=Kapija.LokacijaID where Naziv='"+k.Naziv+"'";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Lokacija l = new Lokacija();
                    l.LokacijaID = citac.GetInt32(0);
                    l.Naziv = citac.GetString(1);
                    l.Opis = citac.GetString(2);
                    
                    
                    k.KapijaID = citac.GetInt32(3);
                    k.Opis = citac.GetString(5);
                    k.Lokacija = l;

                    lista.Add(k);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Lokacija> vratiLokacije()
        {
            List<Lokacija> lista = new List<Lokacija>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Lokacija";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Lokacija l = new Lokacija();
                    l.LokacijaID = citac.GetInt32(0);
                    l.Naziv = citac.GetString(1);
                    l.Opis = citac.GetString(2);

                    lista.Add(l);
                }
                citac.Close();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Satnica> vratiSatnice()
        {
            List<Satnica> lista = new List<Satnica>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Satnica.SatnicaID, Satnica.Naziv, Satnica.Opis, Satnica.BrojSati FROM Satnica";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Satnica s = new Satnica();
                    s.SatnicaID = citac.GetInt32(0);
                    s.Naziv = citac.GetString(1);
                    s.Opis = citac.GetString(2);
                    s.BrojSati = citac.GetInt32(3);
                    lista.Add(s);
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Praznik> vratiPraznike()
        {
            List<Praznik> lista = new List<Praznik>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Praznik";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Praznik p = new Praznik();
                    p.PraznikID = citac.GetInt32(0);
                    p.Naziv = citac.GetString(1);
                    p.DatumPraznika = citac.GetDateTime(2);

                    lista.Add(p);
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if(konekcija != null) konekcija.Close(); }
        }
        public List<Propusnica> vratiPropusnice()
        {
            List<Propusnica> lista = new List<Propusnica>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Propusnica";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Propusnica p = new Propusnica();
                    p.PropusnicaID = citac.GetInt32(0);
                    p.Ime = citac.GetString(1);
                    p.Prezime = citac.GetString(2);

                    p.Razlog = citac.GetString(3);
                    p.Datum = citac.GetDateTime(4);

                    lista.Add(p);
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Pauza> vratiPauze()
        {
            List<Pauza> lista = new List<Pauza>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Pauza";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Pauza p = new Pauza();
                    p.PauzaID = citac.GetInt32(0);
                    p.Naziv = citac.GetString(1);
                    p.DuzinaPauze = citac.GetInt32(2);

                    lista.Add(p);
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public int vratiBrojMinutaPauze(string naziv)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText="Select DuzinaPauze From Pauza Where Naziv='"+naziv+"'";
                int duzinaPauze = Convert.ToInt32(komanda.ExecuteScalar());
                return duzinaPauze;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<GodisnjiOdmor> vratiGodisnjeOdmore()
        {
            List<GodisnjiOdmor> lista = new List<GodisnjiOdmor>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, GodisnjiOdmor.RadnikID AS GodisnjiOdmor_RadnikID, GodisnjiOdmor.Godina, GodisnjiOdmor.OdobrenBroj, GodisnjiOdmor.UkupnoZaKoriscenje, GodisnjiOdmor.Iskorisceno FROM Radnik INNER JOIN GodisnjiOdmor ON Radnik.[RadnikID] = GodisnjiOdmor.[RadnikID]";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);
                    GodisnjiOdmor g = new GodisnjiOdmor();
                    g.Radnik = r;
                    g.Godina = citac.GetInt32(4);
                    g.OdobrenBroj = citac.GetInt32(5);
                    g.UkupnoZaKoriscenje = citac.GetInt32(6);
                    g.Iskorisceno = citac.GetInt32(7);

                    lista.Add(g);
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public GodisnjiOdmor vratiGodisnjiOdmorZaRadnika(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, GodisnjiOdmor.RadnikID AS GodisnjiOdmor_RadnikID, GodisnjiOdmor.Godina, GodisnjiOdmor.OdobrenBroj, GodisnjiOdmor.UkupnoZaKoriscenje, GodisnjiOdmor.Iskorisceno FROM Radnik INNER JOIN GodisnjiOdmor ON Radnik.[RadnikID] = GodisnjiOdmor.[RadnikID] Where Radnik.RadnikID="+r.RadnikID+"";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);
                    GodisnjiOdmor g = new GodisnjiOdmor();
                    g.Radnik = r;
                    g.Godina = citac.GetInt32(4);
                    g.OdobrenBroj = citac.GetInt32(5);
                    g.UkupnoZaKoriscenje = citac.GetInt32(6);
                    g.Iskorisceno = citac.GetInt32(7);

                    return g;
                }
                citac.Close();
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Prolasci> vratiProlazakZaRadnika(Radnik r,string pravac)
        {
            List<Prolasci> lista = new List<Prolasci>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Lokacija.LokacijaID AS Lokacija_LokacijaID, Lokacija.Naziv AS Lokacija_Naziv, Kapija.KapijaID AS Kapija_KapijaID, Kapija.Naziv AS Kapija_Naziv, Kapija.Opis, Kapija.LokacijaID AS Kapija_LokacijaID, Prolasci.ProlazakID, Prolasci.RadnikID AS Prolasci_RadnikID, Prolasci.Pravac, Prolasci.VremeProlaska, Prolasci.KapijaID AS Prolasci_KapijaID FROM Radnik INNER JOIN((Lokacija INNER JOIN Kapija ON Lokacija.[LokacijaID] = Kapija.[LokacijaID]) INNER JOIN Prolasci ON Kapija.[KapijaID] = Prolasci.[KapijaID]) ON Radnik.[RadnikID] = Prolasci.[RadnikID] Where Radnik.RadnikID=" + r.RadnikID + " AND Prolasci.Pravac='"+pravac+"'";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);

                    Lokacija l = new Lokacija();
                    l.LokacijaID = citac.GetInt32(3);
                    l.Naziv = citac.GetString(4);

                    Kapija k = new Kapija();
                    k.KapijaID = citac.GetInt32(5);
                    k.Naziv = citac.GetString(6);
                    k.Opis = citac.GetString(7);
                    k.Lokacija = l;

                    Prolasci p = new Prolasci();
                    p.ProlazakID = citac.GetInt32(9);
                    p.Radnik = r;
                    p.Pravac = citac.GetString(11);
                    p.VremeProlaska = citac.GetDateTime(12);
                    p.Kapija = k;

                    lista.Add(p);
                    
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<OdmorDan> vratiSlobodneDane()
        {
            List<OdmorDan> lista = new List<OdmorDan>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Odmor.RadnikID AS Odmor_RadnikID, Odmor.DatumOd, Odmor.DatumDo FROM Radnik INNER JOIN Odmor ON Radnik.[RadnikID] = Odmor.[RadnikID]";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);
                    OdmorDan o = new OdmorDan();
                    o.Radnik = r;
                    o.DatumOd = citac.GetDateTime(4);
                    o.DatumDo = citac.GetDateTime(5);

                    lista.Add(o);
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Radnik> vratiRadnike()
        {
            List<Radnik> lista = new List<Radnik>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Odeljenje.OdeljenjeID AS Odeljenje_OdeljenjeID, Odeljenje.Naziv AS Odeljenje_Naziv, Radnik.RadnikID, Odeljenje.SefOdeljenja, Odeljenje.BrojZaposlenih, Radnik.Ime, Radnik.Prezime, Radnik.DatumRodjenja, Radnik.Posao, Radnik.Plata, Radnik.Username, Radnik.Password, Radnik.OdeljenjeID AS Radnik_OdeljenjeID, Radnik.Privilegija, Satnica.SatnicaID AS Satnica_SatnicaID, Satnica.Naziv AS Satnica_Naziv, Satnica.Opis, Satnica.BrojSati, Radnik.SatnicaID AS Radnik_SatnicaID FROM Odeljenje INNER JOIN(Satnica INNER JOIN Radnik ON Satnica.[SatnicaID] = Radnik.[SatnicaID]) ON Odeljenje.[OdeljenjeID] = Radnik.[OdeljenjeID]";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    Odeljenje o = new Odeljenje();
                    o.OdeljenjeID = citac.GetInt32(0);
                    o.Naziv = citac.GetString(1);
                    r.RadnikID = citac.GetInt32(2);
                    o.SefOdeljenja = r;
                    o.BrojZaposlenih = citac.GetInt32(4);

                    
                    
                    r.Ime = citac.GetString(5);
                    r.Prezime = citac.GetString(6);
                    r.DatumRodjenja = citac.GetDateTime(7);
                    r.Posao = citac.GetString(8);
                    r.Plata = citac.GetInt32(9);
                    r.Username = citac.GetString(10);
                    r.Password = citac.GetString(11);
                    r.Odeljenje = o;
                    r.Privilegija = citac.GetInt32(13);
                    Satnica s = new Satnica();
                    s.SatnicaID = citac.GetInt32(14);
                    s.Naziv = citac.GetString(15);
                    s.Opis = citac.GetString(16);
                    s.BrojSati = citac.GetInt32(17);
                    r.Satnica = s;

                    lista.Add(r);
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Radnik> vratiRadnikaZaComboBox(Radnik r)
        {
            List<Radnik> lista = new List<Radnik>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT radnikID,ime,prezime FROM Radnik Where RadnikID="+r.RadnikID+"";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);
                    lista.Add(r);
                }
                citac.Close();
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public Radnik vratiRadnikaZaGodisnjiOdmor(Radnik r)
        {
            try
            {
                konekcija.Open();
                Radnik radnik = new Radnik() ;
                komanda.CommandText = "SELECT radnikID,ime,prezime FROM Radnik Where Ime='"+r.Ime+"' And Prezime='"+r.Prezime+"'";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    radnik.RadnikID = citac.GetInt32(0);
                    radnik.Ime = citac.GetString(1);
                    radnik.Prezime = citac.GetString(2);
                    return radnik;
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Prolasci> vratiProlaske()
        {
            List<Prolasci> lista = new List<Prolasci>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Prolasci.ProlazakID, Prolasci.RadnikID AS Prolasci_RadnikID, Prolasci.Pravac, Prolasci.VremeProlaska, Kapija.KapijaID AS Kapija_KapijaID, Kapija.Naziv, Prolasci.KapijaID AS Prolasci_KapijaID FROM Kapija INNER JOIN(Radnik INNER JOIN Prolasci ON Radnik.[RadnikID] = Prolasci.[RadnikID]) ON Kapija.[KapijaID] = Prolasci.[KapijaID]";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);
                    Prolasci p = new Prolasci();
                    p.ProlazakID = citac.GetInt32(3);
                    p.Radnik = r;
                    p.Pravac = citac.GetString(5);
                    p.VremeProlaska = citac.GetDateTime(6);
                    Kapija k = new Kapija();
                    k.KapijaID = citac.GetInt32(7);
                    k.Naziv = citac.GetString(8);
                    p.Kapija = k;


                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Radnik> vratiRadnikaZaOdeljenje(Odeljenje o)
        {
            List<Radnik> lista = new List<Radnik>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT radnikID,ime,prezime FROM Radnik Where OdeljenjeID=" + o.OdeljenjeID + "";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);
                    lista.Add(r);
                }
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        

        public int vratiSifruZaRadnika()
        {
            try
            {
                komanda.CommandText = "Select Max(RadnikID) from Radnik";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        
        public int vratiSifruZaKapiju()
        {
            try
            {
                komanda.CommandText = "Select Max(KapijaID) from Kapija";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public int vratiSifruZaLokaciju()
        {
            try
            {
                komanda.CommandText = "Select Max(LokacijaID) from Lokacija";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public int vratiSifruZaOdeljenje()
        {
            try
            {
                komanda.CommandText = "Select Max(OdeljenjeID) from Odeljenje";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public int vratiBrojZaposlenihZaOdeljenje(string posao)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select COUNT(RadnikID) From Radnik Where Posao='"+posao+"'";
                int broj = Convert.ToInt32(komanda.ExecuteScalar());
                return broj;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int vratiBrojZaposlenihZaIzmenuRadnika(Odeljenje o)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select BrojZaposlenih from Odeljenje where OdeljenjeID=" + o.OdeljenjeID + "";
                int broj = Convert.ToInt32(komanda.ExecuteScalar());
                return broj;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public int vratiSifruZaProlazak()
        {
            try
            {
                komanda.CommandText = "Select Max(ProlazakID) from Prolasci";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public int vratiSifruZaPropusnicu()
        {
            try
            {
                komanda.CommandText = "Select Max(PropusnicaID) from Propusnica";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public int vratiSifruZaProlaske()
        {
            try
            {
                string upit= "Select Max(ProlazakID) from Prolasci";
                komanda = new OleDbCommand(upit, konekcija, transakcija);
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public int vratiSifruZaSatnicu()
        {
            try
            {
                komanda.CommandText = "Select Max(SatnicaID) from Satnica";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        
        public int vratiSifruZaPauzu()
        {
            try
            {
                komanda.CommandText = "Select Max(PauzaID) from Pauza";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public int vratiSifruZaPraznik()
        {
            try
            {
                komanda.CommandText = "Select Max(PraznikID) from Praznik";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public int vratiSifruZaPoruku()
        {
            try
            {
                komanda.CommandText = "Select Max(PorukaID) from Poruka";
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public int vratiSifruZaPoruke()
        {
            try
            {
                string upit = "Select Max(PorukaID) from Poruka";
                komanda = new OleDbCommand(upit, konekcija, transakcija);
                int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                return sifra + 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        
        public int vratiBrojSlobodnihDana(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select UkupnoZaKoriscenje from GodisnjiOdmor where RadnikID=" + r.RadnikID + "";
                int brojDana = Convert.ToInt32(komanda.ExecuteScalar());
                return brojDana;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }


        
        public List<Poruka> vratiPorukuZaRadnika(Radnik r)
        {
            List<Poruka> lista = new List<Poruka>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Poruka.PorukaID, Radnik.RadnikID, Radnik.Ime, Radnik.Prezime, Poruka.Posaljilac, Poruka.Primalac, Poruka.Tekst FROM Poruka inner join Radnik on Poruka.Posaljilac=Radnik.RadnikID Where Poruka.Primalac="+r.RadnikID+"";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Poruka p = new Poruka();
                    p.PorukaID = citac.GetInt32(0);
                    Radnik posaljilac = new Radnik();
                    posaljilac.RadnikID = citac.GetInt32(1);
                    posaljilac.Ime = citac.GetString(2);
                    posaljilac.Prezime = citac.GetString(3);
                    
                    p.Posaljilac = posaljilac;
                    p.Primalac = r;
                    p.Tekst = citac.GetString(6);

                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public int vratiBrojSatiZaRadnika(Satnica s)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Satnica.BrojSati FROM Satnica Where SatnicaID="+s.SatnicaID+"";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Satnica satnica = new Satnica();
                    satnica.BrojSati = citac.GetInt32(0);
                    
                    return s.BrojSati;
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public List<Prolasci> vratiDatumeZaCalendar()
        {
            List<Prolasci> lista = new List<Prolasci>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select VremeProlaska From Prolasci";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Prolasci p = new Prolasci();
                    p.VremeProlaska = citac.GetDateTime(0);

                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
        }
        
        public int sacuvajRadnika(Radnik r)
        {
            try
            {
                konekcija.Open();
                r.RadnikID = vratiSifruZaRadnika();
                komanda.CommandText = "Insert into Radnik Values (" + r.RadnikID + ",'" + r.Ime + "','" + r.Prezime + "','" + r.DatumRodjenja.ToString("dd.MM.yyyy") + "','" + r.Posao + "'," + r.Plata + ",'" + r.Ime.ToLower() + "','" + r.Prezime.ToLower() + "'," + r.Odeljenje.OdeljenjeID + ","+r.Privilegija+","+r.Satnica.SatnicaID+")";
                
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public void sacuvajGodisnjiOdmor(GodisnjiOdmor go)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Insert into GodisnjiOdmor Values (" + go.Radnik.RadnikID + "," + go.Godina + "," + go.OdobrenBroj + "," + go.UkupnoZaKoriscenje + "," + go.Iskorisceno + ")";
                komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajOdeljenje(Odeljenje o)
        {
            try
            {
                konekcija.Open();
                o.OdeljenjeID = vratiSifruZaOdeljenje();
                komanda.CommandText = "Insert into Odeljenje Values (" + o.OdeljenjeID + ",'" + o.Naziv + "'," + o.SefOdeljenja.RadnikID + "," + o.BrojZaposlenih + ")";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajKapiju(Kapija k)
        {
            try
            {
                konekcija.Open();
                k.KapijaID = vratiSifruZaKapiju();
                komanda.CommandText = "Insert into Kapija Values (" + k.KapijaID + ",'" + k.Naziv + "','" + k.Opis + "'," + k.Lokacija.LokacijaID + ")";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajLokaciju(Lokacija l)
        {
            try
            {
                konekcija.Open();
                l.LokacijaID = vratiSifruZaLokaciju();
                komanda.CommandText = "Insert into Lokacija Values (" + l.LokacijaID + ",'" + l.Naziv + "','" + l.Opis + "')";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajProlazak(Prolasci p)
        {
            try
            {
                konekcija.Open();
                p.ProlazakID = vratiSifruZaProlazak();
                komanda.CommandText = "Insert into Prolasci Values (" + p.ProlazakID + "," + p.Radnik.RadnikID + ",'" + p.Pravac +"','" + p.VremeProlaska.ToShortDateString() +"',"+p.Kapija.KapijaID+")";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajProlaske(BindingList<Prolasci> listaRadnika)
        {

            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();

                foreach (Prolasci p in listaRadnika)
                {
                    p.ProlazakID = vratiSifruZaProlaske();

                    string upit = "Insert into Prolasci Values(" + p.ProlazakID + "," + p.Radnik.RadnikID + ",'" + p.Pravac + "','" + p.VremeProlaska.ToString("dd.MM.yyyy HH:mm:ss") + "'," + p.Kapija.KapijaID+ ")";
                    komanda = new OleDbCommand(upit, konekcija, transakcija);
                    komanda.ExecuteNonQuery();
                }
                transakcija.Commit();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                transakcija.Rollback();
                return 0;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public int sacuvajPauzu(Pauza p)
        {
            try
            {
                konekcija.Open();
                p.PauzaID = vratiSifruZaPauzu();
                komanda.CommandText = "Insert into Pauza Values (" + p.PauzaID + ",'" + p.Naziv + "'," + p.DuzinaPauze + ")";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajDnevnik(Dnevnik d)
        {
            try
            {
                konekcija.Open();
                
                komanda.CommandText = "Insert into Dnevnik Values (" + d.Radnik.RadnikID + ",'" + d.Ponedeljak + "','" + d.Utorak + "','" + d.Sreda + "','" + d.Cetvrtak + "','" + d.Petak + "')";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajPraznik(Praznik p)
        {
            try
            {
                konekcija.Open();
                p.PraznikID = vratiSifruZaPraznik();
                komanda.CommandText = "Insert into Praznik Values(" + p.PraznikID + ",'" + p.Naziv + "','" + p.DatumPraznika.ToString("dd.MM.yyyy HH:mm") + "')";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajPoruku(Poruka p)
        {
            try
            {
                konekcija.Open();
                p.PorukaID = vratiSifruZaPoruku();
                komanda.CommandText = "Insert into Poruka Values(" + p.PorukaID + "," +p.Posaljilac.RadnikID +"," + p.Primalac.RadnikID + ",'" + p.Tekst + "')";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public int sacuvajPoruke(Poruka p,List<Radnik> listaRadnika)
        {
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                foreach (Radnik radnik in listaRadnika)
                {
                    p.PorukaID = vratiSifruZaPoruke();
                    string upit= "Insert into Poruka Values(" + p.PorukaID + "," + p.Posaljilac.RadnikID + "," + radnik.RadnikID + ",'" + p.Tekst + "')";
                    komanda = new OleDbCommand(upit, konekcija, transakcija);
                    komanda.ExecuteNonQuery();
                }

                transakcija.Commit();
                return 1; 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                transakcija.Rollback();

                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajOdmor(OdmorDan o)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Insert into Odmor Values(" + o.Radnik.RadnikID + ",'" + o.DatumOd.ToString("dd.MM.yyyy") + "','" + o.DatumDo.ToString("dd.MM.yyyy") + "')";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajPropusnicu(Propusnica p)
        {
            try
            {
                konekcija.Open();
                p.PropusnicaID = vratiSifruZaPropusnicu();
                komanda.CommandText = "Insert into Propusnica Values(" + p.PropusnicaID+ ",'" + p.Ime + "','" +p.Prezime+ "','" + p.Razlog + "','" + p.Datum.ToString("dd.MM.yyyy")+"')";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int sacuvajSatnicu(Satnica s)
        {
            try
            {
                konekcija.Open();
                s.SatnicaID = vratiSifruZaSatnicu();
                komanda.CommandText = "Insert into Satnica Values (" + s.SatnicaID + ",'" + s.Naziv + "','" + s.Opis + "'," + s.BrojSati + ")";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public int izmeniLokaciju(Lokacija l)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Lokacija Set Naziv='" + l.Naziv + "', Opis='" + l.Opis + "' where LokacijaID="+l.LokacijaID+"";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniKapiju(Kapija k)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Kapija Set Naziv='" + k.Naziv + "', Opis='" + k.Opis + "', LokacijaID="+k.Lokacija.LokacijaID+" where KapijaID=" + k.KapijaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniOdeljenje(Odeljenje o)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Odeljenje Set Naziv='" + o.Naziv + "', SefOdeljenja=" + o.SefOdeljenja.RadnikID + ", BrojZaposlenih=" + o.BrojZaposlenih+ " where OdeljenjeID=" + o.OdeljenjeID+ "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public void izmeniBrojZaposlenihUOdeljenju(Odeljenje o,int brojZaposlenih)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Odeljenje Set BrojZaposlenih=" + brojZaposlenih + " where OdeljenjeID=" + o.OdeljenjeID + "";
                komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Greska");
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniProlazak(Prolasci p)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Prolasci Set RadnikID=" + p.Radnik.RadnikID + ", Pravac='" + p.Pravac + "', VremeProlaska='" + p.VremeProlaska.ToShortDateString() + "', KapijaID=" + p.Kapija.KapijaID + " where ProlazakID=" + p.ProlazakID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniRadnika(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Radnik Set Ime='" + r.Ime + "', Prezime='" + r.Prezime + "', DatumRodjenja='" + r.DatumRodjenja.ToString("dd.MM.yyyy") + "', Posao='" + r.Posao + "', Plata=" + r.Plata + ", OdeljenjeID="+r.Odeljenje.OdeljenjeID+", Privilegija="+r.Privilegija+" where RadnikID=" + r.RadnikID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniPauzu(Pauza p)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Pauza Set Naziv='" + p.Naziv + "', DuzinaPauze=" + p.DuzinaPauze + " where PauzaID=" + p.PauzaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniSatnicu(Satnica s)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Satnica Set Naziv='" + s.Naziv + "',Opis='" + s.Opis + "', BrojSati=" + s.BrojSati + " where SatnicaID=" + s.SatnicaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniPraznik(Praznik p)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Praznik Set Naziv='" + p.Naziv + "',DatumPraznika='" + p.DatumPraznika.ToString("dd.MM.yyyy HH:mm") + "' where PraznikID=" + p.PraznikID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniPropusnice(Propusnica p)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Propusnica Set Ime='" + p.Ime + "',Prezime='" + p.Prezime+ "',Razlog='" + p.Razlog + "',Datum='" + p.Datum.ToString("dd.MM.yyyy")+"' where PropusnicaID=" + p.PropusnicaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniGodisnjiOdmor(GodisnjiOdmor g)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update GodisnjiOdmor Set Godina=" + g.Godina + ",OdobrenBroj=" + g.OdobrenBroj + ",UkupnoZaKoriscenje=" + g.UkupnoZaKoriscenje + ",Iskorisceno=" + g.Iskorisceno + " where RadnikID=" + g.Radnik.RadnikID+ "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int izmeniSlobodneDane(GodisnjiOdmor g,double brojD)
        {
            try
            {
                konekcija.Open();
                g.UkupnoZaKoriscenje = Convert.ToInt32(g.UkupnoZaKoriscenje - brojD);
                g.Iskorisceno = Convert.ToInt32(g.Iskorisceno + brojD);
                komanda.CommandText = "Update GodisnjiOdmor Set UkupnoZaKoriscenje=" + g.UkupnoZaKoriscenje + ",Iskorisceno=" + g.Iskorisceno + " where RadnikID=" + g.Radnik.RadnikID + "";

                return komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public void izmeniOdeljenjeRadnika(Radnik r,Odeljenje o)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Update Radnik Set OdeljenjeID=" + o.OdeljenjeID + " where RadnikID=" + r.RadnikID + "";
                komanda.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public int obrisiLokaciju(Lokacija l)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Lokacija where LokacijaID=" + l.LokacijaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiRadnika(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Radnik where RadnikID=" + r.RadnikID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiKapiju(Kapija k)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Kapija where KapijaID=" + k.KapijaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiOdeljenje(Odeljenje o)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Odeljenje where OdeljenjeID=" + o.OdeljenjeID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiProlazak(Prolasci p)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Prolasci where ProlazakID=" + p.ProlazakID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiPauzu(Pauza p)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Pauza where PauzaID=" + p.PauzaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public void obrisiSlobodneDane(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Odmor where RadnikID=" + r.RadnikID+ "";
                komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Grekska!");
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiSatnicu(Satnica s)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Satnica where SatnicaID=" + s.SatnicaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiPraznik(Praznik p)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Praznik where PraznikID=" + p.PraznikID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiDnevnik(Dnevnik d)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Dnevnik where RadnikID=" + d.Radnik.RadnikID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiPorukeZaRadnika(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Poruka where Primalac=" + r.RadnikID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiPropusnicu(Propusnica p)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from Propusnica where PropusnicaID=" + p.PropusnicaID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public int obrisiGodisnjiOdmor(GodisnjiOdmor g)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "Delete from GodisnjiOdmor where RadnikID=" + g.Radnik.RadnikID + "";
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public List<Lokacija> vratiLokacijuPretraga(string naziv,string opis)
        {
            List<Lokacija> lista = new List<Lokacija>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * From Lokacija";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Lokacija lo = new Lokacija();
                    lo.LokacijaID = citac.GetInt32(0);
                    lo.Naziv = citac.GetString(1);
                    lo.Opis = citac.GetString(2);

                    if (lo.Naziv==naziv || lo.Opis==opis)
                    {
                        lista.Add(lo);
                    }
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Satnica> vratiSatnicuPretraga(string naziv,string opis,int brojSati)
        {
            List<Satnica> lista = new List<Satnica>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * From Satnica";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Satnica s = new Satnica();
                    s.SatnicaID = citac.GetInt32(0);
                    s.Naziv = citac.GetString(1);
                    s.Opis = citac.GetString(2);
                    s.BrojSati = citac.GetInt32(3);

                    if (s.Naziv==naziv || s.Opis==opis || s.BrojSati==brojSati)
                    {
                        lista.Add(s);
                    }
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Pauza> vratiPauzuPretraga(string naziv,int duzinaPauze)
        {
            List<Pauza> lista = new List<Pauza>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * From Pauza";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Pauza p = new Pauza();
                    p.PauzaID = citac.GetInt32(0);
                    p.Naziv = citac.GetString(1);
                    p.DuzinaPauze = citac.GetInt32(2);

                    if (p.Naziv == naziv || p.DuzinaPauze == duzinaPauze)
                    {
                        lista.Add(p);
                    }
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<GodisnjiOdmor> vratiGodisnjiOdmorPretraga(int godina,int ukupno)
        {
            List<GodisnjiOdmor> lista = new List<GodisnjiOdmor>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, GodisnjiOdmor.RadnikID AS GodisnjiOdmor_RadnikID, GodisnjiOdmor.Godina, GodisnjiOdmor.OdobrenBroj, GodisnjiOdmor.UkupnoZaKoriscenje, GodisnjiOdmor.Iskorisceno FROM Radnik INNER JOIN GodisnjiOdmor ON Radnik.[RadnikID] = GodisnjiOdmor.[RadnikID]";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);
                    GodisnjiOdmor g = new GodisnjiOdmor();
                    g.Radnik = r;
                    g.Godina = citac.GetInt32(4);
                    g.OdobrenBroj = citac.GetInt32(5);
                    g.UkupnoZaKoriscenje = citac.GetInt32(6);
                    g.Iskorisceno = citac.GetInt32(7);

                    if (g.Godina==godina || g.UkupnoZaKoriscenje==ukupno)
                    {
                        lista.Add(g);
                    }
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Propusnica> vratiPropusnicuPretraga(string ime, string prezime, string razlog, DateTime datum)
        {
            List<Propusnica> lista = new List<Propusnica>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * From Propusnica";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Propusnica p = new Propusnica();
                    p.PropusnicaID = citac.GetInt32(0);
                    p.Ime = citac.GetString(1);
                    p.Prezime = citac.GetString(2);
                    p.Razlog = citac.GetString(3);
                    p.Datum = citac.GetDateTime(4);

                    if (p.Ime == ime || p.Prezime == prezime|| p.Razlog== razlog|| p.Datum== datum)
                    {
                        lista.Add(p);
                    }
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Praznik> vratiPraznikPretraga(string naziv, DateTime datumPraznika)
        {
            List<Praznik> lista = new List<Praznik>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * From Praznik";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Praznik p = new Praznik();
                    p.PraznikID = citac.GetInt32(0);
                    p.Naziv = citac.GetString(1);
                    p.DatumPraznika = citac.GetDateTime(2);

                    if (p.Naziv == naziv || p.DatumPraznika == datumPraznika)
                    {
                        lista.Add(p);
                    }
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Kapija> vratiKapijePretraga(string naziv,string opis,string lokacija)
        {
            List<Kapija> lista = new List<Kapija>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * From Lokacija inner join Kapija on Lokacija.LokacijaID=Kapija.LokacijaID";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Lokacija l = new Lokacija();
                    l.LokacijaID = citac.GetInt32(0);
                    l.Naziv = citac.GetString(1);
                    l.Opis = citac.GetString(2);


                    Kapija ka = new Kapija();
                    ka.KapijaID = citac.GetInt32(3);
                    ka.Naziv = citac.GetString(4);
                    ka.Opis = citac.GetString(5);
                    ka.Lokacija = l;

                    if (ka.Naziv==naziv || ka.Opis==opis || ka.Lokacija.Naziv==lokacija)
                    {
                        lista.Add(ka);
                    }
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Odeljenje> vratiOdeljenjePretraga(string naziv,string ime,string prezime, int brojZaposlenih)
        {
            List<Odeljenje> lista = new List<Odeljenje>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID, Radnik.Ime, Radnik.Prezime, Radnik.DatumRodjenja, Radnik.Posao, Radnik.Plata, Radnik.Username, Radnik.Password, Odeljenje.OdeljenjeID AS Odeljenje_OdeljenjeID, Odeljenje.Naziv, Odeljenje.SefOdeljenja, Odeljenje.BrojZaposlenih FROM Odeljenje INNER JOIN Radnik ON Odeljenje.[OdeljenjeID] = Radnik.[OdeljenjeID]";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);
                    r.DatumRodjenja = citac.GetDateTime(3);
                    r.Posao = citac.GetString(4);
                    r.Plata = citac.GetInt32(5);
                    r.Username = citac.GetString(6);
                    r.Password = citac.GetString(7);

                    Odeljenje od = new Odeljenje();
                    od.OdeljenjeID = citac.GetInt32(8);
                    od.Naziv = citac.GetString(9);
                    od.SefOdeljenja = r;
                    od.BrojZaposlenih= citac.GetInt32(11);

                    if (od.Naziv==naziv || od.SefOdeljenja.Ime==ime || od.SefOdeljenja.Prezime==prezime || od.BrojZaposlenih== brojZaposlenih)
                    {
                        lista.Add(od);
                    }
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Prolasci> vratiProlaskePretraga(string ime,string prezime,string pravac,string kapija)
        {
            List<Prolasci> lista = new List<Prolasci>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Prolasci.ProlazakID, Prolasci.RadnikID AS Prolasci_RadnikID, Prolasci.Pravac, Prolasci.VremeProlaska, Kapija.KapijaID AS Kapija_KapijaID, Kapija.Naziv, Prolasci.KapijaID AS Prolasci_KapijaID FROM Kapija INNER JOIN(Radnik INNER JOIN Prolasci ON Radnik.[RadnikID] = Prolasci.[RadnikID]) ON Kapija.[KapijaID] = Prolasci.[KapijaID]";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Prolasci pr = new Prolasci();
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);

                    pr.ProlazakID = citac.GetInt32(3);
                    pr.Radnik = r;
                    pr.Pravac = citac.GetString(5);
                    pr.VremeProlaska = citac.GetDateTime(6);
                    Kapija k = new Kapija();
                    k.KapijaID = citac.GetInt32(7);
                    k.Naziv = citac.GetString(8);
                    pr.Kapija = k;

                    if(pr.Radnik.Ime==ime|| pr.Radnik.Prezime==prezime || pr.Pravac==pravac ||pr.Kapija.Naziv==kapija)
                    {
                        lista.Add(pr);
                    }

                    
                }
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Radnik> vratiRadnikePretraga(string ime,string prezime,DateTime datum,string posao,string odeljenje)
        {
            List<Radnik> lista = new List<Radnik>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Odeljenje.OdeljenjeID AS Odeljenje_OdeljenjeID, Odeljenje.Naziv, Radnik.RadnikID, Radnik.Ime, Radnik.Prezime, Radnik.DatumRodjenja, Radnik.Posao, Radnik.Plata, Radnik.Username, Radnik.Password, Radnik.OdeljenjeID AS Radnik_OdeljenjeID, Radnik.Privilegija FROM Odeljenje INNER JOIN Radnik ON Odeljenje.[OdeljenjeID] = Radnik.[OdeljenjeID]";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik ra = new Radnik();
                    Odeljenje o = new Odeljenje();
                    o.OdeljenjeID = citac.GetInt32(0);
                    o.Naziv = citac.GetString(1);
                    ra.RadnikID = citac.GetInt32(2);
                    ra.Ime = citac.GetString(3);
                    ra.Prezime = citac.GetString(4);
                    ra.DatumRodjenja = citac.GetDateTime(5);
                    ra.Posao = citac.GetString(6);
                    ra.Plata = citac.GetInt32(7);
                    ra.Username = citac.GetString(8);
                    ra.Password = citac.GetString(9);
                    ra.Odeljenje = o;
                    ra.Privilegija = citac.GetInt32(11);

                    if (ra.Ime==ime || ra.Prezime==prezime || ra.DatumRodjenja==datum || ra.Posao==posao || ra.Odeljenje.Naziv==odeljenje)
                    {
                        lista.Add(ra);
                    }
                    
                }
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Dnevnik> vratiDnevnikeZaSefa(Radnik radnik)
        {
            List<Dnevnik> lista = new List<Dnevnik>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Dnevnik.RadnikID AS Dnevnik_RadnikID, Dnevnik.Ponedeljak, Dnevnik.Utorak, Dnevnik.Sreda, Dnevnik.Cetvrtak, Dnevnik.Petak FROM Radnik INNER JOIN Dnevnik ON Radnik.[RadnikID] = Dnevnik.[RadnikID] Where Radnik.OdeljenjeID=(Select Odeljenje.OdeljenjeID From Odeljenje Where SefOdeljenja="+radnik.RadnikID+")";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);

                    Dnevnik d = new Dnevnik();
                    d.Radnik = r;
                    d.Ponedeljak = citac.GetString(4);
                    d.Utorak = citac.GetString(5);
                    d.Sreda = citac.GetString(6);
                    d.Cetvrtak = citac.GetString(7);
                    d.Petak = citac.GetString(8);

                    lista.Add(d);

                }
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public OdmorDan vratiOdmorZaRadnika(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Odmor.RadnikID AS Odmor_RadnikID, Odmor.DatumOd, Odmor.DatumDo FROM Radnik INNER JOIN Odmor ON Radnik.[RadnikID] = Odmor.[RadnikID] Where Radnik.RadnikID="+r.RadnikID+"";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);

                    OdmorDan o = new OdmorDan();

                    o.Radnik = r;
                    o.DatumOd = citac.GetDateTime(4);
                    o.DatumDo = citac.GetDateTime(5);

                    return o;
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }

        public bool daLiJeNaPosluRadnik(Prolasci p,DateTime danasnjiDatum,string pravac)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Lokacija.LokacijaID AS Lokacija_LokacijaID, Lokacija.Naziv AS Lokacija_Naziv, Kapija.KapijaID AS Kapija_KapijaID, Kapija.Naziv AS Kapija_Naziv, Kapija.Opis, Kapija.LokacijaID AS Kapija_LokacijaID, Prolasci.ProlazakID, Prolasci.RadnikID AS Prolasci_RadnikID, Prolasci.Pravac, Prolasci.VremeProlaska, Prolasci.KapijaID AS Prolasci_KapijaID FROM Radnik INNER JOIN((Lokacija INNER JOIN Kapija ON Lokacija.[LokacijaID] = Kapija.[LokacijaID]) INNER JOIN Prolasci ON Kapija.[KapijaID] = Prolasci.[KapijaID]) ON Radnik.[RadnikID] = Prolasci.[RadnikID] Where Prolasci.RadnikID="+p.Radnik.RadnikID+" And '"+p.VremeProlaska.Date+"'='"+ danasnjiDatum + "' And '"+p.Pravac+"'='"+pravac+"'";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);

                    Lokacija l = new Lokacija();
                    l.LokacijaID = citac.GetInt32(3);
                    l.Naziv = citac.GetString(4);

                    Kapija k = new Kapija();
                    k.KapijaID = citac.GetInt32(5);
                    k.Naziv = citac.GetString(6);
                    k.Opis = citac.GetString(7);
                    k.Lokacija = l;
                    

                    p.Radnik = r;
                    p.Pravac = citac.GetString(11);
                    p.VremeProlaska = citac.GetDateTime(12);
                    p.Kapija = k;


                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }

        public bool daLiJeNaOdmoruRadnik(OdmorDan o, DateTime datum)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Odmor.RadnikID AS Odmor_RadnikID, Odmor.DatumOd, Odmor.DatumDo FROM Radnik INNER JOIN Odmor ON Radnik.[RadnikID] = Odmor.[RadnikID] Where Odmor.RadnikID="+o.Radnik.RadnikID+" AND '"+o.DatumOd+"'<='"+datum+"' And '"+o.DatumDo+"'>='"+datum+"'";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Radnik r = new Radnik();
                    r.RadnikID = citac.GetInt32(0);
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);

                    o.Radnik = r;
                    o.DatumOd = citac.GetDateTime(4);
                    o.DatumDo = citac.GetDateTime(5);

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public bool daLiJeUnesenDnevnikRada(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Radnik.RadnikID AS Radnik_RadnikID, Radnik.Ime, Radnik.Prezime, Dnevnik.RadnikID AS Dnevnik_RadnikID, Dnevnik.Ponedeljak, Dnevnik.Utorak, Dnevnik.Sreda, Dnevnik.Cetvrtak, Dnevnik.Petak FROM Radnik INNER JOIN Dnevnik ON Radnik.[RadnikID] = Dnevnik.[RadnikID] Where Dnevnik.RadnikID=" + r.RadnikID + "";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);

                    Dnevnik d = new Dnevnik();
                    d.Radnik = r;
                    d.Ponedeljak = citac.GetString(4);
                    d.Utorak = citac.GetString(5);
                    d.Sreda = citac.GetString(6);
                    d.Cetvrtak = citac.GetString(7);
                    d.Petak = citac.GetString(8);

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public bool daLiJeDanasPraznik(Praznik pr,DateTime datum)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText = "SELECT Praznik.[PraznikID], Praznik.[Naziv], Praznik.[DatumPraznika] FROM Praznik Where '"+pr.DatumPraznika+"' ='" + datum+"'";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Praznik p = new Praznik();
                    p.PraznikID = citac.GetInt32(0);
                    p.Naziv = citac.GetString(1);
                    p.DatumPraznika = citac.GetDateTime(2);

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }


        public bool daLiJeRadnikSefOdeljenja(Radnik r)
        {
            try
            {
                konekcija.Open();
                komanda.CommandText= "SELECT Radnik.RadnikID, Radnik.Ime, Radnik.Prezime, Odeljenje.OdeljenjeID, Odeljenje.Naziv, Odeljenje.SefOdeljenja, Odeljenje.BrojZaposlenih FROM Odeljenje INNER JOIN Radnik ON Odeljenje.[OdeljenjeID] = Radnik.[OdeljenjeID] Where Odeljenje.SefOdeljenja="+r.RadnikID+"";
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    r.Ime = citac.GetString(1);
                    r.Prezime = citac.GetString(2);

                    Odeljenje o = new Odeljenje();
                    o.OdeljenjeID = citac.GetInt32(3);
                    o.Naziv = citac.GetString(4);
                    o.SefOdeljenja = r;
                    o.BrojZaposlenih = citac.GetInt32(6);

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }

        public List<Prolasci> vratiListuRadnikaZaCalendarINOUT(List<Prolasci> listaProlazaka,DateTime datum)
        {
            List<Prolasci> lista = new List<Prolasci>();

            try
            {
                konekcija.Open();
                foreach (Prolasci prolazak in listaProlazaka)
                {
                    DateTime pom = prolazak.VremeProlaska.Date;
                    if (pom == datum)
                    {
                         lista.Add(prolazak);
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                return null ;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        

    }

    
}
