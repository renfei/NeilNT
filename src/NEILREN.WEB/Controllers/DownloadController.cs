using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEILREN.Controllers
{
    public class DownloadController : Controller
    {
        // GET: Download
        public ActionResult Index()
        {
            return View();
        }

        // GET: Download
        public void Down(string ID)
        {
            if (HttpContext.Request.UrlReferrer != null && HttpContext.Request.UrlReferrer.Host.IndexOf("neilren.com") >= 0)
            {
                Response.ContentType = "application/x-zip-compressed";
                Response.AddHeader("Content-Disposition", "attachment;filename=z.zip");
                //string filename = "E:\\迅雷下载\\28a58fb6e5b270a2b36d00b2a34e4eeb.rar";
                string filename = "H:\\Video\\VID_20141019_150602.mp4";
                Response.TransmitFile(filename);
                Response.End();
            }
            else
            {
                Response.Write("不包含 neilren.com");
                Response.End();
            }
        }
    }
}