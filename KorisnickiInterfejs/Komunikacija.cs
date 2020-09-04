using Biblioteka;
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

namespace KorisnickiInterfejs
{
    public class Komunikacija
    {
        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formater = new BinaryFormatter();

        public Komunikacija()
        {
        }
        
        public bool poveziSeNaServer()
        {
            try
            {
                klijent = new TcpClient("127.0.0.1", 11000);                
                tok = klijent.GetStream();                
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public void izbaciMessageBox()
        {
            MessageBox.Show("Radi");
        }
        
        public void kraj()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.Kraj;
            formater.Serialize(tok, transfer);
        }
        internal Radnik prijava(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.prijava;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as Radnik;
        }
        public void posaljiNaServerProlazak(Prolasci prolazak)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.prolazak;
            transfer.TransferObjekat = prolazak;
            formater.Serialize(tok, transfer);
        }
        public bool posaljiNaServerRadnika(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.radnik;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.DaLiJe;
        }
        public bool daLiJeRadnikPrijavljen(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.daLiJePrijavljen;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);
            
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.DaLiJe;

        }
        public bool daLiJeDanasPraznik(Praznik p,DateTime datum)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.daLiJeDanasPraznik;
            transfer.TransferObjekat = p;
            transfer.Datum = datum;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.DaLiJe;

        }
        public bool daLiJeRadnikNaPoslu(Prolasci p,DateTime datum,string pravac)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.daLiJeRadnikNaPoslu;
            transfer.TransferObjekat = p;
            transfer.Datum = datum;
            transfer.String = pravac;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.DaLiJe;
        }
        public bool daLiJeDnevnikRadaUnesen(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.daLiJeDnevnikRadaUnesen;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.DaLiJe;
        }
        public bool daLiJeRadnikSefOdeljenja(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.daLiJeRadnikSefOdeljenja;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.DaLiJe;
        }
        public List<Kapija> vratiListuKapija()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiKapije;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Kapija>;
        }
        public List<Lokacija> vratiListuLokacija()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiLokacije;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Lokacija>;
        }
        public List<Odeljenje> vratiListuOdeljenja()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiOdeljenja;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Odeljenje>;
        }
        public List<Radnik> vratiListuRadnika()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiRadnike;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Radnik>;
        }
        public List<Prolasci> vratiListuProlazaka()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiProlaske;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Prolasci>;
        }
        public List<GodisnjiOdmor> vratiListuGodisnjihOdmora()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiGodisnjeOdmore;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<GodisnjiOdmor>;
        }
        public List<Propusnica> vratiListuPropusnica()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiPropusnice;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Propusnica>;
        }
        public List<Praznik> vratiListuPraznika()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiPraznike;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Praznik>;
        }
        public List<Satnica> vratiListuSatnica()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiSatnice;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Satnica>;
        }
        public List<Pauza> vratiListuPauza()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiPauze;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Pauza>;
        }
        public bool daLiJeRadnikNaOdmoru(OdmorDan o,DateTime datum)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.daLiJeRadnikNaOdmoru;
            transfer.TransferObjekat = o;
            transfer.Datum = datum;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.DaLiJe;
        }
        public List<OdmorDan> vratiSlobodneDane()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiSlobodneDane;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<OdmorDan>;
        }
        public List<Radnik> vratiRadnikaZaComboBox(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiRadnikaZaComboBox;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Radnik>;
        }
        public Radnik vratiRadnikaZaGodisnjiOdmor(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiRadnikaZaGodisnjiOdmor;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as Radnik;
        }
        public List<Radnik> vratiRadnikaZaOdeljenje(Odeljenje o)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiRadnikaZaOdeljenje;
            transfer.TransferObjekat = o;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Radnik>;
        }
        

        public List<Prolasci> vratiListuRadnikaZaCalendarINOUT(List<Prolasci> listaProlazaka,DateTime datum)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiListuRadnikaZaCalendarINOUT;
            transfer.TransferObjekat = listaProlazaka;
            transfer.Datum = datum;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Prolasci>;
        }
        public int vratiBrojZaposlenihZaIzmenuRadnika(Odeljenje o)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiBrojZaposlenihZaIzmenuRadnika;
            transfer.TransferObjekat = o;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int vratiBrojZaposlenihZaOdeljenje(string posao)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiBrojZaposlenihZaOdeljenje;
            transfer.String=posao;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public List<Prolasci> vratiDatumeZaCalendar()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiDatumeZaCalendar;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Prolasci>;
        }
        public List<Dnevnik> vratiDnevnikeZaSefa(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiDnevnikeZaSefa;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Dnevnik>;
        }
        public List<Poruka> vratiPorukeZaRadnika(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiPorukeZaRadnika;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Poruka>;
        }
        public int obrisiPorukeZaRadnika(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiPorukuZaRadnika;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }

        public GodisnjiOdmor vratiGodisnjiOdmorZaRadnika(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiGodisnjiOdmorZaRadnika;
            transfer.TransferObjekat=r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as GodisnjiOdmor;
        }
        public List<GodisnjiOdmor> vratiGodisnjeOdmorePretraga(int godina,int ukupno)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiGodisnjiOdmorPretraga;
            transfer.Broj = godina;
            transfer.Rezultat = ukupno;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<GodisnjiOdmor>;
        }
        public List<Propusnica> vratiPropusnicePretraga(string ime, string prezime, string razlog, DateTime datum)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiPropusnicePretraga;
            transfer.String=ime;
            transfer.String1 = prezime;
            transfer.TransferObjekat = razlog;
            transfer.Datum = datum;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Propusnica>;
        }
        public List<Praznik> vratiPraznikePretraga(string naziv,DateTime datum)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiPraznikePretraga;
            transfer.String = naziv;
            transfer.Datum = datum;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Praznik>;
        }
        public List<Kapija> vratiKapijePretraga(string naziv,string opis,string lokacija)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiKapijePretraga;
            transfer.String = naziv;
            transfer.TransferObjekat = opis;
            transfer.Rezultat = lokacija;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Kapija>;
        }
        public List<Lokacija> vratiLokacijePretraga(string naziv, string opis)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiLokacijePretraga;
            transfer.String = naziv;
            transfer.String1 = opis;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Lokacija>;
        }
        public List<Odeljenje> vratiOdeljenjePretraga(string naziv, string ime, string prezime,int brojZaposlenih)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiOdeljenjePretraga;
            transfer.String = naziv;
            transfer.TransferObjekat = ime;
            transfer.Rezultat = prezime;
            transfer.Broj = brojZaposlenih;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Odeljenje>;
        }
        public List<Prolasci> vratiProlaskePretraga(string naziv, string ime, string prezime, string kapija)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiProlaskePretraga;
            transfer.String = naziv;
            transfer.TransferObjekat = ime;
            transfer.Rezultat = prezime;
            transfer.String1 = kapija ;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Prolasci>;
        }
        public List<Radnik> vratiRadnikePretraga(string ime, string prezime,DateTime datum, string posao, string odeljenje)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiRadnikePretraga;
            transfer.String = ime;
            transfer.TransferObjekat = prezime;
            transfer.Datum = datum;
            transfer.Rezultat = posao;
            transfer.String1 = odeljenje;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Radnik>;
        }
        public int vratiBrojMinutaPauze(string duzina)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiDuzinuPauze;
            transfer.String = duzina;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public List<Pauza> vratiPauzePretraga(string naziv, int duzinaPauze)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiPauzePretraga;
            transfer.String = naziv;
            transfer.Broj = duzinaPauze;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Pauza>;
        }
        public List<Satnica> vratiSatnicePretraga(string naziv,string opis, int brojSati)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiSatnicePretraga;
            transfer.String = naziv;
            transfer.String1 = opis;
            transfer.Broj = brojSati;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<Satnica>;
        }
        public OdmorDan vratiOdmorZaRadnika(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiOdmorZaRadnika;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as OdmorDan;
        }
        public int vratiBrojSatiZaRadnika(Satnica s)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiBrojSatiZaRadnika;
            transfer.TransferObjekat = s;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public Radnik vratiZaboravljenuLozinku(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiZaboravljenuLozinku;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as Radnik;
        }

        public int sacuvajDnevnikRada(Dnevnik d)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajDnevnikRada;
            transfer.TransferObjekat = d;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajRadnika(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajRadnika;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajOdeljenje(Odeljenje o)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajOdeljenje;
            transfer.TransferObjekat = o;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajKapiju(Kapija k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajKapiju;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajLokaciju(Lokacija l)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajLokaciju;
            transfer.TransferObjekat = l;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajSatnicu(Satnica s)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajSatnicu;
            transfer.TransferObjekat = s;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajPraznik(Praznik p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajPraznik;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajPropusnicu(Propusnica p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajPropusnicu;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajOdmor(OdmorDan o)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajOdmor;
            transfer.TransferObjekat = o;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.TransferObjekat;
        }
        public void sacuvajGodisnjiOdmor(GodisnjiOdmor go)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajGodisnjiOdmor;
            transfer.TransferObjekat = go;
            formater.Serialize(tok, transfer);

            //transfer = formater.Deserialize(tok) as TransferKlasa;
            //return (int)transfer.Rezultat;
        }
        public int sacuvajProlaske(BindingList<Prolasci> lista)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajProlaske;
            transfer.TransferObjekat = lista;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajProlazak(Prolasci p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajProlazak;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int sacuvajPauzu(Pauza p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajPauzu;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        
        public int sacuvajPoruku(Poruka p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajPoruku;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }

        public int sacuvajPoruke(Poruka p,List<Radnik> listaRadnika)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajPoruke;
            transfer.TransferObjekat = p;
            transfer.Rezultat = listaRadnika;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int obrisiRadnika(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiRadnika;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiOdeljenje(Odeljenje o)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiOdeljenje;
            transfer.TransferObjekat = o;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiKapiju(Kapija k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiKapiju;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiLokaciju(Lokacija l)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiLokaciju;
            transfer.TransferObjekat = l;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiPraznik(Praznik p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiPraznik;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiPropusnicu(Propusnica p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiPropusnicu;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiGodisnjiOdmor(GodisnjiOdmor go)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiGodisnjiOdmor;
            transfer.TransferObjekat = go;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiPauzu(Pauza p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiPauzu;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiSatnicu(Satnica s)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiSatnicu;
            transfer.TransferObjekat = s;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int obrisiDnevnik(Dnevnik d)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiDnevnik;
            transfer.TransferObjekat = d;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public void obrisiOdmor(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiOdmor;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);
        }
        public int obrisiProlazak(Prolasci p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.obrisiProlazak;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int izmeniRadnika(Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniRadnika;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int izmeniOdeljenje(Odeljenje o)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniOdeljenje;
            transfer.TransferObjekat = o;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int izmeniKapiju(Kapija k)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniKapiju;
            transfer.TransferObjekat = k;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int izmeniLokaciju(Lokacija l)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniLokaciju;
            transfer.TransferObjekat = l;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int izmeniPraznik(Praznik p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniPraznik;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int izmeniPauzu(Pauza p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniPauzu;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int izmeniPropusnicu(Propusnica p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniPropusnicu;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int izmeniSatnicu(Satnica s)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniSatnicu;
            transfer.TransferObjekat = s;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public void izmeniBrojZaposlenihUOdeljenju(Odeljenje o,int brojZaposlenih)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniBrojZaposlenihUOdeljenju;
            transfer.TransferObjekat = o;
            transfer.Broj = brojZaposlenih;
            formater.Serialize(tok, transfer);
        }
        public void izmeniOdeljenjeRadnika(Radnik r,Odeljenje o)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniOdeljenjeRadnika;
            transfer.TransferObjekat = r;
            transfer.Rezultat=o;
            formater.Serialize(tok, transfer);
        }
        public int izmeniSlobodneDane(GodisnjiOdmor go, double brojDana)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniSlobodneDane;
            transfer.TransferObjekat = go;
            transfer.BrojD = brojDana;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Broj;
        }
        public int izmeniGodisnjiOdmor(GodisnjiOdmor go)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniGodisnjiOdmor;
            transfer.TransferObjekat = go;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }
        public int izmeniProlazak(Prolasci p)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniProlazak;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.Rezultat;
        }

        


        public void odjaviRadnika(Prolasci p,Radnik r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izlazak;
            transfer.TransferObjekat = p;
            formater.Serialize(tok, transfer);

            transfer.Operacija = Operacije.odjaviRadnika;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);
        }
    }
}
