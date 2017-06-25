using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEILREN.DAL
{
    public class SelectDAL
    {
        //MSSQLConnection connObj = new MSSQLConnection();
        //SqlCommand cmd = new SqlCommand();
        MYSQLConnection connObj = new MYSQLConnection();
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// 返回tAlbum表全部行
        /// </summary>
        /// <returns>tAlbum表全部行</returns>
        string SelecttAlbumAll(ref List<tAlbum> objlist)
        {
            objlist.Clear();
            string sql = "SELECT * FROM tAlbum";
            DataTable dt = new DataTable();
            string retn = SqlToDataTable(sql, ref dt);
            if (retn == "ok")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tAlbum obj = new tAlbum();
                    obj.AlbumID = Int32.Parse(dt.Rows[i]["AlbumID"].ToString());                           //相册编号
                    obj.TableType = dt.Rows[i]["TableType"].ToString();                                           //表类别
                    obj.AlbumTitle = dt.Rows[i]["AlbumTitle"].ToString();                                         //相册名
                    obj.AlbumDesc = dt.Rows[i]["AlbumDesc"].ToString();                                      //相册描述
                    obj.AlbumDate = DateTime.Parse(dt.Rows[i]["AlbumDate"].ToString());             //发布时间
                    obj.AlbumImage = dt.Rows[i]["AlbumImage"].ToString();                                  //缩略图
                    objlist.Add(obj);
                }
                return "ok";
            }
            else
                return retn;
        }

        /// <summary>
        /// 返回tArticle表全部行
        /// </summary>
        /// <returns>tArticle表全部行</returns>
        string SelecttArticleAll(ref List<tArticle> objlist)
        {
            objlist.Clear();
            string sql = "SELECT * FROM tArticle";
            DataTable dt = new DataTable();
            string retn = SqlToDataTable(sql, ref dt);
            if (retn == "ok")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tArticle obj = new tArticle();
                    obj.ArticleID = Int32.Parse(dt.Rows[i]["ArticleID"].ToString());                //文章ID
                    obj.TableType = dt.Rows[i]["TableType"].ToString();                               //表类别
                    obj.ArticleFrom = dt.Rows[i]["ArticleFrom"].ToString();                          //文章来源
                    obj.FromLink = dt.Rows[i]["FromLink"].ToString();                                 //文章来源链接
                    obj.ArticleAuthor = dt.Rows[i]["ArticleAuthor"].ToString();                     //文章作者
                    obj.AuthorLink = dt.Rows[i]["AuthorLink"].ToString();                            //作者链接
                    obj.ArticleDate = DateTime.Parse(dt.Rows[i]["ArticleDate"].ToString());  //发布时间
                    obj.ArticleImage = dt.Rows[i]["ArticleImage"].ToString();                       //特色图像
                    obj.ArticleTitle = dt.Rows[i]["ArticleTitle"].ToString();                             //文章标题
                    obj.ArticleContent = dt.Rows[i]["ArticleContent"].ToString();                 //文章内容
                    obj.CatID = Int32.Parse(dt.Rows[i]["CatID"].ToString());                         //分类ID
                    obj.TagID = Int32.Parse(dt.Rows[i]["TagID"].ToString());                        //标签ID
                    objlist.Add(obj);
                }
                return "ok";
            }
            else
                return retn;
        }

        /// <summary>
        /// 返回tCategory表全部行
        /// </summary>
        /// <returns>tCategory表全部行</returns>
        string SelecttCategoryAll(ref List<tCategory> objlist)
        {
            objlist.Clear();
            string sql = "SELECT * FROM tCategory";
            DataTable dt = new DataTable();
            string retn = SqlToDataTable(sql, ref dt);
            if (retn == "ok")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tCategory obj = new tCategory();
                    obj.CatID = Int32.Parse(dt.Rows[i]["CatID"].ToString());    //标签ID
                    obj.CatEnName = dt.Rows[i]["CatEnName"].ToString();    //标签英文名
                    obj.CatCnName = dt.Rows[i]["CatCnName"].ToString();    //标签名
                    objlist.Add(obj);
                }
                return "ok";
            }
            else
                return retn;
        }

        /// <summary>
        /// 返回tComment表全部行
        /// </summary>
        /// <returns>tComment表全部行</returns>
        string SelecttCommentAll(ref List<tComment> objlist)
        {
            objlist.Clear();
            string sql = "SELECT * FROM tComment";
            DataTable dt = new DataTable();
            string retn = SqlToDataTable(sql, ref dt);
            if (retn == "ok")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tComment obj = new tComment();
                    obj.CommentID = Int32.Parse(dt.Rows[i]["CommentID"].ToString());    //评论ID
                    obj.ObjectID = Int32.Parse(dt.Rows[i]["ObjectID"].ToString());    //被评论的文章/说说/相册/照片
                    obj.CommentType = Int32.Parse(dt.Rows[i]["CommentType"].ToString());    //评论类型，评论1文章2说说3相册4相片
                    obj.AuthorName = dt.Rows[i]["AuthorName"].ToString();    //评论者称呼
                    obj.AuthorEmail = dt.Rows[i]["AuthorEmail"].ToString();    //评论者邮箱
                    obj.AuthorURL = dt.Rows[i]["AuthorURL"].ToString();    //评论者URL
                    obj.AuthorIP = dt.Rows[i]["AuthorIP"].ToString();    //评论者IP
                    obj.CommentDate = DateTime.Parse(dt.Rows[i]["CommentDate"].ToString());    //评论时间
                    obj.CommentContent = dt.Rows[i]["CommentContent"].ToString();    //评论正文
                    obj.CommentParent = Int32.Parse(dt.Rows[i]["CommentParent"].ToString());    //父级评论ID
                    obj.UserID = Int32.Parse(dt.Rows[i]["UserID"].ToString());    //评论用户ID(注册用户)
                    objlist.Add(obj);
                }
                return "ok";
            }
            else
                return retn;
        }

        /// <summary>
        /// 执行SQL查询语句返回DataTable
        /// </summary>
        /// <param name="sql">查询类SQL语句</param>
        /// <param name="dt">将被填充结果的DataTable</param>
        /// <returns>ok或者异常信息</returns>
        string SqlToDataTable(string sql, ref DataTable dt)
        {
            cmd.Connection = connObj.conn;
            cmd.CommandText = sql;
            try
            {
                if (!connObj.IsOpen)
                    connObj.Open();
                //SqlDataAdapter sdap = new SqlDataAdapter();
                MySqlDataAdapter sdap = new MySqlDataAdapter();
                sdap.SelectCommand = cmd;
                dt.Clear();
                sdap.Fill(dt);
                connObj.Close();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
