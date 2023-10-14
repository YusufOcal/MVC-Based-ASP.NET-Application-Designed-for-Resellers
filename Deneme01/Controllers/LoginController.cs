using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Deneme01.Models;
using System.Web.UI.WebControls;

namespace Deneme01.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();

        // GET: Login
        [HttpGet]
        public ActionResult Giris()
        {
            if (Session["UserID"] != null) //Session kelimesi, web uygulamalarında kullanılan bir terimdir ve sunucu ile tarayıcı arasında bilgi saklamak için kullanılan bir mekanizmadır. 
            {
                return RedirectToAction("UrunListele", "Urun"); // Kullanıcı zaten giriş yapmışsa yönlendir
            }

            return View();
        }

        [HttpPost]
        public ActionResult Giris(Kullanici ks)
        {
            if (ModelState.IsValid)
            {
                var mevcutKullanici = context.Kullanici.Find(ks.UserID); //Database içerisinde verinin satırını bulacak. tut ile de o satırdaki verilere erişebileceğim.

                if ((ks.UserName == mevcutKullanici.UserName) && (ks.Password == mevcutKullanici.Password)) //'ks' ile de text içine girilen verilere erişmeye çalışıyoruz.
                {
                    // Kullanıcı girişi başarılı, oturumu başlat
                    Session["UserID"] = mevcutKullanici.UserID;
                    return RedirectToAction("UrunListele", "Urun");
                }
                else
                {
                    return RedirectToAction("Giris", "Login");
                }
            }

            return View(ks);
        }
    }
}