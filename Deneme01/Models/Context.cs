using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Deneme01.Models
{
    public class Context : DbContext
    {
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<UstKategori> UstKategori { get; set; }
        public DbSet<AltKategori> AltKategori { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<Banka> Banka { get; set; }
    }
}