using MySql.Data.MySqlClient;
using System.Data;

namespace NEILREN.DAL
{
    public class tCategoryDAL
    {
        Command cmd = new Command();

        public DataTable GetByCatID(string CatID)
        {
            string sql = "SELECT * FROM tCategory WHERE CatID = @CatID";
            MySqlParameter[] parameters = {
	            new MySqlParameter("@CatID", CatID)
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

        //public DataTable GetByCatID(string CatID)
        //{
        //    string sql = "SELECT * FROM tCategory WHERE CatID = @CatID";
        //    SqlParameter[] parameters = {
        //        new SqlParameter("@CatID", CatID)
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

        public DataTable GetAllCategory()
        {
            string sql = "SELECT * FROM tCategory";
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
    }
}
