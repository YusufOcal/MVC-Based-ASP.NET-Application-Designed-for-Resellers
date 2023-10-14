using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Deneme01.Models
{
    public class UstKategori
    {
        [Key] public int UstKategoriID { get; set; }
        public string UstKategori_Adi { get; set; }

        public ICollection<AltKategori> AltKategoriX { get; set; } //Bir Kategori(üst) birden fazla AltKategori içerebilir.
    }
}