using Deneme01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Deneme01.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();

        // GET: Admin
        public ActionResult UrunListele()
        {
            var urunler = context.Urun
                .Include(u => u.BankaX)
                .Include(u => u.AltKategoriX)
                .Include(u => u.AltKategoriX.UstKategoriX) //UstKategori sınıfı içersindeki verilere erişmek için kullanıyoruz.
                .OrderBy(u => u.UrunID)
                .ToList();

            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            if (ModelState.IsValid)
            {
                context.Urun.Add(urun);
                context.SaveChanges();

                return RedirectToAction("UrunListele"); //Eğer girilen veriler ekleme yapmak için uygunsa ekleme işlemi yapılır ve listeleme ekranına yönlendirilir.
            }
            return View(urun); // Eğer veriler ekleme için uygun değilse sayfanın son hali güncel kalacak şekilde yeniden göstertilir.
        }
        [HttpGet]
        public ActionResult UrunSil(int id)
        {
            var bul = context.Urun.Find(id);

            if (bul == null)
            {
                return RedirectToAction("UrunListele");
            }

            return View(bul);
        }
        [HttpPost]
        public ActionResult UrunSilOnay(int id)
        {
            var bul = context.Urun.Find(id);

            if (bul != null)
            {
                context.Urun.Remove(bul);
                context.SaveChanges();
            }

            return RedirectToAction("UrunListele");
        }
        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            var bul = context.Urun.Find(id);

            if(bul == null)
            {
                return RedirectToAction("UrunListele");
            }

            return View(bul); //Veriler girili olacak şekilde ekrana taşıyor.
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun urun)
        {
            if(ModelState.IsValid)
            {
                var mevcutUrun = context.Urun.Find(urun.UrunID);

                if(mevcutUrun != null)
                {
                    mevcutUrun.Urun_Adi = urun.Urun_Adi;
                    mevcutUrun.Urun_Renk_Bilgisi = urun.Urun_Renk_Bilgisi;
                    mevcutUrun.Stok_Bilgisi = urun.Stok_Bilgisi;
                    mevcutUrun.Garanti_Süresi_AY = urun.Garanti_Süresi_AY;
                    mevcutUrun.Max_Teslimat_Tarihi = urun.Max_Teslimat_Tarihi;
                    mevcutUrun.Fiyat_Bilgisi = urun.Fiyat_Bilgisi;
                    mevcutUrun.Yüzde_Cinsinden_Indirim_Miktari = urun.Yüzde_Cinsinden_Indirim_Miktari;
                    mevcutUrun.BankaID = urun.BankaID;
                    mevcutUrun.AltKategoriID = urun.AltKategoriID;

                    context.SaveChanges();

                    return RedirectToAction("UrunListele");
                }
                else
                {
                    return RedirectToAction("UrunListele");
                }
            }
            return View(urun); //Bir sıkıntı olsa dahi sayfanın en son hali ile bize yeniden gösterilmesini sağlayacak.
        }
    }
}