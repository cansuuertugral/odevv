using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi
{
    public class Ogrenci
    {
        public int OgrenciId { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(30)]
        [Required]
        public string Ad { get; set; } = string.Empty;

        public string Soyad { get; set; } = string.Empty;

        [Required]
        public string Numara { get; set; } = string.Empty;

        public int SinifId { get; set; } 
        public Sinif Sinif { get; set; } = new Sinif();

        public ICollection<OgrenciDers> OgrenciDers { get; set; } = new HashSet<OgrenciDers>();

        public override string ToString()
        {
            return $"OgrenciId:{this.OgrenciId}-Ad:{this.Ad}-Soyad:{this.Soyad}-Numara:{this.Numara}";
        }
    }
}
