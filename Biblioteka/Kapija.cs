using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Kapija
    {
        public override string ToString()
        {
                return naziv;
        }

        int kapijaID;
        string naziv;
        string opis;
        Lokacija lokacija;

        public int KapijaID { get {return kapijaID; } set { kapijaID = value ; } }
        public string Naziv { get { return naziv; } set { naziv = value; } }
        public string Opis { get { return opis; } set { opis = value; } }
        public Lokacija Lokacija { get { return lokacija; } set { lokacija = value; } }
    }
}
