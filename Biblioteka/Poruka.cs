using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Poruka
    {
        public override string ToString()
        {
            return posaljilac.Ime + " " + posaljilac.Prezime;
        }

        int porukaID;
        Radnik posaljilac;
        Radnik primalac;
        string tekst;

        public int PorukaID { get => porukaID; set => porukaID = value; }
        
        
        public Radnik Posaljilac { get => posaljilac; set => posaljilac = value; }
        //public Radnik radnik { get => posaljilac.Ime +posaljilac.Prezime; set => posaljilac = value; }
        public Radnik Primalac { get => primalac; set => primalac = value; }
        public string Tekst { get => tekst; set => tekst = value; }
    }

}
