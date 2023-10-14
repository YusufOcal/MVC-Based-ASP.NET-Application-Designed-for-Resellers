using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Deneme01.Models
{
    public class Urun
    {
        [Key] public int UrunID { get; set; }
        public string Urun_Adi { get; set; }
        public string Urun_Renk_Bilgisi { get; set; }
        public int? Stok_Bilgisi { get; set; }
        public short? Garanti_Süresi_AY { get; set; }
        public DateTime? Max_Teslimat_Tarihi { get; set; }
        public double? Fiyat_Bilgisi { get; set; }
        public double? Yüzde_Cinsinden_Indirim_Miktari { get; set; }
        public int? BankaID { get; set; }
        public int? AltKategoriID { get; set; }

        public AltKategori AltKategoriX { get; set; } //Bir Urun sadece bir AltKategoriye sahip olabilir.
        public Banka BankaX { get; set; } //Bir Urun sadece bir bankayı kullanabiliyor.
        public ICollection<Siparis> SiparisX { get; set; } //Bir Urunde birden fazla Siparis içinde kullanılabilir.
    }
}