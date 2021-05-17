using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {

        // GET: Istatistik
        Context context = new Context();
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {

            // Toplam Kategori Sayısı
            var query1 = context.Categories.Count();
            ViewBag.q1 = query1;

            // Başlık tablosunda "yazılım" kategorisine ait başlık sayısı

            var query2 = context.Headings.Count(x => x.CategoryID == 8);
            ViewBag.q2 = query2;



            // Yazar adında 'a' harfi geçen yazar sayısı

            var query3 = context.Writers.Count(w => w.WriterName.Contains("a"));
            ViewBag.q3 = query3;



            // En fazla başlığa sahip kategori adı

            var query4 = context.Categories.Where(c => c.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.q4 = query4;



            // Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark

            var query5 = (context.Categories.Count(x => x.CategoryStatus == true)) - (context.Categories.Count(x => x.CategoryStatus == false));
            ViewBag.q5 = query5;

















            return View();
        }







    }
}