using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Praznik
    {
        public override string ToString()
        {
            return naziv;
        }

        int praznikID;
        string naziv;
        DateTime datumPraznika;

        public int PraznikID { get => praznikID; set => praznikID = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public DateTime DatumPraznika { get => datumPraznika; set => datumPraznika = value; }
    }
}
