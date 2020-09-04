using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Satnica
    {
        public override string ToString()
        {
            return naziv;
        }
        int satnicaID;
        string naziv;
        string opis;
        int brojSati;

        public int SatnicaID { get => satnicaID; set => satnicaID = value; }

        public string Naziv { get => naziv; set => naziv = value; }

        public string Opis { get => opis; set => opis = value; }
        public int BrojSati { get => brojSati; set => brojSati = value; }
    }
}
