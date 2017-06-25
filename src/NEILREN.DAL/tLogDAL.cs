using MySql.Data.MySqlClient;
using System;

namespace NEILREN.DAL
{
    public class tLogDAL
    {
        Command cmd = new Command();
        public void SetLog(string Type, string Conntent)
        {
            string sql = "INSERT INTO tLog (LogDate,LogType,LogContent) VALUES('" + DateTime.Now.ToString() + "',@Type,@Conntent)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@Type", Type),
                new MySqlParameter("@Conntent", Conntent)
            };
            cmd.SqlToDataTable(sql, parameters);
        }

        //public void SetLog(string Type, string Conntent)
        //{
        //    string sql = "INSERT INTO tLog (LogDate,LogType,LogContent) VALUES('" + DateTime.Now.ToString() + "',@Type,@Conntent)";
        //    SqlParameter[] parameters = {
        //        new SqlParameter("@Type", Type),
        //        new SqlParameter("@Conntent", Conntent)
        //    };
        //    cmd.SqlToDataTable(sql, parameters);
        //}
    }
}
