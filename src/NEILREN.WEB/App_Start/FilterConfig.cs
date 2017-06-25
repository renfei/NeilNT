using System;
using System.Web;
using System.Web.Mvc;
using NEILREN.DAL;

namespace NEILREN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AppHandleErrorAttribute());
        }
    }

    /// <summary>
    /// 错误日志（Controller发生异常时会执行这里）
    /// </summary>
    public class AppHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            //使用log4net或其他记录错误消息
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息
            string Url = HttpContext.Current.Request.RawUrl;//错误发生地址
            tLogDAL DAL = new tLogDAL();
            DAL.SetLog("500Error", "错误发生地址：" + Url + "; 错误信息：" + Message);
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/Error500/");//跳转至错误提示页面
        }
    }
}
