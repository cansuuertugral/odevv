using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi
{
    public class Sinif
    {
        public int SinifId { get; set; }
        public string SinifAd { get; set; } = string.Empty;
        public int Kontenjan { get; set; }
        public ICollection<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();

        public override string ToString()
        {
            return $"SinifId:{this.SinifId}-SinifAd:{this.SinifAd}-Kontenjan:{this.Kontenjan}";
        }
    }
}
