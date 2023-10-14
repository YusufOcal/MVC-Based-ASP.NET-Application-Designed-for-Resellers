using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Deneme01.Models
{
    public class Musteri
    {
        [Key] public int MusteriID { get; set; }
        public string Musteri_Adi { get; set; }
        public string Musteri_Soyadi { get;  set; }
        public string Musteri_Telefon_No { get; set; }
        public Boolean? Musteri_Cinsiyet { get; set; }
        public string Musteri_Sehir { get; set; }
        public string Musteri_E_Mail { get; set; }

        public ICollection<Siparis> SiparisX { get; set; } //Bir Musteri birden fazla Siparis verebilir.
    }
}