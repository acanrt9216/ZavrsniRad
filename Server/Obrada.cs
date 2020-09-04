using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Biblioteka;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows;
using Sesija;

namespace Server
{
    class Obrada
    {
        private NetworkStream tok;
        BinaryFormatter formater;
        private ServerKlasa formServer;
        public Obrada(NetworkStream tok, ServerKlasa formServer)
        {
            this.tok = tok;
            this.formServer = formServer;
            formater = new BinaryFormatter();

            ThreadStart ts = obradaKlijenta;
            Thread nit = new Thread(ts);
            nit.Start();
        }

        void obradaKlijenta()
        {
            int operacija = 0;

            while (operacija != (int)Operacije.Kraj)
            {
                TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                switch (transfer.Operacija)
                {
                    case Operacije.prolazak:
                        formServer.Dispatcher.Invoke(new Action(() =>
                        {
                            formServer.ListaProlazaka.Add(transfer.TransferObjekat as Prolasci);
                        }));
                        break;
                    case Operacije.prijava:
                        transfer.TransferObjekat = Broker.dajSesiju().prijava(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.radnik:
                        formServer.Dispatcher.Invoke(new Action(() =>
                        {
                            formServer.ListaUlogovanihRadnika.Add(transfer.TransferObjekat as Radnik);
                            foreach (Radnik rad in formServer.ListaUlogovanihRadnika)
                            {
                                Radnik r = transfer.TransferObjekat as Radnik;
                                if (rad.RadnikID == r.RadnikID)
                                {
                                    transfer.DaLiJe = true;
                                    formater.Serialize(tok, transfer);
                                }
                            }
                        }));
                        break;
                    
                    case Operacije.daLiJePrijavljen:
                        BindingList<Radnik> lista = formServer.ListaUlogovanihRadnika;
                        if (lista.Count == 0)
                        {
                            transfer.DaLiJe = false;
                            formater.Serialize(tok, transfer);
                        }
                        else
                        {
                            foreach (Radnik rad in lista)
                            {
                                Radnik radn = transfer.TransferObjekat as Radnik;
                                if (rad.Ime == radn.Ime && rad.Prezime==radn.Prezime)
                                {
                                    transfer.DaLiJe = true;
                                    formater.Serialize(tok, transfer);
                                }
                                else
                                {
                                    transfer.DaLiJe = false;
                                    formater.Serialize(tok, transfer);
                                }
                            }
                        }
                        break;
                    
                    case Operacije.izlazak:
                        Prolasci pr = transfer.TransferObjekat as Prolasci;
                        formServer.Dispatcher.Invoke(new Action(() =>
                        {
                            formServer.ListaProlazaka.Add(pr);
                        }));
                        break;
                    case Operacije.odjaviRadnika:
                        Radnik ra = transfer.TransferObjekat as Radnik;

                        formServer.Dispatcher.Invoke(new Action(() =>
                        {
                            for (int i = 0; i < formServer.ListaUlogovanihRadnika.Count; i++)
                            {
                                if (formServer.ListaUlogovanihRadnika[i].RadnikID == ra.RadnikID)
                                {
                                    formServer.ListaUlogovanihRadnika.RemoveAt(i);
                                }
                            }
                        }));
                        break;



                        //

                        // Vracanje

                        //


                    case Operacije.vratiKapije:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiKapije();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiLokacije:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiLokacije();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiOdeljenja:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiOdeljenja();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiRadnike:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiRadnike();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiProlaske:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiProlaske();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiGodisnjeOdmore:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiGodisnjeOdmore();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiPropusnice:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiPropusnice();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiPraznike:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiPraznike();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiSatnice:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiSatnice();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiPauze:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiPauze();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiRadnikaZaComboBox:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiRadnikaZaComboBox(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiRadnikaZaOdeljenje:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiRadnikaZaOdeljenje(transfer.TransferObjekat as Odeljenje);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiListuRadnikaZaCalendarINOUT:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiListuRadnikaZaCalendarINOUT(transfer.TransferObjekat as List<Prolasci>,transfer.Datum);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiRadnikaZaGodisnjiOdmor:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiRadnikaZaGodisnjiOdmor(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiOdmorZaRadnika:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiOdmorZaRadnika(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiGodisnjiOdmorZaRadnika:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiGodisnjiOdmorZaRadnika(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiPorukeZaRadnika:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiPorukuZaRadnika(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiBrojSatiZaRadnika:
                        transfer.Broj = Broker.dajSesiju().vratiBrojSatiZaRadnika(transfer.TransferObjekat as Satnica);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiSlobodneDane:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiSlobodneDane();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiZaboravljenuLozinku:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiZaboravljenuLozinku(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiBrojZaposlenihZaIzmenuRadnika:
                        transfer.Broj = Broker.dajSesiju().vratiBrojZaposlenihZaIzmenuRadnika(transfer.TransferObjekat as Odeljenje);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiBrojZaposlenihZaOdeljenje:
                        transfer.Broj = Broker.dajSesiju().vratiBrojZaposlenihZaOdeljenje(transfer.String);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiDatumeZaCalendar:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiDatumeZaCalendar();
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiDnevnikeZaSefa:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiDnevnikeZaSefa(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiGodisnjiOdmorPretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiGodisnjiOdmorPretraga(transfer.Broj,(int)transfer.Rezultat);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiPropusnicePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiPropusnicuPretraga(transfer.String,transfer.String1,transfer.TransferObjekat as string,transfer.Datum);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiPraznikePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiPraznikPretraga(transfer.String, transfer.Datum);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiKapijePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiKapijePretraga(transfer.String, transfer.TransferObjekat as string,transfer.Rezultat as string);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiOdeljenjePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiOdeljenjePretraga(transfer.String, transfer.TransferObjekat as string, transfer.Rezultat as string,transfer.Broj);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiLokacijePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiLokacijuPretraga(transfer.String, transfer.String1);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiProlaskePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiProlaskePretraga(transfer.String, transfer.TransferObjekat as string, transfer.Rezultat as string, transfer.String1);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiRadnikePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiRadnikePretraga(transfer.String, transfer.TransferObjekat as string,transfer.Datum, transfer.Rezultat as string, transfer.String1);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiDuzinuPauze:
                        transfer.Broj = Broker.dajSesiju().vratiBrojMinutaPauze(transfer.String);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiPauzePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiPauzuPretraga(transfer.String, transfer.Broj);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.vratiSatnicePretraga:
                        transfer.TransferObjekat = Broker.dajSesiju().vratiSatnicuPretraga(transfer.String,transfer.String1, transfer.Broj);
                        formater.Serialize(tok, transfer);
                        break;


                        //

                        // DaLiJe

                        //

                    case Operacije.daLiJeRadnikNaOdmoru:
                        transfer.DaLiJe = Broker.dajSesiju().daLiJeNaOdmoruRadnik(transfer.TransferObjekat as OdmorDan,transfer.Datum);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.daLiJeRadnikNaPoslu:
                        transfer.DaLiJe = Broker.dajSesiju().daLiJeNaPosluRadnik(transfer.TransferObjekat as Prolasci, transfer.Datum,transfer.String);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.daLiJeDnevnikRadaUnesen:
                        transfer.DaLiJe = Broker.dajSesiju().daLiJeUnesenDnevnikRada(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.daLiJeDanasPraznik:
                        transfer.DaLiJe = Broker.dajSesiju().daLiJeDanasPraznik(transfer.TransferObjekat as Praznik,transfer.Datum);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.daLiJeRadnikSefOdeljenja:
                        transfer.DaLiJe = Broker.dajSesiju().daLiJeRadnikSefOdeljenja(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;

                        //

                        // Sacuvaj

                        //

                    case Operacije.sacuvajRadnika:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajRadnika(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajOdeljenje:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajOdeljenje(transfer.TransferObjekat as Odeljenje);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajKapiju:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajKapiju(transfer.TransferObjekat as Kapija);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajLokaciju:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajLokaciju(transfer.TransferObjekat as Lokacija);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajDnevnikRada:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajDnevnik(transfer.TransferObjekat as Dnevnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajPropusnicu:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajPropusnicu(transfer.TransferObjekat as Propusnica);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajPauzu:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajPauzu(transfer.TransferObjekat as Pauza);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajPraznik:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajPraznik(transfer.TransferObjekat as Praznik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajSatnicu:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajSatnicu(transfer.TransferObjekat as Satnica);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajProlazak:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajProlazak(transfer.TransferObjekat as Prolasci);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajPoruku:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajPoruku(transfer.TransferObjekat as Poruka);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajPoruke:
                        transfer.Rezultat = Broker.dajSesiju().sacuvajPoruke(transfer.TransferObjekat as Poruka,transfer.Rezultat as List<Radnik>);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajGodisnjiOdmor:
                        Broker.dajSesiju().sacuvajGodisnjiOdmor(transfer.TransferObjekat as GodisnjiOdmor);
                        break;
                    case Operacije.sacuvajProlaske:
                        transfer.TransferObjekat = Broker.dajSesiju().sacuvajProlaske(transfer.TransferObjekat as BindingList<Prolasci>);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.sacuvajOdmor:
                        transfer.TransferObjekat = Broker.dajSesiju().sacuvajOdmor(transfer.TransferObjekat as OdmorDan);
                        formater.Serialize(tok,transfer);
                        break;

                        //

                        // Brisanje

                        //

                    case Operacije.obrisiRadnika:
                        transfer.Broj = Broker.dajSesiju().obrisiRadnika(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiSatnicu:
                        transfer.Broj = Broker.dajSesiju().obrisiSatnicu(transfer.TransferObjekat as Satnica);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiDnevnik:
                        transfer.Broj = Broker.dajSesiju().obrisiDnevnik(transfer.TransferObjekat as Dnevnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiGodisnjiOdmor:
                        transfer.Broj = Broker.dajSesiju().obrisiGodisnjiOdmor(transfer.TransferObjekat as GodisnjiOdmor);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiKapiju:
                        transfer.Broj = Broker.dajSesiju().obrisiKapiju(transfer.TransferObjekat as Kapija);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiLokaciju:
                        transfer.Broj = Broker.dajSesiju().obrisiLokaciju(transfer.TransferObjekat as Lokacija);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiOdeljenje:
                        transfer.Broj = Broker.dajSesiju().obrisiOdeljenje(transfer.TransferObjekat as Odeljenje);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiPauzu:
                        transfer.Broj = Broker.dajSesiju().obrisiPauzu(transfer.TransferObjekat as Pauza);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiPraznik:
                        transfer.Broj = Broker.dajSesiju().obrisiPraznik(transfer.TransferObjekat as Praznik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiProlazak:
                        transfer.Broj = Broker.dajSesiju().obrisiProlazak(transfer.TransferObjekat as Prolasci);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiPorukuZaRadnika:
                        transfer.Rezultat = Broker.dajSesiju().obrisiPorukeZaRadnika(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiPropusnicu:
                        transfer.Broj = Broker.dajSesiju().obrisiPropusnicu(transfer.TransferObjekat as Propusnica);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.obrisiOdmor:
                        Broker.dajSesiju().obrisiSlobodneDane(transfer.TransferObjekat as Radnik);
                        break;

                    //

                    //Izmena

                    //

                    case Operacije.izmeniRadnika:
                        transfer.Rezultat = Broker.dajSesiju().izmeniRadnika(transfer.TransferObjekat as Radnik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniOdeljenje:
                        transfer.Rezultat = Broker.dajSesiju().izmeniOdeljenje(transfer.TransferObjekat as Odeljenje);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniKapiju:
                        transfer.Rezultat = Broker.dajSesiju().izmeniKapiju(transfer.TransferObjekat as Kapija);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniLokaciju:
                        transfer.Rezultat = Broker.dajSesiju().izmeniLokaciju(transfer.TransferObjekat as Lokacija);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniPraznik:
                        transfer.Rezultat = Broker.dajSesiju().izmeniPraznik(transfer.TransferObjekat as Praznik);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniPauzu:
                        transfer.Rezultat = Broker.dajSesiju().izmeniPauzu(transfer.TransferObjekat as Pauza);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniPropusnicu:
                        transfer.Rezultat = Broker.dajSesiju().izmeniPropusnice(transfer.TransferObjekat as Propusnica);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniSatnicu:
                        transfer.Rezultat = Broker.dajSesiju().izmeniSatnicu(transfer.TransferObjekat as Satnica);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniGodisnjiOdmor:
                        transfer.Rezultat = Broker.dajSesiju().izmeniGodisnjiOdmor(transfer.TransferObjekat as GodisnjiOdmor);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniProlazak:
                        transfer.Rezultat = Broker.dajSesiju().izmeniProlazak(transfer.TransferObjekat as Prolasci);
                        formater.Serialize(tok, transfer);
                        break;
                    case Operacije.izmeniBrojZaposlenihUOdeljenju:
                        Broker.dajSesiju().izmeniBrojZaposlenihUOdeljenju(transfer.TransferObjekat as Odeljenje, transfer.Broj);
                        break;
                    case Operacije.izmeniOdeljenjeRadnika:
                        Broker.dajSesiju().izmeniOdeljenjeRadnika(transfer.TransferObjekat as Radnik, transfer.Rezultat as Odeljenje);
                        break;
                    case Operacije.izmeniSlobodneDane:
                        transfer.Broj=Broker.dajSesiju().izmeniSlobodneDane(transfer.TransferObjekat as GodisnjiOdmor, transfer.BrojD);
                        formater.Serialize(tok, transfer);
                        break;
                    
                    case Operacije.Kraj:
                        operacija = 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
