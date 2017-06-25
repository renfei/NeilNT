using NEILREN.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NEILREN.Models
{
    public class HomeModel
    {
        public Int32 Total { get; set; }
        public List<Metadata> Meta { get; set; }
        public List<FrieLink> FLink { get; set; }
        public List<ArticleModel> RecentArticle { get; set; }
        public class Metadata
        {
            public String TITLE { get; set; }
            public String ID { get; set; }
            public String TYPE { get; set; }
            public String IMAGE { get; set; }
            public String CONTENT { get; set; }
            public String DATE { get; set; }
        }
        public class FrieLink
        {
            public String LinkName { get; set; }
            public String Link { get; set; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="PageNum">第几页数</param>
        public HomeModel(string PageNum)
        {
            try
            {
                int PagNum = Int32.Parse(PageNum);
                PagNum = (PagNum - 1) * 10;
                HomeDAL DAL=new HomeDAL();
                DataSet ds = DAL.GetHome(PagNum.ToString(), "10");
                Total=0;
                //计算总行数
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Total += Int32.Parse(ds.Tables[0].Rows[i]["RowNum"].ToString());
                }
                int pag = Total / 10;
                if (Total % 10 > 0)
                    pag++;
                Total = pag;
                DataTable dt = ds.Tables[1];
                List<Metadata> ListObj = new List<Metadata>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Metadata obj = new Metadata();
                    obj.TITLE = dt.Rows[i]["TITLE"].ToString();
                    obj.ID = dt.Rows[i]["ID"].ToString();
                    obj.TYPE = dt.Rows[i]["TTYPE"].ToString();
                    obj.IMAGE = dt.Rows[i]["IMAGES"].ToString();
                    obj.CONTENT = dt.Rows[i]["CONTENT"].ToString();
                    obj.DATE = dt.Rows[i]["DATET"].ToString();
                    ListObj.Add(obj);
                }
                this.Meta = ListObj;
                DataTable dtFLink = ds.Tables[2];
                List<FrieLink> FLinkObj = new List<FrieLink>();
                for (int i = 0; i < dtFLink.Rows.Count; i++)
                {
                    FrieLink obj = new FrieLink();
                    obj.LinkName = dtFLink.Rows[i]["LinkName"].ToString();
                    obj.Link = dtFLink.Rows[i]["Link"].ToString();
                    FLinkObj.Add(obj);
                }
                this.FLink = FLinkObj;
                tArticleDAL ArticleDAL=new tArticleDAL();
                DataTable RecentDT = ArticleDAL.GetRecentAction();
                List<ArticleModel> ListArticle = new List<ArticleModel>();
                for (int i = 0; i < RecentDT.Rows.Count; i++)
                {
                    ArticleModel ArticleObj = new ArticleModel();
                    ArticleObj.ArticleID= RecentDT.Rows[i]["ArticleID"].ToString();
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
            catch (Exception ex)
            {
                //出错啦
            }
        }
    }
}