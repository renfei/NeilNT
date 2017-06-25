using NEILREN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEILREN.Controllers
{
    public class AlbumController : Controller
    {
        //
        // GET: /Album/
        public ActionResult Index(string id)
        {
            try
            {
                string PagNum = Request.QueryString["PageNum"] == null ? "1" : Request.QueryString["PageNum"].ToString();
                if (id == null)
                {
                    Int32.Parse(PagNum);
                    ViewBag.PageNum = Int32.Parse(PagNum);
                    //显示相册列表
                    AlbumModel Album = new AlbumModel(PagNum);
                    if (Album.AlbumList[0].AlbumID == null)
                        RedirectToAction("Error404", "Error", new { });
                    return View("AlbumList", Album);
                }
                else
                {
                    Int32.Parse(PagNum);
                    ViewBag.PageNum = Int32.Parse(PagNum);
                    //显示具体相册内容
                    AlbumModel Album = new AlbumModel(id,PagNum);
                    if (Album.Album.AlbumID == null)
                        RedirectToAction("Error404", "Error", new { });
                    return View(Album);
                }
            }
            catch (Exception)
            {
                
            }
            return View();
        }
	}
}