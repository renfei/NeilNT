using MySql.Data.MySqlClient;
using System.Data;

namespace NEILREN.DAL
{
    public class SearchDAL
    {
        Command cmd = new Command();
        public DataSet SearchByWd(string Search, string StartNum, string NextNum)
        {
            string sql = "SELECT tArticle.ArticleTitle AS TITLE,tArticle.ArticleID AS ID,tArticle.TableType AS TTYPE,tArticle.ArticleImage AS IMAGES,";
            sql += "tArticle.ArticleContent AS CONTENT,tArticle.ArticleDate AS DATET FROM tArticle ";
            sql += "WHERE tArticle.ArticleTitle LIKE @Search OR  tArticle.ArticleContent LIKE @Search";
            sql += " UNION ALL ";
            sql += "SELECT NULL AS TITLE,tTalking.TalkID AS ID,tTalking.TableType AS TTYPE,tTalking.TalkImage AS IMAGES,tTalking.TalkContent AS CONTENT,";
            sql += "tTalking.TalkDate AS DATET FROM tTalking ";
            sql += "WHERE tTalking.TalkContent LIKE @Search";
            sql += " UNION ALL ";
            sql += "SELECT tAlbum.AlbumTitle AS TITLE,tAlbum.AlbumID AS ID,tAlbum.TableType AS TTYPE,tAlbum.AlbumImage AS IMAGES,tAlbum.AlbumDesc AS CONTENT,";
            sql += "tAlbum.AlbumDate AS DATET FROM tAlbum ";
            sql += "WHERE tAlbum.AlbumTitle LIKE @Search OR  tAlbum.AlbumDesc LIKE @Search ";
            sql += "ORDER BY DATET DESC LIMIT @StartNum , @NextNum ";
            string sqlNum = "SELECT count(*) AS RowNum FROM tArticle ";
            sqlNum += "WHERE tArticle.ArticleTitle LIKE @SearchNum OR  tArticle.ArticleContent LIKE @SearchNum";
            sqlNum += " UNION ALL ";
            sqlNum += "SELECT count(*) AS RowNum FROM tTalking ";
            sqlNum += "WHERE tTalking.TalkContent LIKE @SearchNum";
            sqlNum += " UNION ALL ";
            sqlNum += "SELECT count(*) AS RowNum FROM tAlbum ";
            sqlNum += "WHERE tAlbum.AlbumTitle LIKE @SearchNum OR  tAlbum.AlbumDesc LIKE @SearchNum";
            MySqlParameter[] parameters = new MySqlParameter[3];
            MySqlParameter SearchPa = new MySqlParameter("@Search", MySqlDbType.String);
            MySqlParameter StartNumPa = new MySqlParameter("@StartNum", MySqlDbType.Int32);
            MySqlParameter NextNumPa = new MySqlParameter("@NextNum", MySqlDbType.Int32);
            SearchPa.Value = "%" + Search + "%";
            StartNumPa.Value = StartNum;
            NextNumPa.Value = NextNum;
            parameters[0] = SearchPa;
            parameters[1] = StartNumPa;
            parameters[2] = NextNumPa;
            MySqlParameter[] parameters2 = {
                                            new MySqlParameter("@SearchNum","%" + Search + "%")
                                        };
            DataTable dt = cmd.SqlToDataTable(sql, parameters);
            DataTable dtNum = cmd.SqlToDataTable(sqlNum, parameters2);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtNum);
            ds.Tables.Add(dt);
            return ds;
        }

        //public DataSet SearchByWd(string Search, string StartNum, string NextNum)
        //{
        //    string sql = "(SELECT tArticle.ArticleTitle AS TITLE,tArticle.ArticleID AS ID,tArticle.TableType AS TTYPE,tArticle.ArticleImage AS IMAGES,";
        //    sql += "tArticle.ArticleContent AS CONTENT,tArticle.ArticleDate AS DATET FROM tArticle ";
        //    sql += "WHERE tArticle.ArticleTitle LIKE @Search OR  tArticle.ArticleContent LIKE @Search";
        //    sql += " UNION ALL ";
        //    sql += "SELECT NULL AS TITLE,tTalking.TalkID AS ID,tTalking.TableType AS TTYPE,tTalking.TalkImage AS IMAGES,tTalking.TalkContent AS CONTENT,";
        //    sql += "tTalking.TalkDate AS DATET FROM tTalking ";
        //    sql += "WHERE tTalking.TalkContent LIKE @Search";
        //    sql += " UNION ALL ";
        //    sql += "SELECT tAlbum.AlbumTitle AS TITLE,tAlbum.AlbumID AS ID,tAlbum.TableType AS TTYPE,tAlbum.AlbumImage AS IMAGES,tAlbum.AlbumDesc AS CONTENT,";
        //    sql += "tAlbum.AlbumDate AS DATET FROM tAlbum ";
        //    sql += "WHERE tAlbum.AlbumTitle LIKE @Search OR  tAlbum.AlbumDesc LIKE @Search)";
        //    sql += "ORDER BY DATET DESC OFFSET @StartNum ROW FETCH NEXT @NextNum ROWS only";
        //    string sqlNum = "SELECT count(*) AS RowNum FROM tArticle ";
        //    sqlNum += "WHERE tArticle.ArticleTitle LIKE @SearchNum OR  tArticle.ArticleContent LIKE @SearchNum";
        //    sqlNum += " UNION ALL ";
        //    sqlNum += "SELECT count(*) AS RowNum FROM tTalking ";
        //    sqlNum += "WHERE tTalking.TalkContent LIKE @SearchNum";
        //    sqlNum += " UNION ALL ";
        //    sqlNum += "SELECT count(*) AS RowNum FROM tAlbum ";
        //    sqlNum += "WHERE tAlbum.AlbumTitle LIKE @SearchNum OR  tAlbum.AlbumDesc LIKE @SearchNum";
        //    SqlParameter[] parameters = new SqlParameter[3];
        //    SqlParameter SearchPa = new SqlParameter("@Search", SqlDbType.NVarChar);
        //    SqlParameter StartNumPa = new SqlParameter("@StartNum", SqlDbType.Int);
        //    SqlParameter NextNumPa = new SqlParameter("@NextNum", SqlDbType.Int);
        //    SearchPa.Value = "%" + Search + "%";
        //    StartNumPa.Value = StartNum;
        //    NextNumPa.Value = NextNum;
        //    parameters[0] = SearchPa;
        //    parameters[1] = StartNumPa;
        //    parameters[2] = NextNumPa;
        //    SqlParameter[] parameters2 = {
        //                                    new SqlParameter("@SearchNum","%" + Search + "%")
        //                                };
        //    DataTable dt = cmd.SqlToDataTable(sql, parameters);
        //    DataTable dtNum = cmd.SqlToDataTable(sqlNum, parameters2);
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dtNum);
        //    ds.Tables.Add(dt);
        //    return ds;
        //}
    }
}
