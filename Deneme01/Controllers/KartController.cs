using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deneme01.Models;

namespace Deneme01.Controllers
{
    public class KartController : Controller
    {
        // GET: Kart
        public ActionResult bankaView()
        {
            Context context = new Context();
            var bankalar = context.Banka.ToList();

            return View(bankalar);
        }
    }
}