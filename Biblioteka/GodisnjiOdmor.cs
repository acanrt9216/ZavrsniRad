using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class GodisnjiOdmor
    {
        Radnik radnik;
        int godina;
        int odobrenBroj;
        int ukupnoZaKoriscenje;
        int iskorisceno;

        public Radnik Radnik { get => radnik; set => radnik = value; }
        public int Godina { get => godina; set => godina = value; }
        public int OdobrenBroj { get => odobrenBroj; set => odobrenBroj = value; }
        public int UkupnoZaKoriscenje { get => ukupnoZaKoriscenje; set => ukupnoZaKoriscenje = value; }
        public int Iskorisceno { get => iskorisceno; set => iskorisceno = value; }
    }
}
