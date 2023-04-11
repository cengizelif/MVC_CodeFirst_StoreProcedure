using MVC_CodeFirst_StoreProcedure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CodeFirst_StoreProcedure.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            db.Kitaplar.ToList();
            // db.Kitapekle();
            //List<TariheGoreKitaplarclass> model=db.TariheGoreKitaplar(2000, 2023);

            List<KitapBilgi> model = db.KitapBilgiGetir();

            //Kitap kitap= new Kitap();
            //kitap.Ad = "Varmısın";
            //kitap.Aciklama = "Açıklama1";
            //kitap.YayinTarihi = DateTime.Now;

            //db.Kitaplar.Add(kitap);
            //db.SaveChanges();


            return View(model);
        }
    }
}