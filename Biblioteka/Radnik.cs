using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Radnik
    {
        public override string ToString()
        {
            return ime + " " + prezime;
        }

        int radnikID;
        string ime;
        string prezime;
        DateTime datumRodjenja;
        string posao;
        int plata;
        string username;
        string password;

        Odeljenje odeljenjeID;
        int privilegija;
        Satnica satnicaID;
        

        public int RadnikID { get {return radnikID; } set { radnikID = value; } }
        public string Ime { get { return ime; } set { ime = value; } }
        public string Prezime { get { return prezime; } set { prezime = value; } }
        public DateTime DatumRodjenja { get { return datumRodjenja; } set { datumRodjenja = value; } }
        public string Posao { get { return posao; } set { posao = value; } }
        public int Plata { get { return plata; } set { plata = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
 
        public Odeljenje Odeljenje { get { return odeljenjeID; } set { odeljenjeID = value; } }
        public int Privilegija { get => privilegija; set => privilegija = value; }
        public Satnica Satnica { get => satnicaID; set => satnicaID = value; }
    }
}
