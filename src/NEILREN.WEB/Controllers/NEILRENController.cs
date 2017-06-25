using NEILREN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEILREN.Controllers
{
    public class NEILRENController : Controller
    {
        //
        // GET: /NEILREN/
        public ActionResult Index(string id)
        {
            string PagNum = id == null ? "1" : id;
            try
            {
                ViewBag.PageNum = Int32.Parse(PagNum);
                HomeModel Model = new HomeModel(Int32.Parse(PagNum).ToString());
                return View(Model);
            }
            catch (Exception)
            {
                return Redirect("http://www.neilren.com/");
            }
        }

        public ActionResult ViewPage1()
        {
            return View();
        }
    }
}