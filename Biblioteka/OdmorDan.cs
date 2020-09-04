using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class OdmorDan
    {
        Radnik radnik;
        DateTime datumOd;
        DateTime datumDo;

        public Radnik Radnik { get => radnik; set => radnik = value; }
        public DateTime DatumOd { get => datumOd; set => datumOd = value; }
        public DateTime DatumDo { get => datumDo; set => datumDo = value; }
    }
}
