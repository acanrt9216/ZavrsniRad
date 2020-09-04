using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Prolasci
    {
        public override string ToString()
        {
            return radnik.Ime + " " + radnik.Prezime;
        }

        int prolazakID;
        Radnik radnik;
        string pravac;
        DateTime vremeProlaska;
        Kapija kapija;

        public int ProlazakID { get {return prolazakID; } set { prolazakID = value ; } }

        public Radnik Radnik { get { return radnik; } set { radnik = value; } }
        public string Pravac { get { return pravac; } set { pravac = value; } }
        public DateTime VremeProlaska { get { return vremeProlaska; } set { vremeProlaska = value; } }
        public Kapija Kapija { get { return kapija; } set { kapija = value; } }

    }
}
