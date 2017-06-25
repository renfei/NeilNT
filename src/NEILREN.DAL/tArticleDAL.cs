using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace NEILREN.DAL
{
    public class tArticleDAL
    {
        Command cmd = new Command();

        public DataTable GetByActionID(string ArticleID)
        {
            string sql = "SELECT * FROM tArticle WHERE ArticleID = @ArticleID";
            MySqlParameter[] parameters = {
	            new MySqlParameter("@ArticleID", ArticleID)
            };
            DataTable dt = cmd.SqlToDataTable(sql, parameters);
            if (dt != null && dt.Rows.Count == 1)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public DataSet GetAllAction(string StartNum, string NextNum)
        {
            string sql = "SELECT * FROM tArticle ORDER BY ArticleDate DESC LIMIT @StartNum , @NextNum ";
            string sqlnum = "SELECT count(*) AS RowNum FROM tArticle";
            MySqlParameter[] parameters = new MySqlParameter[2];
            MySqlParameter StartNumPa = new MySqlParameter("@StartNum", SqlDbType.Int);
            MySqlParameter NextNumPa = new MySqlParameter("@NextNum", SqlDbType.Int);
            StartNumPa.Value = StartNum;
            NextNumPa.Value = NextNum;
            parameters[0] = StartNumPa;
            parameters[1] = NextNumPa;
            DataTable dt = cmd.SqlToDataTable(sql, parameters);
            DataTable dtNum = cmd.SqlToDataTable(sqlnum);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dtNum);
                ds.Tables.Add(dt);
                return ds;
            }
            else
            {
                return null;
            }
        }

        public DataSet GetAllAction(string Category,string StartNum, string NextNum)
        {
            string sql = "SELECT * FROM tArticle WHERE CatID = @Category ORDER BY ArticleDate DESC LIMIT @StartNum , @NextNum ";
            string sqlnum = "SELECT count(*) AS RowNum FROM tArticle";
            MySqlParameter[] parameters = new MySqlParameter[3];
            MySqlParameter StartNumPa = new MySqlParameter("@StartNum", MySqlDbType.Int32);
            MySqlParameter NextNumPa = new MySqlParameter("@NextNum", MySqlDbType.Int32);
            MySqlParameter CategoryID = new MySqlParameter("@Category", MySqlDbType.Int32);
            StartNumPa.Value = StartNum;
            NextNumPa.Value = NextNum;
            CategoryID.Value = Category;
            parameters[0] = StartNumPa;
            parameters[1] = NextNumPa;
            parameters[2] = CategoryID;
            DataTable dt = cmd.SqlToDataTable(sql, parameters);
            DataTable dtNum = cmd.SqlToDataTable(sqlnum);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dtNum);
                ds.Tables.Add(dt);
                return ds;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetRecentAction()
        {
            string sql = "SELECT * FROM tArticle ORDER BY ArticleDate DESC LIMIT 0 , 10";
            DataTable dt = cmd.SqlToDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        /////////////////////////////////
        //public DataTable GetByActionID(string ArticleID)
        //{
        //    string sql = "SELECT * FROM tArticle WHERE ArticleID = @ArticleID";
        //    SqlParameter[] parameters = {
        //        new SqlParameter("@ArticleID", ArticleID)
        //    };
        //    DataTable dt = cmd.SqlToDataTable(sql, parameters);
        //    if (dt != null && dt.Rows.Count == 1)
        //    {
        //        return dt;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public DataSet GetAllAction(string StartNum, string NextNum)
        //{
        //    string sql = "SELECT * FROM tArticle ORDER BY ArticleDate DESC OFFSET @StartNum ROW FETCH NEXT @NextNum ROWS only";
        //    string sqlnum = "SELECT count(*) AS RowNum FROM tArticle";
        //    SqlParameter[] parameters = new SqlParameter[2];
        //    SqlParameter StartNumPa = new SqlParameter("@StartNum", SqlDbType.Int);
        //    SqlParameter NextNumPa = new SqlParameter("@NextNum", SqlDbType.Int);
        //    StartNumPa.Value = StartNum;
        //    NextNumPa.Value = NextNum;
        //    parameters[0] = StartNumPa;
        //    parameters[1] = NextNumPa;
        //    DataTable dt = cmd.SqlToDataTable(sql, parameters);
        //    DataTable dtNum = cmd.SqlToDataTable(sqlnum);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        DataSet ds = new DataSet();
        //        ds.Tables.Add(dtNum);
        //        ds.Tables.Add(dt);
        //        return ds;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public DataSet GetAllAction(string Category, string StartNum, string NextNum)
        //{
        //    string sql = "SELECT * FROM tArticle WHERE CatID = @Category ORDER BY ArticleDate DESC OFFSET @StartNum ROW FETCH NEXT @NextNum ROWS only";
        //    string sqlnum = "SELECT count(*) AS RowNum FROM tArticle";
        //    SqlParameter[] parameters = new SqlParameter[3];
        //    SqlParameter StartNumPa = new SqlParameter("@StartNum", SqlDbType.Int);
        //    SqlParameter NextNumPa = new SqlParameter("@NextNum", SqlDbType.Int);
        //    SqlParameter CategoryID = new SqlParameter("@Category", SqlDbType.Int);
        //    StartNumPa.Value = StartNum;
        //    NextNumPa.Value = NextNum;
        //    CategoryID.Value = Category;
        //    parameters[0] = StartNumPa;
        //    parameters[1] = NextNumPa;
        //    parameters[2] = CategoryID;
        //    DataTable dt = cmd.SqlToDataTable(sql, parameters);
        //    DataTable dtNum = cmd.SqlToDataTable(sqlnum);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        DataSet ds = new DataSet();
        //        ds.Tables.Add(dtNum);
        //        ds.Tables.Add(dt);
        //        return ds;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public DataTable GetRecentAction()
        //{
        //    string sql = "SELECT TOP 10 * FROM tArticle ORDER BY ArticleDate DESC";
        //    DataTable dt = cmd.SqlToDataTable(sql);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        return dt;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
