using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi
{
    public class Dersler
    {
        public int DersId { get; set; }
        public string DersKod { get; set;}
        public string DersAd {  get; set; }
        public ICollection<OgrenciDers> OgrenciDersler { get; set; } = new List<OgrenciDers>();

        public override string ToString()
        {
            return $"DersId:{this.DersId}-DersAd:{this.DersAd}-DersKod:{this.DersKod}";
        }
    }
}

