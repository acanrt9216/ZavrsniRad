using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Odeljenje
    {
        public override string ToString()
        {
            return naziv;
        }

        int odeljenjeID;
        string naziv;
        Radnik sefOdeljenja;
        int brojZaposlenih;
        public int OdeljenjeID { get { return odeljenjeID; } set { odeljenjeID = value; } }
        public string Naziv { get { return naziv; } set { naziv = value; } }
        public Radnik SefOdeljenja { get { return sefOdeljenja; } set { sefOdeljenja = value; } }
        public int BrojZaposlenih { get { return brojZaposlenih; } set { brojZaposlenih = value; } }

    }
}
