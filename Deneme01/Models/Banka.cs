using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Deneme01.Models
{
    public class Banka
    {
        [Key] public int BankaID { get; set; }
        public string Banka_Adi { get; set; }
        public short? Aylik_Taksit_Miktari { get; set; }

        public ICollection<Urun> UrunX { get; set; } //Bir banka birden fazla Urun için kullanılabiliyor.
    }
}