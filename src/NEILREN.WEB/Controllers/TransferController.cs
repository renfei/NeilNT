using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEILREN.Models;

namespace NEILREN.Controllers
{
    public class TransferController : Controller
    {
        //
        // GET: /Transfer/
        public ActionResult Index(string id)
        {
            return View();
        }

        //
        // GET: /Transfer/Blog/
        public ActionResult Blog(string id)
        {
            if (id != null)
            {
                BlogTransfer BT=new BlogTransfer(id);
                BT.GetNewID();
                if (BT.Finish)
                {
                    Response.Status = "301 Moved Permanently";
                    Response.AddHeader("Location", "http://www.neilren.com/Article/"+BT.NewID);
                    return View();
                }
                else
                    return Redirect("/");
            }
            else
                return Redirect("/");
        }
    }
}