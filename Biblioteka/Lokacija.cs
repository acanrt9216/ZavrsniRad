using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Lokacija
    {
        public override string ToString()
        {
            return naziv;
        }

        int lokacijaID;
        string naziv;
        string opis;

        public int LokacijaID { get { return lokacijaID; } set { lokacijaID = value ; } }
        public string Naziv { get { return naziv; } set { naziv = value; } }
        public string Opis { get { return opis; } set { opis = value; } }
    }
}
