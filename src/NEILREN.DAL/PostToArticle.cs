using MySql.Data.MySqlClient;
using System.Data;

namespace NEILREN.DAL
{
    public class PostToArticle
    {
        Command cmd = new Command();

        public string GetNewID(string OldID)
        {
            string sql = "SELECT ArticleID FROM tPostToArticle WHERE PostID = @OldID";
            MySqlParameter[] parameters = {
	            new MySqlParameter("@OldID", OldID)
            };
            DataTable dt = cmd.SqlToDataTable(sql, parameters);
            if (dt != null && dt.Rows.Count == 1)
            {
                return dt.Rows[0]["ArticleID"].ToString();
            }
            else
            {
                return "-1";
            }
        }

        //public string GetNewID(string OldID)
        //{
        //    string sql = "SELECT ArticleID FROM tPostToArticle WHERE PostID = @OldID";
        //    SqlParameter[] parameters = {
        //        new SqlParameter("@OldID", OldID)
        //    };
        //    DataTable dt = cmd.SqlToDataTable(sql, parameters);
        //    if (dt != null && dt.Rows.Count == 1)
        //    {
        //        return dt.Rows[0]["ArticleID"].ToString();
        //    }
        //    else
        //    {
        //        return "-1";
        //    }
        //}
    }
}
