using Deneme01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Deneme01.Controllers
{
    public class MusteriController : Controller
    {
        Context context = new Context();

        // GET: Admin

        public ActionResult MusteriListele()
        {
            var musteriler = context.Musteri
                .OrderBy(u => u.MusteriID)
                .ToList();

            return View(musteriler);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                if (musteri.Musteri_E_Mail.EndsWith("@gmail.com"))//Eger E-Mail alanına girilen veri @gmail.com ile bitiyorsa yapılaması istenenler:
                {
                    context.Musteri.Add(musteri);
                    context.SaveChanges();

                    return RedirectToAction("MusteriListele"); //Eğer girilen veriler ekleme yapmak için uygunsa eklme işlemi yapılır ve listeleme ekranına yönlendirilir.
                }
                else//Eger E-Mail alanına girilen veri @gmail.com ile bitmiyorsa hatalı verilerin girilmeyi çalışıldığı ekran döner.
                {
                    return View(musteri);
                }
            }
            return View(musteri); // Eğer veriler ekleme için uygun değilse sayfanın son hali güncel kalacak şekilde yeniden göstertilir.
        }
        [HttpGet]
        public ActionResult MusteriSil(int id)
        {
            var bul = context.Musteri.Find(id);

            if (bul == null)
            {
                return RedirectToAction("MusteriListele"); //Eğer girilen siparis NULL ise SiparisListeleme ekranına dön. 
            }

            return View(bul);
        }
        [HttpPost]
        public ActionResult MusteriSilOnay(int id)
        {
            var bul = context.Musteri.Find(id);

            if (bul != null)
            {
                context.Musteri.Remove(bul);
                context.SaveChanges();
            }

            return RedirectToAction("MusteriListele");
        }
        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var bul = context.Musteri.Find(id);

            if (bul == null)
            {
                return RedirectToAction("MusteriListele");
            }

            return View(bul);
        }
        [HttpPost]
        public ActionResult MusteriGuncelle(Musteri musteri)
        {
            var mevcutMusteri = context.Musteri.Find(musteri.MusteriID);

           if (ModelState.IsValid)
            {
                if (mevcutMusteri != null)
                {
                    mevcutMusteri.Musteri_Adi = musteri.Musteri_Adi;
                    mevcutMusteri.Musteri_Soyadi = musteri.Musteri_Soyadi;
                    mevcutMusteri.Musteri_Telefon_No = musteri.Musteri_Telefon_No;
                    mevcutMusteri.Musteri_Cinsiyet = musteri.Musteri_Cinsiyet;
                    mevcutMusteri.Musteri_Sehir = musteri.Musteri_Sehir;
                    mevcutMusteri.Musteri_E_Mail = musteri.Musteri_E_Mail;

                    context.SaveChanges();

                    return RedirectToAction("MusteriListele");
                }
                else
                {
                    return RedirectToAction("MusteriListele");
                }
            }

            return View(musteri);
        }
    }
}
