using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEILREN.Models;
using System.Threading;

namespace NEILREN.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            SendMail sendmail = new SendMail();
            sendmail.email = "504359836@qq.com";
            sendmail.subject = "测试主题";
            sendmail.content = "测试内容";
            Thread t = new Thread(new ThreadStart(sendmail.SendEmail));
            t.Start();
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }
    }
}