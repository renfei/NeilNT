using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEILREN.Models;

namespace NEILREN.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        public ActionResult Index(string id)
        {
            Response.Write(id);
            Response.End();
            return View();
        }

        //文章分类
        //GET: /Article/Category/id
        public ActionResult Category(string id)
        {
            if (id != null)
            {
                string PagNum = Request.QueryString["PageNum"] == null ? "1" : Request.QueryString["PageNum"].ToString();
                try
                {
                    ViewBag.PageNum = Int32.Parse(PagNum);
                    ArticleListModel Model = new ArticleListModel(id, Int32.Parse(PagNum).ToString());
                    if (Model.ArticleList[0].CatID == null || Model.ArticleList[0].CatID == "")
                        RedirectToAction("Error404", "Error", new { });
                    return View("Category", Model);
                }
                catch (Exception)
                {
                    return RedirectToAction("Error404", "Error", new { });
                }
            }
            else
            {
                //没有分类ID，跳转
                return RedirectToAction("Error404", "Error", new { });
            }
        }

        //阅读文章
        //GET: /Article/Read/id
        public ActionResult Read(string id)
        {
            if (id==null)
            {
                //ID不存在，显示所有博客文章的列表
                string PagNum = Request.QueryString["PageNum"] == null ? "1" : Request.QueryString["PageNum"].ToString();
                try
                {
                    ViewBag.PageNum = Int32.Parse(PagNum);
                    ArticleListModel Model = new ArticleListModel(Int32.Parse(PagNum).ToString());
                    return View("Article", Model);
                }
                catch (Exception)
                {
                    return Redirect("http://www.neilren.com/Error/Error404");
                }
                return View();
            }
            else
            {
                ArticleModel Article = new ArticleModel(id);
                if (Article.ArticleID != null)
                    return View(Article);
                else Response.Status = "404 NOT FOUND";
                return RedirectToAction("Error404", "Error", new { });
            }
        }
	}
}