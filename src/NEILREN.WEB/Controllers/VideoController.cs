﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEILREN.Models;

namespace NEILREN.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }

        // GET: Video/Show
        public ActionResult Show(string ID)
        {
            return View();
        }
    }
}