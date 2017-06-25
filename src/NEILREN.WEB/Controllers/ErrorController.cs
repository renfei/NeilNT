using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NEILREN.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/Error404/
        public ActionResult Error404()
        {
            Response.Status = "404 NOT FOUND";
            return View();
        }

        //
        // GET: /Error/Error500/
        public ActionResult Error500()
        {
            Response.Status = "500 INTERNAL SERVER ERROR";
            return View();
        }
	}
}