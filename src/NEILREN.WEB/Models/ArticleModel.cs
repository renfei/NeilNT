using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NEILREN.DAL;
using System.Data;

namespace NEILREN.Models
{
    /// <summary>
    /// 文章类
    /// </summary>
    public class ArticleModel
    {
        #region 文章字段
        /// <summary>
        /// 文章编号
        /// </summary>
        public String ArticleID { get; set; }
        /// <summary>
        /// 表类别
        /// </summary>
        public String TableType { get; set; }
        /// <summary>
        /// 文章来源
        /// </summary>
        public String ArticleFrom { get; set; }
        /// <summary>
        /// 来源链接
        /// </summary>
        public String FromLink { get; set; }
        /// <summary>
        /// 文章作者
        /// </summary>
        public String ArticleAuthor { get; set; }
        /// <summary>
        /// 作者链接
        /// </summary>
        public String AuthorLink { get; set; }
        /// <summary>
        /// 文章发布时间
        /// </summary>
        public DateTime ArticleDate { get; set; }
        /// <summary>
        /// 特色图像
        /// </summary>
        public String ArticleImage { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public String ArticleTitle { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public String ArticleContent { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public String CatID { get; set; }
        /// <summary>
        /// 标签ID
        /// </summary>
        public String TagID { get; set; }
        /// <summary>
        /// 文章所属分类实例
        /// </summary>
        public CategoryModel Category { get; set; }
        /// <summary>
        /// 所有分类
        /// </summary>
        public List<CategoryModel> CategoryList { get; set; }
        public List<ArticleModel> RecentArticle { get; set; }
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ArticleModel() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ActionID"></param>
        public ArticleModel(string ActionID)
        {
            this.ArticleID = ActionID;
            tArticleDAL ArticleDAL = new tArticleDAL();
            DataTable dt = ArticleDAL.GetByActionID(this.ArticleID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ArticleID = dt.Rows[0]["ArticleID"].ToString();
                this.TableType = dt.Rows[0]["TableType"].ToString();
                this.ArticleFrom = dt.Rows[0]["ArticleFrom"].ToString();
                this.FromLink = dt.Rows[0]["FromLink"].ToString();
                this.ArticleAuthor = dt.Rows[0]["ArticleAuthor"].ToString();
                this.AuthorLink = dt.Rows[0]["AuthorLink"].ToString();
                this.ArticleDate = DateTime.Parse(dt.Rows[0]["ArticleDate"].ToString());
                this.ArticleImage = dt.Rows[0]["ArticleImage"].ToString();
                this.ArticleTitle = dt.Rows[0]["ArticleTitle"].ToString();
                this.ArticleContent = dt.Rows[0]["ArticleContent"].ToString();
                this.CatID = dt.Rows[0]["CatID"].ToString();
                this.TagID = dt.Rows[0]["TagID"].ToString();
                this.Category = new CategoryModel(this.CatID);
                
                List<CategoryModel> CatList = new List<CategoryModel>();
                tCategoryDAL CatDAL = new tCategoryDAL();
                DataTable dtCat = CatDAL.GetAllCategory();
                for (int i = 0; i < dtCat.Rows.Count; i++)
                {
                    CategoryModel Cat = new CategoryModel();
                    Cat.CatID = dtCat.Rows[i]["CatID"].ToString();
                    Cat.CatCnName = dtCat.Rows[i]["CatCnName"].ToString();
                    Cat.CatEnName = dtCat.Rows[i]["CatEnName"].ToString();
                    CatList.Add(Cat);
                }
                this.CategoryList = CatList;
                DataTable RecentDT = ArticleDAL.GetRecentAction();
                List<ArticleModel> ListArticle = new List<ArticleModel>();
                for (int i = 0; i < RecentDT.Rows.Count; i++)
                {
                    ArticleModel ArticleObj = new ArticleModel();
                    ArticleObj.ArticleID = RecentDT.Rows[i]["ArticleID"].ToString();
                    ArticleObj.TableType = RecentDT.Rows[i]["TableType"].ToString();
                    ArticleObj.ArticleFrom = RecentDT.Rows[i]["ArticleFrom"].ToString();
                    ArticleObj.FromLink = RecentDT.Rows[i]["FromLink"].ToString();
                    ArticleObj.ArticleAuthor = RecentDT.Rows[i]["ArticleAuthor"].ToString();
                    ArticleObj.AuthorLink = RecentDT.Rows[i]["AuthorLink"].ToString();
                    ArticleObj.ArticleDate = DateTime.Parse(RecentDT.Rows[i]["ArticleDate"].ToString());
                    ArticleObj.ArticleImage = RecentDT.Rows[i]["ArticleImage"].ToString();
                    ArticleObj.ArticleTitle = RecentDT.Rows[i]["ArticleTitle"].ToString();
                    ArticleObj.ArticleContent = RecentDT.Rows[i]["ArticleContent"].ToString();
                    ArticleObj.CatID = RecentDT.Rows[i]["CatID"].ToString();
                    ArticleObj.TagID = RecentDT.Rows[i]["TagID"].ToString();
                    ListArticle.Add(ArticleObj);
                }
                this.RecentArticle = ListArticle;
            }
            else
            {
                this.ArticleID = null;
            }
        }
    }
}