using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NEILREN.DAL;
using System.Data;

namespace NEILREN.Models
{
    public class ArticleListModel
    {
        public Int32 Total { get; set; }
        public List<ArticleModel> ArticleList { get; set; }
        /// <summary>
        /// 构造函数，获取所有博客文章
        /// </summary>
        public ArticleListModel(string PageNum)
        {
            try
            {
                int PagNum = Int32.Parse(PageNum);
                PagNum = (PagNum - 1) * 10;
                tArticleDAL ArticleDAL = new tArticleDAL();
                DataSet ds = ArticleDAL.GetAllAction(PagNum.ToString(),"10");
                Total = Int32.Parse(ds.Tables[0].Rows[0]["RowNum"].ToString());;
                //计算总页数
                int pag = Total / 10;
                if (Total % 10 > 0)
                    pag++;
                Total = pag;
                DataTable dt = ds.Tables[1];
                List<ArticleModel> ListObj = new List<ArticleModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArticleModel obj = new ArticleModel();
                    obj.ArticleID = dt.Rows[i]["ArticleID"].ToString();
                    obj.TableType = dt.Rows[i]["TableType"].ToString();
                    obj.ArticleFrom = dt.Rows[i]["ArticleFrom"].ToString();
                    obj.FromLink = dt.Rows[i]["FromLink"].ToString();
                    obj.ArticleAuthor = dt.Rows[i]["ArticleAuthor"].ToString();
                    obj.AuthorLink = dt.Rows[i]["AuthorLink"].ToString();
                    obj.ArticleDate = DateTime.Parse(dt.Rows[i]["ArticleDate"].ToString());
                    obj.ArticleImage = dt.Rows[i]["ArticleImage"].ToString();
                    obj.ArticleTitle = dt.Rows[i]["ArticleTitle"].ToString();
                    obj.ArticleContent = dt.Rows[i]["ArticleContent"].ToString();
                    obj.CatID = dt.Rows[i]["CatID"].ToString();
                    obj.TagID = dt.Rows[i]["TagID"].ToString();
                    obj.Category = new CategoryModel(obj.CatID);
                    List<CategoryModel> CatList = new List<CategoryModel>();
                    tCategoryDAL CatDAL = new tCategoryDAL();
                    DataTable dtCat = CatDAL.GetAllCategory();
                    for (int j = 0; j < dtCat.Rows.Count; j++)
                    {
                        CategoryModel Cat = new CategoryModel();
                        Cat.CatID = dtCat.Rows[j]["CatID"].ToString();
                        Cat.CatCnName = dtCat.Rows[j]["CatCnName"].ToString();
                        Cat.CatEnName = dtCat.Rows[j]["CatEnName"].ToString();
                        CatList.Add(Cat);
                    }
                    obj.CategoryList = CatList;
                    DataTable RecentDT = ArticleDAL.GetRecentAction();
                    List<ArticleModel> ListArticle = new List<ArticleModel>();
                    for (int q = 0; q < RecentDT.Rows.Count; q++)
                    {
                        ArticleModel ArticleObj = new ArticleModel();
                        ArticleObj.ArticleID = RecentDT.Rows[q]["ArticleID"].ToString();
                        ArticleObj.TableType = RecentDT.Rows[q]["TableType"].ToString();
                        ArticleObj.ArticleFrom = RecentDT.Rows[q]["ArticleFrom"].ToString();
                        ArticleObj.FromLink = RecentDT.Rows[q]["FromLink"].ToString();
                        ArticleObj.ArticleAuthor = RecentDT.Rows[q]["ArticleAuthor"].ToString();
                        ArticleObj.AuthorLink = RecentDT.Rows[q]["AuthorLink"].ToString();
                        ArticleObj.ArticleDate = DateTime.Parse(RecentDT.Rows[q]["ArticleDate"].ToString());
                        ArticleObj.ArticleImage = RecentDT.Rows[q]["ArticleImage"].ToString();
                        ArticleObj.ArticleTitle = RecentDT.Rows[q]["ArticleTitle"].ToString();
                        ArticleObj.ArticleContent = RecentDT.Rows[q]["ArticleContent"].ToString();
                        ArticleObj.CatID = RecentDT.Rows[q]["CatID"].ToString();
                        ArticleObj.TagID = RecentDT.Rows[q]["TagID"].ToString();
                        ListArticle.Add(ArticleObj);
                    }
                    obj.RecentArticle = ListArticle;
                    ListObj.Add(obj);
                }
                this.ArticleList = ListObj;
            }
            catch (Exception)
            {
                
            }
        }
        /// <summary>
        /// 构造函数，获取分类下的文章
        /// </summary>
        /// <param name="Category"></param>
        /// <param name="PageNum"></param>
        public ArticleListModel(string Category,string PageNum)
        {
            try
            {
                int PagNum = Int32.Parse(PageNum);
                PagNum = (PagNum - 1) * 10;
                tArticleDAL ArticleDAL = new tArticleDAL();
                DataSet ds = ArticleDAL.GetAllAction(Category,PagNum.ToString(), "10");
                Total = Int32.Parse(ds.Tables[0].Rows[0]["RowNum"].ToString()); ;
                //计算总页数
                int pag = Total / 10;
                if (Total % 10 > 0)
                    pag++;
                Total = pag;
                DataTable dt = ds.Tables[1];
                List<ArticleModel> ListObj = new List<ArticleModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArticleModel obj = new ArticleModel();
                    obj.ArticleID = dt.Rows[i]["ArticleID"].ToString();
                    obj.TableType = dt.Rows[i]["TableType"].ToString();
                    obj.ArticleFrom = dt.Rows[i]["ArticleFrom"].ToString();
                    obj.FromLink = dt.Rows[i]["FromLink"].ToString();
                    obj.ArticleAuthor = dt.Rows[i]["ArticleAuthor"].ToString();
                    obj.AuthorLink = dt.Rows[i]["AuthorLink"].ToString();
                    obj.ArticleDate = DateTime.Parse(dt.Rows[i]["ArticleDate"].ToString());
                    obj.ArticleImage = dt.Rows[i]["ArticleImage"].ToString();
                    obj.ArticleTitle = dt.Rows[i]["ArticleTitle"].ToString();
                    obj.ArticleContent = dt.Rows[i]["ArticleContent"].ToString();
                    obj.CatID = dt.Rows[i]["CatID"].ToString();
                    obj.TagID = dt.Rows[i]["TagID"].ToString();
                    obj.Category = new CategoryModel(obj.CatID);
                    List<CategoryModel> CatList = new List<CategoryModel>();
                    tCategoryDAL CatDAL = new tCategoryDAL();
                    DataTable dtCat = CatDAL.GetAllCategory();
                    for (int j = 0; j < dtCat.Rows.Count; j++)
                    {
                        CategoryModel Cat = new CategoryModel();
                        Cat.CatID = dtCat.Rows[j]["CatID"].ToString();
                        Cat.CatCnName = dtCat.Rows[j]["CatCnName"].ToString();
                        Cat.CatEnName = dtCat.Rows[j]["CatEnName"].ToString();
                        CatList.Add(Cat);
                    }
                    obj.CategoryList = CatList;
                    DataTable RecentDT = ArticleDAL.GetRecentAction();
                    List<ArticleModel> ListArticle = new List<ArticleModel>();
                    for (int q = 0; q < RecentDT.Rows.Count; q++)
                    {
                        ArticleModel ArticleObj = new ArticleModel();
                        ArticleObj.ArticleID = RecentDT.Rows[q]["ArticleID"].ToString();
                        ArticleObj.TableType = RecentDT.Rows[q]["TableType"].ToString();
                        ArticleObj.ArticleFrom = RecentDT.Rows[q]["ArticleFrom"].ToString();
                        ArticleObj.FromLink = RecentDT.Rows[q]["FromLink"].ToString();
                        ArticleObj.ArticleAuthor = RecentDT.Rows[q]["ArticleAuthor"].ToString();
                        ArticleObj.AuthorLink = RecentDT.Rows[q]["AuthorLink"].ToString();
                        ArticleObj.ArticleDate = DateTime.Parse(RecentDT.Rows[q]["ArticleDate"].ToString());
                        ArticleObj.ArticleImage = RecentDT.Rows[q]["ArticleImage"].ToString();
                        ArticleObj.ArticleTitle = RecentDT.Rows[q]["ArticleTitle"].ToString();
                        ArticleObj.ArticleContent = RecentDT.Rows[q]["ArticleContent"].ToString();
                        ArticleObj.CatID = RecentDT.Rows[q]["CatID"].ToString();
                        ArticleObj.TagID = RecentDT.Rows[q]["TagID"].ToString();
                        ListArticle.Add(ArticleObj);
                    }
                    obj.RecentArticle = ListArticle;
                    ListObj.Add(obj);
                }
                this.ArticleList = ListObj;
            }
            catch (Exception)
            {

            }
        }
    }
}