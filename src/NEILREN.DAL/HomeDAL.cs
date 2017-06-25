using MySql.Data.MySqlClient;
using System.Data;

namespace NEILREN.DAL
{
    public class HomeDAL
    {
        Command cmd = new Command();
        public DataSet GetHome(string StartNum, string NextNum)
        {
            string sqlnum = "(SELECT count(*) AS RowNum FROM tArticle) UNION ALL (SELECT count(*) FROM tTalking) UNION ALL (SELECT count(*) FROM tAlbum)";
            string sql = "SELECT tArticle.ArticleTitle AS TITLE,tArticle.ArticleID AS ID,tArticle.TableType AS TTYPE,tArticle.ArticleImage AS IMAGES,tArticle.ArticleContent AS CONTENT,tArticle.ArticleDate AS DATET FROM tArticle";
            sql += " UNION ALL ";
            sql += "SELECT NULL AS TITLE,tTalking.TalkID AS ID,tTalking.TableType AS TTYPE,tTalking.TalkImage AS IMAGES,tTalking.TalkContent AS CONTENT,tTalking.TalkDate AS DATET FROM tTalking";
            sql += " UNION ALL ";
            sql += "SELECT tAlbum.AlbumTitle AS TITLE,tAlbum.AlbumID AS ID,tAlbum.TableType AS TTYPE,tAlbum.AlbumImage AS IMAGES,tAlbum.AlbumDesc AS CONTENT,tAlbum.AlbumDate AS DATET FROM tAlbum ";
            sql += "ORDER BY DATET DESC LIMIT @StartNum , @NextNum ";
            string FLinkSql = "SELECT * FROM tFrieLink WHERE IsEnable = 1";
            MySqlParameter[] parameters = new MySqlParameter[2];
            MySqlParameter StartNumPa = new MySqlParameter("@StartNum",MySqlDbType.Int32);
            MySqlParameter NextNumPa = new MySqlParameter("@NextNum", MySqlDbType.Int32);
            StartNumPa.Value = StartNum;
            NextNumPa.Value = NextNum;
            parameters[0] = StartNumPa;
            parameters[1] = NextNumPa;
            DataTable dt = cmd.SqlToDataTable(sql, parameters);
            DataTable dtNum = cmd.SqlToDataTable(sqlnum);
            DataTable dtFLink = cmd.SqlToDataTable(FLinkSql);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtNum);
            ds.Tables.Add(dt);
            ds.Tables.Add(dtFLink);
            return ds;
        }

        //下方代码适用于SQL Server
        //public DataSet GetHome(string StartNum, string NextNum)
        //{
        //    string sqlnum = "(SELECT count(*) AS RowNum FROM tArticle) UNION ALL (SELECT count(*) FROM tTalking) UNION ALL (SELECT count(*) FROM tAlbum)";
        //    string sql = "(SELECT tArticle.ArticleTitle AS TITLE,tArticle.ArticleID AS ID,tArticle.TableType AS TTYPE,tArticle.ArticleImage AS IMAGES,tArticle.ArticleContent AS CONTENT,tArticle.ArticleDate AS DATET FROM tArticle";
        //    sql += " UNION ALL ";
        //    sql += "SELECT NULL AS TITLE,tTalking.TalkID AS ID,tTalking.TableType AS TTYPE,tTalking.TalkImage AS IMAGES,tTalking.TalkContent AS CONTENT,tTalking.TalkDate AS DATET FROM tTalking";
        //    sql += " UNION ALL ";
        //    sql += "SELECT tAlbum.AlbumTitle AS TITLE,tAlbum.AlbumID AS ID,tAlbum.TableType AS TTYPE,tAlbum.AlbumImage AS IMAGES,tAlbum.AlbumDesc AS CONTENT,tAlbum.AlbumDate AS DATET FROM tAlbum)";
        //    sql += "ORDER BY DATET DESC OFFSET @StartNum ROW FETCH NEXT @NextNum ROWS only";
        //    string FLinkSql = "SELECT * FROM tFrieLink WHERE IsEnable = 1";
        //    SqlParameter[] parameters = new SqlParameter[2];
        //    SqlParameter StartNumPa = new SqlParameter("@StartNum", SqlDbType.Int);
        //    SqlParameter NextNumPa = new SqlParameter("@NextNum", SqlDbType.Int);
        //    StartNumPa.Value = StartNum;
        //    NextNumPa.Value = NextNum;
        //    parameters[0] = StartNumPa;
        //    parameters[1] = NextNumPa;
        //    DataTable dt = cmd.SqlToDataTable(sql, parameters);
        //    DataTable dtNum = cmd.SqlToDataTable(sqlnum);
        //    DataTable dtFLink = cmd.SqlToDataTable(FLinkSql);
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dtNum);
        //    ds.Tables.Add(dt);
        //    ds.Tables.Add(dtFLink);
        //    return ds;
        //}
    }
}
