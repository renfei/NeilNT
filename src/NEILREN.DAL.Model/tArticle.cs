using System;

namespace NEILREN
{
    /// <summary>
    /// 数据库文章表
    /// </summary>
    public class tArticle
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int ArticleID { get; set; }
        /// <summary>
        /// 表类别
        /// </summary>
        public string TableType { get; set; }
        /// <summary>
        /// 文章来源
        /// </summary>
        public string ArticleFrom { get; set; }
        /// <summary>
        /// 文章来源链接
        /// </summary>
        public string FromLink { get; set; }
        /// <summary>
        /// 文章作者
        /// </summary>
        public string ArticleAuthor { get; set; }
        /// <summary>
        /// 作者链接
        /// </summary>
        public string AuthorLink { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ArticleDate { get; set; }
        /// <summary>
        /// 特色图像
        /// </summary>
        public string ArticleImage { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ArticleTitle { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string ArticleContent { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CatID { get; set; }
        /// <summary>
        /// 标签ID
        /// </summary>
        public int TagID { get; set; }
    }
}
