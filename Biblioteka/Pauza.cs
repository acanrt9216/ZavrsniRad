
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Pauza
    {
        public override string ToString()
        {
            return naziv;
        }

        int pauzaID;
        string naziv;
        int duzinaPauze;

        public int PauzaID { get => pauzaID; set => pauzaID = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public int DuzinaPauze { get => duzinaPauze; set => duzinaPauze = value; }
    }
}
