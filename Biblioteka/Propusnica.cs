using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Propusnica
    {
        

        int propusnicaID;
        string ime;
        string prezime;

        string razlog;
        DateTime datum;

        public int PropusnicaID { get => propusnicaID; set => propusnicaID = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Razlog { get => razlog; set => razlog = value; }
        public DateTime Datum { get => datum; set => datum = value; }
    }
}
