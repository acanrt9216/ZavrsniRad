using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Dnevnik
    {
        Radnik radnik;
        string ponedeljak;
        string utorak;
        string sreda;
        string cetvrtak;
        string petak;

        public Radnik Radnik { get => radnik; set => radnik = value; }
        public string Ponedeljak { get => ponedeljak; set => ponedeljak = value; }
        public string Utorak { get => utorak; set => utorak = value; }
        public string Sreda { get => sreda; set => sreda = value; }
        public string Cetvrtak { get => cetvrtak; set => cetvrtak = value; }
        public string Petak { get => petak; set => petak = value; }
    }
}
