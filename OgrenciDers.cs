using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi
{
    public class OgrenciDers
    {
        public int DersId { get; set; }
        public int OgrenciId { get; set;}

        public Ogrenci? Ogrenci { get; set; }

        public Dersler? Ders { get; set; }

    }
}
