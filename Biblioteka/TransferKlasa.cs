using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public enum Operacije { Kraj = 1,
        listaRadnika = 2,
        listaProlazaka = 3,
        prolazak = 4,
        radnik = 5,
        odjaviRadnika = 6,
        izlazak = 7,
        daLiJePrijavljen = 8,
        vratiKapije = 9,
        vratiRadnikaZaComboBox = 10,
        vratiOdmorZaRadnika = 11,
        vratiLokacije = 12,
        vratiOdeljenja = 13,
        vratiRadnike = 14,
        vratiProlaske = 15,
        vratiGodisnjeOdmore = 16,
        vratiPropusnice = 17,
        vratiPraznike = 18,
        vratiSatnice = 19,
        vratiPauze = 20,
        daLiJeRadnikNaOdmoru = 21,
        sacuvajDnevnikRada = 22,
        sacuvajRadnika = 23,
        sacuvajOdeljenje = 24,
        sacuvajKapiju = 25,
        sacuvajLokaciju = 26,
        sacuvajPropusnicu = 27,
        sacuvajPauzu = 28,
        sacuvajPraznik = 29,
        sacuvajSatnicu = 30,
        sacuvajProlazak = 31,
        sacuvajPoruku = 32,
        sacuvajGodisnjiOdmor = 33,
        sacuvajProlaske = 34,
        sacuvajOdmor = 35,
        obrisiDnevnik = 36,
        obrisiGodisnjiOdmor = 37,
        obrisiRadnika = 38,
        obrisiSatnicu = 39,
        obrisiKapiju = 40,
        obrisiLokaciju = 41,
        obrisiOdeljenje = 42,
        obrisiPauzu = 43,
        obrisiPraznik = 44,
        obrisiProlazak = 45,
        obrisiPropusnicu = 46,
        obrisiSlobodneDane = 47,
        izmeniRadnika = 48,
        izmeniOdeljenje = 49,
        izmeniKapiju = 50,
        izmeniLokaciju = 51,
        izmeniPraznik = 52,
        izmeniPauzu = 53,
        izmeniPropusnicu = 54,
        izmeniSatnicu = 55,
        izmeniSlobodneDane = 56,
        izmeniGodisnjiOdmor = 57,
        izmeniProlazak = 58,
        vratiSlobodneDane = 59,
        vratiZaboravljenuLozinku = 60,
        daLiJeRadnikNaPoslu = 61,
        daLiJeDnevnikRadaUnesen = 62,
        daLiJeRadnikSefOdeljenja = 63,
        izmeniBrojZaposlenihUOdeljenju = 64,
        izmeniOdeljenjeRadnika = 65,
        prijava = 66,
        vratiBrojZaposlenihZaIzmenuRadnika = 67,
        vratiBrojZaposlenihZaOdeljenje = 68,
        vratiDatumeZaCalendar = 69,
        vratiDnevnikeZaSefa = 70,
        vratiGodisnjiOdmorPretraga = 71,
        vratiPropusnicePretraga = 72,
        vratiPraznikePretraga = 73,
        vratiKapijePretraga = 74,
        vratiOdeljenjePretraga = 75,
        vratiRadnikePretraga = 76,
        vratiProlaskePretraga = 77,
        vratiPauzePretraga = 78,
        vratiSatnicePretraga = 79,
        vratiRadnikaZaOdeljenje = 80,
        vratiListuRadnikaZaCalendarINOUT = 81,
        vratiGodisnjiOdmorZaRadnika = 82,
        vratiPorukeZaRadnika = 83,
        obrisiPorukuZaRadnika = 84,
        vratiLokacijePretraga = 85,
        vratiRadnikaZaGodisnjiOdmor = 86,
        vratiBrojSatiZaRadnika = 87,
        daLiJeDanasPraznik = 88,
        sacuvajPoruke = 89,
        vratiDuzinuPauze = 90,
        obrisiOdmor = 91
    }
    [Serializable]
    public class TransferKlasa
    {
        Operacije operacija;

        public Operacije Operacija
        {
            get { return operacija; }
            set { operacija = value; }
        }
        Object transferObjekat;

        public Object TransferObjekat
        {
            get { return transferObjekat; }
            set { transferObjekat = value; }
        }
        Object rezultat;

        public Object Rezultat
        {
            get { return rezultat; }
            set { rezultat = value; }
        }
        bool daLiJe;
        public bool DaLiJe
        {
            get { return daLiJe; }
            set { daLiJe = value; }
        }
        DateTime datum;
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        string s;
        public string String
        {
            get { return s; }
            set { s = value; }
        }
        string s1;
        public string String1
        {
            get { return s1; }
            set { s1 = value; }
        }

        int broj;
        public int Broj
        {
            get { return broj; }
            set { broj = value; }
        }

        double brojD;
        public double BrojD
        {
            get { return brojD; }
            set { brojD = value; }
        }
        
    }
}
