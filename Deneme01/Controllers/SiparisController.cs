using Deneme01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Deneme01.Controllers
{
    public class SiparisController : Controller
    {
        Context context = new Context();

        // GET: Admin

        public ActionResult SiparisListele()
        {
            var siparisler = context.Siparis
                .Include(u => u.MusteriX) //Musteri sınıfı içersindeki verilere erişmek için kullanıyoruz.
                .Include(u => u.UrunX)
                .OrderBy(u => u.SiparisID)
                .ToList();

            return View(siparisler);
        }
        [HttpGet]
        public ActionResult SiparisEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SiparisEkle(Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                context.Siparis.Add(siparis);
                context.SaveChanges();

                return RedirectToAction("SiparisListele"); //Eğer girilen veriler ekleme yapmak için uygunsa eklme işlemi yapılır ve listeleme ekranına yönlendirilir.
            }
            return View(siparis); // Eğer veriler ekleme için uygun değilse sayfanın son hali güncel kalacak şekilde yeniden göstertilir.
        }
        [HttpGet]
        public ActionResult SiparisSil (int id)
        {
            var bul = context.Siparis.Find(id);

            if(bul == null)
            {
                return RedirectToAction ("SiparisListele"); //Eğer girilen siparis NULL ise SiparisListeleme ekranına dön. 
            }

            return View(bul);
        }
        [HttpPost]
        public ActionResult SiparisSilOnay (int id)
        {
            var bul = context.Siparis.Find(id); 

            if(bul != null)
            {
                context.Siparis.Remove(bul);
                context.SaveChanges();
            }

            return RedirectToAction ("SiparisListele");
        }
        [HttpGet]
        public ActionResult SiparisGuncelle(int id)
        {
           var bul = context.Siparis.Find(id);

            if(bul == null)
            {
                return RedirectToAction("SiparisListele");
            }

            return View(bul);
        }
        [HttpPost]
        public ActionResult SiparisGuncelle(Siparis siparis)
        {
            var mevcutSiparis = context.Siparis.Find(siparis.SiparisID);

            if (ModelState.IsValid)
            {
                if (mevcutSiparis != null)
                {
                    mevcutSiparis.MusteriID = siparis.MusteriID;
                    mevcutSiparis.UrunID = siparis.UrunID;
                    mevcutSiparis.Siparis_Edilen_Tarih = siparis.Siparis_Edilen_Tarih;
                    mevcutSiparis.Siparis_Edilen_Urun_Adet = siparis.Siparis_Edilen_Urun_Adet;

                    context.SaveChanges();

                    return RedirectToAction("SiparisListele");
                }
                else
                {
                    return RedirectToAction("SiparisListele");
                }
            }

            return View(siparis);
        }
    }
}