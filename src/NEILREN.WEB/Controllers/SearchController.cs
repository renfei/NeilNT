using NEILREN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEILREN.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index(string wd)
        {
            if (wd != null || wd != "")
            {
                ViewBag.Title = wd + " - 搜索结果";
                ViewBag.Search = wd;
                string PagNum = Request.QueryString["PageNum"] == null ? "1" : Request.QueryString["PageNum"].ToString();
                try
                {
                    ViewBag.PageNum = Int32.Parse(PagNum);
                    SearchModel Model = new SearchModel(wd, Int32.Parse(PagNum).ToString());
                    //if (Model.Meta[0].ID == null || Model.Meta[0].ID == "")
                    //    RedirectToAction("Error404", "Error", new { });
                    return View(Model);
                }
                catch (Exception)
                {
                    return RedirectToAction("Error404", "Error", new { });
                }
            }
            else
            {
                return View("SearchIndex");
            }
        }
	}
}