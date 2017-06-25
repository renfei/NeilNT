using System;

namespace NEILREN
{
    /// <summary>
    /// 数据库页面表
    /// </summary>
    public class tPage
    {
        /// <summary>
        /// 页面ID
        /// </summary>
        public int PageID { get; set; }
        /// <summary>
        /// 表类别
        /// </summary>
        public string TableType { get; set; }
        /// <summary>
        /// 特色图像
        /// </summary>
        public string PageImage { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PageDate { get; set; }
        /// <summary>
        /// 页面标题
        /// </summary>
        public string PageTitle { get; set; }
        /// <summary>
        /// 页面内容
        /// </summary>
        public string PageContent { get; set; }
    }
}
