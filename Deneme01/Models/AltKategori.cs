using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Deneme01.Models
{
    public class AltKategori
    {
        [Key] public int AltKategoriID { get; set; }
        public string AltKategori_Adi { get; set; }
        public int? UstKategoriID { get; set; }

        public UstKategori UstKategoriX { get; set; } //Bir AltKategorinin ise sadece bir tane Kategori(üst) olabilir.
        public ICollection<Urun> UrunX { get; set; } //Bir AltKategori içerisinde birden fazla Urun bulunabilir.
    }
}