using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Deneme01.Models
{
    public class Siparis
    {
        [Key] public int SiparisID { get; set; }
        public int? MusteriID { get; set; }
        public int? UrunID { get; set; }
        public DateTime? Siparis_Edilen_Tarih { get; set; }
        public short? Siparis_Edilen_Urun_Adet { get; set; }

        public Musteri MusteriX { get; set; } //Bir Siparis sadece bir tane Musteriye ait olabilir.
        public Urun UrunX { get; set; } //Bir Sipariste sadece bir Urun bulunabilir.
    }
}